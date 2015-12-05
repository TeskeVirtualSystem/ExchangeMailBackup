using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;


using SvcInstaller;

namespace Exchange_Manager
{
    public partial class MainForm : Form
    {
        private DatabaseManager dbman;
        private String ServicePath;
        private String EncServerPass;
        private String ServerIP;
        private String ServerUser;
        private List<ExchangeMailbox> mboxs;
        private Boolean connected = false;
        private int SelectedMailboxIndex;
        private String SelectedMailboxName;
        private bool FullBackup;
        private int LastDays;
        private List<ScheduledAction> schedules;
        
        public MainForm()
        {
            InitializeComponent();
        }
                delegate void CmdCompleteCallback(object sender, PSBGCompletedEventArgs e);

        public void ReceiveMBOXCompleted(object sender, PSBGCompletedEventArgs e)
        {
            if (this.contentManager.InvokeRequired)
            {
                CmdCompleteCallback d = new CmdCompleteCallback(ReceiveMBOXCompleted);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                if (!e.failed)
                {
                    mailboxList.Text = "";
                    mailboxList.Items.Clear();
                    mboxs = ExchangeUtils.ProcessMBOXOutput(e.OutData);
                    for (int i = 0; i < mboxs.Count(); i++)
                    {
                        mailboxList.Items.Add(i + ": " + mboxs[i].Alias);
                    }
                    contentManager.TabPages.Add(backupConfig);
                    contentManager.TabPages.Add(currentRequests);
                    //MessageBox.Show("Conectado e lista de caixas recebida!");
                    connectButton.Enabled = true;
                    connected = true;
                    requestUpdate.Enabled = true;
                    connectButton.Text = "Conectado, clique aqui para desconectar.";
                }
                else
                {
                    connected = false;
                    requestUpdate.Enabled = false;
                    contentManager.TabPages.Remove(backupConfig);
                    contentManager.TabPages.Remove(currentRequests);
                    connectButton.Text = "Conectar e Baixar Lista de Usuários";
                    serverIPtextBox.Enabled = true;
                    serverUserTextBox.Enabled = true;
                    serverPassTextBox.Enabled = true;
                    saveServerConfig.Enabled = true;
                    MessageBox.Show("Não foi possível conectar: \r\n"+e.failmsg);
                }
            }
        }
        public void RefreshSchedules()
        {
            schedules = dbman.GetScheduledActions();
            scheduleList.Items.Clear();
            for (int i = 0; i < schedules.Count; i++)
            {
                scheduleList.Items.Add(schedules[i].Id+":"+schedules[i].Mailbox);
            }
            serviceNumSchedules.Text = dbman.GetScheduledActions().Count().ToString();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            contentManager.TabPages.Remove(backupConfig);
            contentManager.TabPages.Remove(currentRequests);
            ServicePath = Utils.ReadReg("ServicePath");
            EncServerPass = Utils.ReadReg("ServerPass");
            ServerIP = Utils.ReadReg("ServerIP");
            ServerUser = Utils.ReadReg("ServerUser");
            if (ServicePath != null && ServicePath.Trim().Length != 0)
                dbman = new DatabaseManager(ServicePath + "\\config.db");
            if (ServicePath == null || ServicePath.Trim().Length == 0)
            {
                MessageBox.Show("Você precisa primeiro executar o serviço em algum diretório!");
                Close();
            }
            else
            {
                serverIPtextBox.Text = ServerIP;
                serverUserTextBox.Text = ServerUser;
                if (EncServerPass != null && EncServerPass.Trim().Length != 0)
                    serverPassTextBox.Text = Utils.DecryptPassword(EncServerPass) ;
                serviceDirectoryLabel.Text = ServicePath;
                RefreshSchedules();
            }
        }

