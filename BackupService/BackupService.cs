using Exchange_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace BackupService
{
    public partial class BackupService : ServiceBase
    {
        private DatabaseManager dbman;
        private String ServicePath = "";
        private String EncServerPass = "";
        private String ServerIP = "";
        private String ServerUser = "";
        private System.Timers.Timer scheduleTimer;

        public BackupService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("Mail Backup"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Mail Backup", "Mail Backup");
            }
            mainLogger.Source = "Mail Backup";
            mainLogger.Log = "Mail Backup";

            ServicePath = Utils.ReadReg("ServicePath");
            EncServerPass = Utils.ReadReg("ServerPass");
            ServerIP = Utils.ReadReg("ServerIP");
            ServerUser = Utils.ReadReg("ServerUser");

            mainLogger.WriteEntry("Initializing DB at " + ServicePath + "\\config.db");
            dbman = new DatabaseManager(ServicePath + "\\config.db");
            mainLogger.WriteEntry("Done");

            this.scheduleTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTimer)).BeginInit();
            //this.ScheduleTimer.Interval = 300000; // 5 Minutes
            this.scheduleTimer.Interval = 60000;
            this.scheduleTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.ScheduleAction);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTimer)).EndInit();
        }

        protected override void OnStart(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            mainLogger.WriteEntry("Backup Service Started");
            mainLogger.WriteEntry("Timer started! Interval: " + (scheduleTimer.Interval / 60000) + " minutes.");
            mainLogger.WriteEntry("Current Culture: " + Thread.CurrentThread.CurrentCulture.DisplayName);
            scheduleTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            mainLogger.WriteEntry("Backup Service Stopped");
            scheduleTimer.Enabled = false;
        }

        private void ScheduleAction(object sender, System.Timers.ElapsedEventArgs e)
        {
            mainLogger.WriteEntry("Backup Service Tick. Checking Scheduled Actions");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime now = DateTime.Now;
            List<ScheduledAction> Schedules = dbman.GetScheduledActions();
            mainLogger.WriteEntry("Scheduled Actions: "+Schedules.Count);
            foreach (ScheduledAction Schedule in Schedules)
            {
                if (Schedule.ScheduleTime.isOnDate(now))
                    DoSchedule(Schedule);
            }
        }
        public void CmdCompleted(object sender, PSBGCompletedEventArgs e)
        {
            mainLogger.WriteEntry("Agendamento inicializado de ID " + e.Id + ": " + e.Output);
        }

        private void DoSchedule(ScheduledAction Schedule)
        {
            // Correção de bug no Powershell. A data precisa estar no formato inglês.
            Collection<Command> cmd;
            if (Schedule.FullBackup)
            {
                mainLogger.WriteEntry("Executando agendamento de " + Schedule.Mailbox + " para " + Schedule.Target + " programado para " + Schedule.ScheduleTime + " com ID " + Schedule.Id + "\r\n" +
                    "   - Exportação de Mailbox completa.");
                cmd = ExchangeUtils.ExportMailbox(Schedule.Id, Schedule.Mailbox, "*", "*", Schedule.Target);

            }
            else
            {
                mainLogger.WriteEntry("Executando agendamento de " + Schedule.Mailbox + " para " + Schedule.Target + " programado para " + Schedule.ScheduleTime + " com ID " + Schedule.Id + "\r\n" +
                    "   - Exportação de Mailbox de (" + DateTime.Today.AddDays(-Schedule.LastDays).ToShortDateString() + ") até (" + DateTime.Today.ToShortDateString() + ")");
                cmd = ExchangeUtils.ExportMailbox(Schedule.Id, Schedule.Mailbox, DateTime.Today.AddDays(-Schedule.LastDays).ToShortDateString(), DateTime.Today.ToShortDateString(), Schedule.Target);
            }

            PSBGWorker exportWorker = new PSBGWorker(ServerUser, Utils.DecryptPassword(EncServerPass), ServerIP, cmd, 0);
            exportWorker.Completed += CmdCompleted;
            exportWorker.InitTask();
        }
    }
}