        private void saveServerConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente salvar as confirgurações?", "Salvar Configurações", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                Utils.WriteReg("ServerIP", serverIPtextBox.Text);
                Utils.WriteReg("ServerUser", serverUserTextBox.Text);
                Utils.WriteReg("ServerPass", Utils.EncryptPassword(serverPassTextBox.Text));
                MessageBox.Show("Configurações Salvas!");
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                EncServerPass = Utils.EncryptPassword(serverPassTextBox.Text);
                ServerUser = serverUserTextBox.Text;
                ServerIP = serverIPtextBox.Text;
                Collection<Command> cmd = ExchangeUtils.GetMailboxes();
                PSBGWorker exportWorker = new PSBGWorker(ServerUser, Utils.DecryptPassword(EncServerPass), ServerIP, cmd, 0);
                exportWorker.Completed += ReceiveMBOXCompleted;
                exportWorker.InitTask();
                connectButton.Enabled = false;
                connectButton.Text = "Conectando";
                serverIPtextBox.Enabled = false;
                serverUserTextBox.Enabled = false;
                serverPassTextBox.Enabled = false;
                saveServerConfig.Enabled = false;
            }
            else
            {
                connected = false;
                requestUpdate.Enabled = false;
                contentManager.TabPages.Remove(backupConfig);
                connectButton.Text = "Conectar e Baixar Lista de Usuários";
                serverIPtextBox.Enabled = true;
                serverUserTextBox.Enabled = true;
                serverPassTextBox.Enabled = true;
                saveServerConfig.Enabled = true;
            }
        }

        private void startCreateSchedule_Click(object sender, EventArgs e)
        {
            String[] mbx = mailboxList.Text.Split(':');
            SelectedMailboxName = mbx[1].Trim();
            SelectedMailboxIndex = Int32.Parse(mbx[0].Trim());
            scheduleBox.Text = "Criando agendamento para: " + mbx[1].Trim();
            scheduleBox.Visible = true;
        }

        private void createSchedule_Click(object sender, EventArgs e)
        {
            if (directoryTextBox.Text.Trim().Length > 0)
            {
                ScheduledAction action = new ScheduledAction(SelectedMailboxName, FullBackup ? 1 : 0, LastDays, directoryTextBox.Text.Trim(), whenHour.Text, whenMinute.Text, whenDayOfWeek.SelectedIndex==7?"*":whenDayOfWeek.SelectedIndex.ToString(), whenDayOfMonth.Text, whenMonth.Text);
                if (MessageBox.Show("Criar um agendamento para caixa \""+SelectedMailboxName+"\" com as configurações selecionadas?", "Criar agendamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dbman.AddSchedule(action);
                    MessageBox.Show("Agendamento criado!");
                    SelectedMailboxName = "";
                    SelectedMailboxIndex = -1;
                    LastDays = 15;
                    directoryTextBox.Text = "";
                    whenHour.Text = "*";
                    whenMinute.Text = "*";
                    whenMonth.Text = "*";
                    whenDayOfMonth.Text = "*";
                    whenDayOfWeek.Text = "Qualquer";
                    fullBackupRadio.Checked = true;
                    lastMonth.Checked = false;
                    lastWeekRadio.Checked = false;
                    lastDaysRadio.Checked = false;
                    lastDaysTextBox.Enabled = false;
                    scheduleBox.Visible = false;
                }               
            }
            else
            {
                MessageBox.Show("Preencha o campo \"Destino\"");
            }
        }

        private void whenHour_Leave(object sender, EventArgs e)
        {
            int bla = 2;
            bool test = Int32.TryParse(whenHour.Text, out bla);
            if (!whenHour.Text.Trim().Equals("*") && !test)
            {
                MessageBox.Show("Valor inválido no campo \"Hora\". Valores numéricos e * são válidos.");
                whenHour.Text = "*";
            }
            else if ((bla > 24 || bla < 0) && test)
            {
                MessageBox.Show("Valor da Hora deve ser maior ou igual a 0 e menor que 24");
                whenHour.Text = "*";
            }
        }

        private void whenMinute_Leave(object sender, EventArgs e)
        {
            int bla = 2;
            bool test = Int32.TryParse(whenMinute.Text, out bla);
            if (!whenMinute.Text.Trim().Equals("*") && !test)
            {
                MessageBox.Show("Valor inválido no campo \"Minuto\". Valores numéricos e * são válidos.");
                whenMinute.Text = "*";
            }
            else if ((bla > 60 || bla < 0) && test)
            {
                MessageBox.Show("Valor do Minuto deve ser maior ou igual a 0 e menor que 60");
                whenMinute.Text = "*";
            }
        }

        private void whenDayOfMonth_Leave(object sender, EventArgs e)
        {
            int bla = 2;
            bool test = Int32.TryParse(whenDayOfMonth.Text, out bla);
            if (!whenDayOfMonth.Text.Trim().Equals("*") && !test)
            {
                MessageBox.Show("Valor inválido no campo \"Dia do Mês\". Valores numéricos e * são válidos.");
                whenMonth.Text = "*";
            }
            else if ((bla > 30 || bla < 1) && test)
            {
                MessageBox.Show("Valor do Dia do Mês deve ser maior que 0 e menor que 30");
                whenMonth.Text = "*";
            }
        }

        private void whenMonth_TextChanged(object sender, EventArgs e)
        {
            int bla = 2;
            bool test = Int32.TryParse(whenMonth.Text, out bla);
            if (!whenMonth.Text.Trim().Equals("*") && !test)
            {
                MessageBox.Show("Valor inválido no campo \"Mês\". Valores numéricos e * são válidos.");
                whenMonth.Text = "*";
            }
            else if ((bla > 12 || bla < 1) && test)
            {
                MessageBox.Show("Valor do Mês deve ser maior que 0 e menor que 13");
                whenMonth.Text = "*";
            }
        }

        private void BackupRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (fullBackupRadio.Checked)
            {
                FullBackup = true;
                LastDays = -1;
                lastDaysTextBox.Enabled = false;
            }
            else if (lastMonth.Checked)
            {
                FullBackup = false;
                LastDays = 30;
                lastDaysTextBox.Enabled = false;
            }
            else if (lastWeekRadio.Checked)
            {
                FullBackup = false;
                LastDays = 7;
                lastDaysTextBox.Enabled = false;
            }
            else if (lastDaysRadio.Checked)
            {
                FullBackup = false;
                LastDays = 15;
                lastDaysTextBox.Enabled = true;
            }
        }

        private void lastDaysTextBox_Leave(object sender, EventArgs e)
        {
            int bla = -1;
            bool test = Int32.TryParse(lastDaysTextBox.Text, out bla);
            if (test && bla > 0)
            {
                LastDays = bla;
            }
            else
            {
                LastDays = -1;
                lastDaysTextBox.Text = "15";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Certifique-se que seja um caminho de rede e que o servidor tenha permissão para acessar.");
            findDirectory.ShowDialog();
            directoryTextBox.Text = findDirectory.SelectedPath;
        }

        private void findDirectory_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Certifique-se que seja um caminho de rede e que o servidor tenha permissão para acessar.");
            findDirectory.ShowDialog();
            directoryTextBoxManager.Text = findDirectory.SelectedPath;
        }

        private void scheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduledAction tmp = schedules[scheduleList.SelectedIndex];
            whenHourManager.Text = (tmp.ScheduleTime.hour == -1) ? "*" : tmp.ScheduleTime.hour.ToString();
            whenMinuteManager.Text = (tmp.ScheduleTime.minute == -1) ? "*" : tmp.ScheduleTime.minute.ToString();
            whenDayOfMonthManager.Text = (tmp.ScheduleTime.dayofmonth == -1) ? "*" : tmp.ScheduleTime.dayofmonth.ToString();
            whenMonthManager.Text = (tmp.ScheduleTime.month == -1) ? "*" : tmp.ScheduleTime.month.ToString();
            whenDayOfWeekManager.SelectedIndex = (tmp.ScheduleTime.dayofweek == -1) ? 7 : tmp.ScheduleTime.dayofweek;
            directoryTextBoxManager.Text = tmp.Target;
            managerBox.Text = "Agendamento de " + tmp.Mailbox;
            fullBackupRadioManager.Checked = false;
            lastWeekRadioManager.Checked = false;
            lastMonthManager.Checked = false;
            lastDaysRadioManager.Checked = false;
            lastDaysTextBox.Enabled = false;
            fullBackupRadioManager.Checked = tmp.FullBackup;
            switch (tmp.LastDays)
            {
                case -1: fullBackupRadioManager.Checked = true; break;
                case 7: lastWeekRadioManager.Checked = true; break;
                case 30: lastMonthManager.Checked = true; break;
                default: lastDaysRadioManager.Checked = true; lastDaysTextBox.Enabled = true; break;
            }
            lastDaysTextBoxManager.Text = tmp.LastDays.ToString();
            managerBox.Visible = true;
        }
        private void ManagerRadioCheckedChanged(object sender, EventArgs e)
        {
                lastDaysTextBoxManager.Enabled = lastDaysRadioManager.Checked;
                if (lastWeekRadioManager.Checked)
                    lastDaysTextBoxManager.Text = "7";
                else if (lastMonthManager.Checked)
                    lastDaysTextBoxManager.Text = "30";
                else if (fullBackupRadioManager.Checked)
                    lastDaysTextBoxManager.Text = "-1";
                else
                    lastDaysTextBoxManager.Text = "15";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = schedules[scheduleList.SelectedIndex].Id;
            schedules[scheduleList.SelectedIndex] = new ScheduledAction(id, schedules[scheduleList.SelectedIndex].Mailbox, fullBackupRadioManager.Checked ? 1 : 0, Int16.Parse(lastDaysTextBoxManager.Text), directoryTextBoxManager.Text.Trim(), whenHourManager.Text, whenMinuteManager.Text, whenDayOfWeekManager.SelectedIndex == 7 ? "*" : whenDayOfWeekManager.SelectedIndex.ToString(), whenDayOfMonthManager.Text, whenMonthManager.Text);
            dbman.ChangeSchedule(id, schedules[scheduleList.SelectedIndex]);
            MessageBox.Show("Alterado!");
            managerBox.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbman.DeleteSchedule(schedules[scheduleList.SelectedIndex].Id);
            RefreshSchedules();
            MessageBox.Show("Apagado!");
            managerBox.Visible = false;

        }

        public void ProcessRequestsOutput(object sender, PSBGCompletedEventArgs e)
        {
            if (this.requestsView.InvokeRequired)
            {
                CmdCompleteCallback d = new CmdCompleteCallback(ProcessRequestsOutput);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                if (!e.failed)
                {
                    //dataGridView1
                    List<ExchangeRequest> requests = new List<ExchangeRequest>();
                    ExchangeRequest req = new ExchangeRequest();
                    RequestOutput outd = e.OutData;
                    for (int i = 0, len = outd.ResponseTitles.Count(); i < len; i++)
                    {
                        String title = outd.ResponseTitles[i].ToLower();
                        String value = outd.ResponseValues[i];
                        switch (title)
                        {
                            case "name": req.Name = value; break;
                            case "status": req.Status = value; break;
                            case "filepath": req.Filepath = value; break;
                            case "sourcealias": req.SourceAlias = value; break;
                            case "sourcemailboxidentity": req.SourceMailboxIdentity = value; break;
                            case "contentfilter": req.ContentFilter = value; break;
                            case "overallduration": req.OverallDuration = value; break;
                            case "totalqueuedduration": req.TotalQueuedDuration = value; break;
                            case "totalinprogressduration": req.TotalInProgressDuration = value; break;
                            case "percentcomplete": req.PercentComplete = value; break;
                            case "objectstate": requests.Add(req); req = new ExchangeRequest(); break;
                        }
                    }

                    requestsView.ColumnCount = 7;
                    requestsView.Columns[0].Name = "Name";
                    requestsView.Columns[1].Name = "Status";
                    requestsView.Columns[2].Name = "SourceAlias";
                    requestsView.Columns[3].Name = "SourceMailboxIdentity";
                    requestsView.Columns[4].Name = "TotalInProgressDuration";
                    requestsView.Columns[5].Name = "PercentComplete";
                    requestsView.Columns[6].Name = "FilePath";
                    int c = 0;
                    foreach (ExchangeRequest reqo in requests)
                    {
                        if (requestsView.Rows.Count > c)
                        {
                            requestsView.Rows[c].Cells[0].Value = reqo.Name;
                            requestsView.Rows[c].Cells[1].Value = reqo.Status;
                            requestsView.Rows[c].Cells[2].Value = reqo.SourceAlias;
                            requestsView.Rows[c].Cells[3].Value = reqo.SourceMailboxIdentity;
                            requestsView.Rows[c].Cells[4].Value = reqo.TotalInProgressDuration;
                            requestsView.Rows[c].Cells[5].Value = reqo.PercentComplete;
                            requestsView.Rows[c].Cells[6].Value = reqo.Filepath;
                        }
                        else
                        {
                            requestsView.Rows.Add(new string[] {
                                reqo.Name,
                                reqo.Status,
                                reqo.SourceAlias,
                                reqo.SourceMailboxIdentity,
                                reqo.TotalInProgressDuration,
                                reqo.PercentComplete,
                                reqo.Filepath
                            });
                        }
                        switch (reqo.Status.ToLower())
                        {
                            case "completed":
                                requestsView.Rows[c].DefaultCellStyle.BackColor = Color.Green; break;
                            case "failed":
                                requestsView.Rows[c].DefaultCellStyle.BackColor = Color.Red; break;
                            case "inprogress":
                                requestsView.Rows[c].DefaultCellStyle.BackColor = Color.Cyan; break;
                            default:
                                requestsView.Rows[c].DefaultCellStyle.BackColor = Color.Yellow; break;
                        }
                        c++;
                    }

                    if (requestsView.Rows.Count > requests.Count)
                    {
                        for (int i = requests.Count; i < requestsView.Rows.Count; i++)
                        {
                            requestsView.Rows.RemoveAt(requestsView.Rows.Count - 1);
                        }
                        requestsView.Refresh();
                    }
                    requestUpdate.Start();
                }
            }
        }

        public void CleanCurrentRequestsCallback(object sender, PSBGCompletedEventArgs e)
        {
            if (this.requestsView.InvokeRequired)
            {
                CmdCompleteCallback d = new CmdCompleteCallback(CleanCurrentRequestsCallback);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                if (e.failed)
                    MessageBox.Show("Falha ao limpar requests: "+e.failmsg);
                else
                    MessageBox.Show("Requests limpos!");
            }
        }

        private void cleanCurrentRequests_Click(object sender, EventArgs e)
        {
            Collection<Command> cmd = ExchangeUtils.CleanDoneRequests();
            PSBGWorker exportWorker = new PSBGWorker(ServerUser, Utils.DecryptPassword(EncServerPass), ServerIP, cmd, 0);
            exportWorker.Completed += CleanCurrentRequestsCallback;
            exportWorker.InitTask();
            cleanCurrentRequests.Enabled = false;
        }

        private void requestUpdate_Tick(object sender, EventArgs e)
        {
            String cmd = "Get-MailboxExportRequest | Get-MailboxExportRequestStatistics";
            PSBGWorker exportWorker = new PSBGWorker(ServerUser, Utils.DecryptPassword(EncServerPass), ServerIP, cmd);
            exportWorker.Completed += ProcessRequestsOutput;
            exportWorker.InitTask();
            requestUpdate.Stop();
        }

        private void startServiceButton_Click(object sender, EventArgs e)
        {
            Utils.StartService("BackupManager");
        }

        private void stopServiceButton_Click(object sender, EventArgs e)
        {
            Utils.StopService("BackupManager");
        }

        private void serviceStatusUpdate_Tick(object sender, EventArgs e)
        {
            Utils.ServiceStatus status = Utils.GetServiceStatus("BackupManager");
            serviceStatus.Text = status.ToString();
            switch(status)
            {
                case Utils.ServiceStatus.Stopped:
                case Utils.ServiceStatus.Paused:
                    stopServiceButton.Enabled = false;
                    startServiceButton.Enabled = true;
                    serviceStatus.ForeColor = Color.Red;
                    break;
                case Utils.ServiceStatus.Running:
                    stopServiceButton.Enabled = true;
                    startServiceButton.Enabled = false;
                    serviceStatus.ForeColor = Color.Green;
                    break;
                case Utils.ServiceStatus.Starting:
                case Utils.ServiceStatus.Stopping:
                case Utils.ServiceStatus.Pausing:
                    stopServiceButton.Enabled = false;
                    startServiceButton.Enabled = false;
                    serviceStatus.ForeColor = Color.Yellow;
                    break;
            }
        }

        private void cleanFailedRequests_Click(object sender, EventArgs e)
        {
            Collection<Command> cmd = ExchangeUtils.CleanFailedRequests();
            PSBGWorker exportWorker = new PSBGWorker(ServerUser, Utils.DecryptPassword(EncServerPass), ServerIP, cmd, 0);
            exportWorker.Completed += CleanCurrentRequestsCallback;
            exportWorker.InitTask();
            cleanCurrentRequests.Enabled = false;
        }
    }
}
