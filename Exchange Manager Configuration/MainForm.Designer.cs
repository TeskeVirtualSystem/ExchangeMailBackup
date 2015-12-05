namespace Exchange_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contentManager = new System.Windows.Forms.TabControl();
            this.initialConfig = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.serviceStatus = new System.Windows.Forms.Label();
            this.stopServiceButton = new System.Windows.Forms.Button();
            this.startServiceButton = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.serviceNumSchedules = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serviceDirectoryLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveServerConfig = new System.Windows.Forms.Button();
            this.serverPassTextBox = new System.Windows.Forms.TextBox();
            this.serverUserTextBox = new System.Windows.Forms.TextBox();
            this.serverIPtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backupConfig = new System.Windows.Forms.TabPage();
            this.scheduleBox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.searchRemoteFolderInConfig = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.createSchedule = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lastDaysTextBox = new System.Windows.Forms.TextBox();
            this.lastDaysRadio = new System.Windows.Forms.RadioButton();
            this.lastWeekRadio = new System.Windows.Forms.RadioButton();
            this.lastMonth = new System.Windows.Forms.RadioButton();
            this.fullBackupRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.whenMonth = new System.Windows.Forms.TextBox();
            this.whenDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.whenDayOfMonth = new System.Windows.Forms.TextBox();
            this.whenMinute = new System.Windows.Forms.TextBox();
            this.whenHour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startCreateSchedule = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mailboxList = new System.Windows.Forms.ListBox();
            this.scheduleManager = new System.Windows.Forms.TabPage();
            this.managerBox = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.searchRemoteFolderInManager = new System.Windows.Forms.Button();
            this.directoryTextBoxManager = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lastDaysTextBoxManager = new System.Windows.Forms.TextBox();
            this.lastDaysRadioManager = new System.Windows.Forms.RadioButton();
            this.lastWeekRadioManager = new System.Windows.Forms.RadioButton();
            this.lastMonthManager = new System.Windows.Forms.RadioButton();
            this.fullBackupRadioManager = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.whenMonthManager = new System.Windows.Forms.TextBox();
            this.whenDayOfWeekManager = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.whenDayOfMonthManager = new System.Windows.Forms.TextBox();
            this.whenMinuteManager = new System.Windows.Forms.TextBox();
            this.whenHourManager = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.scheduleList = new System.Windows.Forms.ListBox();
            this.currentRequests = new System.Windows.Forms.TabPage();
            this.cleanCurrentRequests = new System.Windows.Forms.Button();
            this.requestsView = new System.Windows.Forms.DataGridView();
            this.findDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.requestUpdate = new System.Windows.Forms.Timer(this.components);
            this.serviceStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.cleanFailedRequests = new System.Windows.Forms.Button();
            this.contentManager.SuspendLayout();
            this.initialConfig.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.backupConfig.SuspendLayout();
            this.scheduleBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.scheduleManager.SuspendLayout();
            this.managerBox.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.currentRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsView)).BeginInit();
            this.SuspendLayout();
            // 
            // contentManager
            // 
            this.contentManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentManager.Controls.Add(this.initialConfig);
            this.contentManager.Controls.Add(this.backupConfig);
            this.contentManager.Controls.Add(this.scheduleManager);
            this.contentManager.Controls.Add(this.currentRequests);
            this.contentManager.Location = new System.Drawing.Point(12, 1);
            this.contentManager.Name = "contentManager";
            this.contentManager.SelectedIndex = 0;
            this.contentManager.Size = new System.Drawing.Size(951, 401);
            this.contentManager.TabIndex = 0;
            // 
            // initialConfig
            // 
            this.initialConfig.Controls.Add(this.groupBox6);
            this.initialConfig.Controls.Add(this.connectButton);
            this.initialConfig.Controls.Add(this.groupBox2);
            this.initialConfig.Controls.Add(this.groupBox1);
            this.initialConfig.Location = new System.Drawing.Point(4, 22);
            this.initialConfig.Name = "initialConfig";
            this.initialConfig.Padding = new System.Windows.Forms.Padding(3);
            this.initialConfig.Size = new System.Drawing.Size(943, 375);
            this.initialConfig.TabIndex = 0;
            this.initialConfig.Text = "Configuração Inicial";
            this.initialConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.serviceStatus);
            this.groupBox6.Controls.Add(this.stopServiceButton);
            this.groupBox6.Controls.Add(this.startServiceButton);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Location = new System.Drawing.Point(6, 136);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 124);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Serviço";
            // 
            // serviceStatus
            // 
            this.serviceStatus.AutoSize = true;
            this.serviceStatus.Location = new System.Drawing.Point(55, 19);
            this.serviceStatus.Name = "serviceStatus";
            this.serviceStatus.Size = new System.Drawing.Size(41, 13);
            this.serviceStatus.TabIndex = 6;
            this.serviceStatus.Text = "Parado";
            // 
            // stopServiceButton
            // 
            this.stopServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopServiceButton.Location = new System.Drawing.Point(9, 83);
            this.stopServiceButton.Name = "stopServiceButton";
            this.stopServiceButton.Size = new System.Drawing.Size(255, 30);
            this.stopServiceButton.TabIndex = 5;
            this.stopServiceButton.Text = "Parar Serviço";
            this.stopServiceButton.UseVisualStyleBackColor = true;
            this.stopServiceButton.Click += new System.EventHandler(this.stopServiceButton_Click);
            // 
            // startServiceButton
            // 
            this.startServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServiceButton.Location = new System.Drawing.Point(9, 47);
            this.startServiceButton.Name = "startServiceButton";
            this.startServiceButton.Size = new System.Drawing.Size(255, 30);
            this.startServiceButton.TabIndex = 4;
            this.startServiceButton.Text = "Iniciar Serviço";
            this.startServiceButton.UseVisualStyleBackColor = true;
            this.startServiceButton.Click += new System.EventHandler(this.startServiceButton_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Estado:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(6, 346);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(931, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Conectar e Baixar Lista de Usuários";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.serviceNumSchedules);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.serviceDirectoryLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(282, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serviço";
            // 
            // serviceNumSchedules
            // 
            this.serviceNumSchedules.AutoSize = true;
            this.serviceNumSchedules.Location = new System.Drawing.Point(148, 45);
            this.serviceNumSchedules.Name = "serviceNumSchedules";
            this.serviceNumSchedules.Size = new System.Drawing.Size(80, 13);
            this.serviceNumSchedules.TabIndex = 3;
            this.serviceNumSchedules.Text = "{SCHEDULES}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Número de Agendamentos:";
            // 
            // serviceDirectoryLabel
            // 
            this.serviceDirectoryLabel.AutoSize = true;
            this.serviceDirectoryLabel.Location = new System.Drawing.Point(88, 19);
            this.serviceDirectoryLabel.Name = "serviceDirectoryLabel";
            this.serviceDirectoryLabel.Size = new System.Drawing.Size(34, 13);
            this.serviceDirectoryLabel.TabIndex = 1;
            this.serviceDirectoryLabel.Text = "{DIR}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Diretório Atual:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveServerConfig);
            this.groupBox1.Controls.Add(this.serverPassTextBox);
            this.groupBox1.Controls.Add(this.serverUserTextBox);
            this.groupBox1.Controls.Add(this.serverIPtextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servidor Exchange";
            // 
            // saveServerConfig
            // 
            this.saveServerConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveServerConfig.Location = new System.Drawing.Point(9, 94);
            this.saveServerConfig.Name = "saveServerConfig";
            this.saveServerConfig.Size = new System.Drawing.Size(255, 23);
            this.saveServerConfig.TabIndex = 6;
            this.saveServerConfig.Text = "Salvar Configurações";
            this.saveServerConfig.UseVisualStyleBackColor = true;
            this.saveServerConfig.Click += new System.EventHandler(this.saveServerConfig_Click);
            // 
            // serverPassTextBox
            // 
            this.serverPassTextBox.Location = new System.Drawing.Point(82, 68);
            this.serverPassTextBox.Name = "serverPassTextBox";
            this.serverPassTextBox.PasswordChar = '*';
            this.serverPassTextBox.Size = new System.Drawing.Size(182, 20);
            this.serverPassTextBox.TabIndex = 5;
            // 
            // serverUserTextBox
            // 
            this.serverUserTextBox.Location = new System.Drawing.Point(82, 42);
            this.serverUserTextBox.Name = "serverUserTextBox";
            this.serverUserTextBox.Size = new System.Drawing.Size(182, 20);
            this.serverUserTextBox.TabIndex = 4;
            // 
            // serverIPtextBox
            // 
            this.serverIPtextBox.Location = new System.Drawing.Point(82, 16);
            this.serverIPtextBox.Name = "serverIPtextBox";
            this.serverIPtextBox.Size = new System.Drawing.Size(182, 20);
            this.serverIPtextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // backupConfig
            // 
            this.backupConfig.Controls.Add(this.scheduleBox);
            this.backupConfig.Controls.Add(this.startCreateSchedule);
            this.backupConfig.Controls.Add(this.label6);
            this.backupConfig.Controls.Add(this.mailboxList);
            this.backupConfig.Location = new System.Drawing.Point(4, 22);
            this.backupConfig.Name = "backupConfig";
            this.backupConfig.Padding = new System.Windows.Forms.Padding(3);
            this.backupConfig.Size = new System.Drawing.Size(943, 375);
            this.backupConfig.TabIndex = 1;
            this.backupConfig.Text = "Configurar Backups";
            this.backupConfig.UseVisualStyleBackColor = true;
            // 
            // scheduleBox
            // 
            this.scheduleBox.Controls.Add(this.groupBox5);
            this.scheduleBox.Controls.Add(this.createSchedule);
            this.scheduleBox.Controls.Add(this.groupBox4);
            this.scheduleBox.Controls.Add(this.groupBox3);
            this.scheduleBox.Location = new System.Drawing.Point(219, 9);
            this.scheduleBox.Name = "scheduleBox";
            this.scheduleBox.Size = new System.Drawing.Size(718, 257);
            this.scheduleBox.TabIndex = 3;
            this.scheduleBox.TabStop = false;
            this.scheduleBox.Text = "Agendamento para: XXXX";
            this.scheduleBox.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.searchRemoteFolderInConfig);
            this.groupBox5.Controls.Add(this.directoryTextBox);
            this.groupBox5.Location = new System.Drawing.Point(346, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(366, 73);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Diretório Destino";
            // 
            // searchRemoteFolderInConfig
            // 
            this.searchRemoteFolderInConfig.Location = new System.Drawing.Point(6, 44);
            this.searchRemoteFolderInConfig.Name = "searchRemoteFolderInConfig";
            this.searchRemoteFolderInConfig.Size = new System.Drawing.Size(354, 23);
            this.searchRemoteFolderInConfig.TabIndex = 1;
            this.searchRemoteFolderInConfig.Text = "Procurar";
            this.searchRemoteFolderInConfig.UseVisualStyleBackColor = true;
            this.searchRemoteFolderInConfig.Click += new System.EventHandler(this.button1_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(6, 19);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(354, 20);
            this.directoryTextBox.TabIndex = 0;
            // 
            // createSchedule
            // 
            this.createSchedule.Location = new System.Drawing.Point(346, 106);
            this.createSchedule.Name = "createSchedule";
            this.createSchedule.Size = new System.Drawing.Size(366, 23);
            this.createSchedule.TabIndex = 2;
            this.createSchedule.Text = "Criar Agendamento";
            this.createSchedule.UseVisualStyleBackColor = true;
            this.createSchedule.Click += new System.EventHandler(this.createSchedule_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lastDaysTextBox);
            this.groupBox4.Controls.Add(this.lastDaysRadio);
            this.groupBox4.Controls.Add(this.lastWeekRadio);
            this.groupBox4.Controls.Add(this.lastMonth);
            this.groupBox4.Controls.Add(this.fullBackupRadio);
            this.groupBox4.Location = new System.Drawing.Point(6, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 145);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "O que fazer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "dias";
            // 
            // lastDaysTextBox
            // 
            this.lastDaysTextBox.Enabled = false;
            this.lastDaysTextBox.Location = new System.Drawing.Point(77, 90);
            this.lastDaysTextBox.Name = "lastDaysTextBox";
            this.lastDaysTextBox.Size = new System.Drawing.Size(41, 20);
            this.lastDaysTextBox.TabIndex = 4;
            this.lastDaysTextBox.Text = "15";
            this.lastDaysTextBox.Leave += new System.EventHandler(this.lastDaysTextBox_Leave);
            // 
            // lastDaysRadio
            // 
            this.lastDaysRadio.AutoSize = true;
            this.lastDaysRadio.Location = new System.Drawing.Point(9, 91);
            this.lastDaysRadio.Name = "lastDaysRadio";
            this.lastDaysRadio.Size = new System.Drawing.Size(62, 17);
            this.lastDaysRadio.TabIndex = 3;
            this.lastDaysRadio.Text = "Ultimos ";
            this.lastDaysRadio.UseVisualStyleBackColor = true;
            this.lastDaysRadio.CheckedChanged += new System.EventHandler(this.BackupRadio_CheckedChanged);
            // 
            // lastWeekRadio
            // 
            this.lastWeekRadio.AutoSize = true;
            this.lastWeekRadio.Location = new System.Drawing.Point(9, 67);
            this.lastWeekRadio.Name = "lastWeekRadio";
            this.lastWeekRadio.Size = new System.Drawing.Size(96, 17);
            this.lastWeekRadio.TabIndex = 2;
            this.lastWeekRadio.Text = "Ultima Semana";
            this.lastWeekRadio.UseVisualStyleBackColor = true;
            this.lastWeekRadio.CheckedChanged += new System.EventHandler(this.BackupRadio_CheckedChanged);
            // 
            // lastMonth
            // 
            this.lastMonth.AutoSize = true;
            this.lastMonth.Location = new System.Drawing.Point(9, 43);
            this.lastMonth.Name = "lastMonth";
            this.lastMonth.Size = new System.Drawing.Size(77, 17);
            this.lastMonth.TabIndex = 1;
            this.lastMonth.Text = "Ultimo Mês";
            this.lastMonth.UseVisualStyleBackColor = true;
            this.lastMonth.CheckedChanged += new System.EventHandler(this.BackupRadio_CheckedChanged);
            // 
            // fullBackupRadio
            // 
            this.fullBackupRadio.AutoSize = true;
            this.fullBackupRadio.Checked = true;
            this.fullBackupRadio.Location = new System.Drawing.Point(9, 20);
            this.fullBackupRadio.Name = "fullBackupRadio";
            this.fullBackupRadio.Size = new System.Drawing.Size(109, 17);
            this.fullBackupRadio.TabIndex = 0;
            this.fullBackupRadio.TabStop = true;
            this.fullBackupRadio.Text = "Backup Completo";
            this.fullBackupRadio.UseVisualStyleBackColor = true;
            this.fullBackupRadio.CheckedChanged += new System.EventHandler(this.BackupRadio_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.whenMonth);
            this.groupBox3.Controls.Add(this.whenDayOfWeek);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.whenDayOfMonth);
            this.groupBox3.Controls.Add(this.whenMinute);
            this.groupBox3.Controls.Add(this.whenHour);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 81);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quando executar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Use * para qualquer.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Mês";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Dia do Mês";
            // 
            // whenMonth
            // 
            this.whenMonth.Location = new System.Drawing.Point(295, 33);
            this.whenMonth.MaxLength = 2;
            this.whenMonth.Name = "whenMonth";
            this.whenMonth.Size = new System.Drawing.Size(27, 20);
            this.whenMonth.TabIndex = 17;
            this.whenMonth.Text = "*";
            this.whenMonth.TextChanged += new System.EventHandler(this.whenMonth_TextChanged);
            // 
            // whenDayOfWeek
            // 
            this.whenDayOfWeek.FormattingEnabled = true;
            this.whenDayOfWeek.Items.AddRange(new object[] {
            "Domingo",
            "Segunda",
            "Terça",
            "Quarta",
            "Quinta",
            "Sexta",
            "Sábado",
            "Qualquer"});
            this.whenDayOfWeek.Location = new System.Drawing.Point(87, 33);
            this.whenDayOfWeek.Name = "whenDayOfWeek";
            this.whenDayOfWeek.Size = new System.Drawing.Size(121, 21);
            this.whenDayOfWeek.TabIndex = 16;
            this.whenDayOfWeek.Text = "Qualquer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Dia da Semana";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Minuto";
            // 
            // whenDayOfMonth
            // 
            this.whenDayOfMonth.Location = new System.Drawing.Point(229, 33);
            this.whenDayOfMonth.MaxLength = 2;
            this.whenDayOfMonth.Name = "whenDayOfMonth";
            this.whenDayOfMonth.Size = new System.Drawing.Size(27, 20);
            this.whenDayOfMonth.TabIndex = 13;
            this.whenDayOfMonth.Text = "*";
            this.whenDayOfMonth.Leave += new System.EventHandler(this.whenDayOfMonth_Leave);
            // 
            // whenMinute
            // 
            this.whenMinute.Location = new System.Drawing.Point(42, 33);
            this.whenMinute.MaxLength = 2;
            this.whenMinute.Name = "whenMinute";
            this.whenMinute.Size = new System.Drawing.Size(27, 20);
            this.whenMinute.TabIndex = 12;
            this.whenMinute.Text = "*";
            this.whenMinute.Leave += new System.EventHandler(this.whenMinute_Leave);
            // 
            // whenHour
            // 
            this.whenHour.Location = new System.Drawing.Point(9, 33);
            this.whenHour.MaxLength = 2;
            this.whenHour.Name = "whenHour";
            this.whenHour.Size = new System.Drawing.Size(27, 20);
            this.whenHour.TabIndex = 11;
            this.whenHour.Text = "*";
            this.whenHour.Leave += new System.EventHandler(this.whenHour_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Hora";
            // 
            // startCreateSchedule
            // 
            this.startCreateSchedule.Location = new System.Drawing.Point(10, 243);
            this.startCreateSchedule.Name = "startCreateSchedule";
            this.startCreateSchedule.Size = new System.Drawing.Size(203, 23);
            this.startCreateSchedule.TabIndex = 2;
            this.startCreateSchedule.Text = "Criar Rotina";
            this.startCreateSchedule.UseVisualStyleBackColor = true;
            this.startCreateSchedule.Click += new System.EventHandler(this.startCreateSchedule_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Lista de Caixas de Correio";
            // 
            // mailboxList
            // 
            this.mailboxList.FormattingEnabled = true;
            this.mailboxList.Location = new System.Drawing.Point(10, 25);
            this.mailboxList.Name = "mailboxList";
            this.mailboxList.Size = new System.Drawing.Size(203, 212);
            this.mailboxList.TabIndex = 0;
            // 
            // scheduleManager
            // 
            this.scheduleManager.Controls.Add(this.managerBox);
            this.scheduleManager.Controls.Add(this.scheduleList);
            this.scheduleManager.Location = new System.Drawing.Point(4, 22);
            this.scheduleManager.Name = "scheduleManager";
            this.scheduleManager.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleManager.Size = new System.Drawing.Size(943, 375);
            this.scheduleManager.TabIndex = 2;
            this.scheduleManager.Text = "Gerenciador de Agendamentos";
            this.scheduleManager.UseVisualStyleBackColor = true;
            // 
            // managerBox
            // 
            this.managerBox.Controls.Add(this.groupBox7);
            this.managerBox.Controls.Add(this.groupBox8);
            this.managerBox.Controls.Add(this.groupBox9);
            this.managerBox.Controls.Add(this.button3);
            this.managerBox.Controls.Add(this.button2);
            this.managerBox.Location = new System.Drawing.Point(272, 6);
            this.managerBox.Name = "managerBox";
            this.managerBox.Size = new System.Drawing.Size(665, 264);
            this.managerBox.TabIndex = 1;
            this.managerBox.TabStop = false;
            this.managerBox.Text = "Agendamento";
            this.managerBox.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.searchRemoteFolderInManager);
            this.groupBox7.Controls.Add(this.directoryTextBoxManager);
            this.groupBox7.Location = new System.Drawing.Point(346, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(313, 81);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Diretório Destino";
            // 
            // searchRemoteFolderInManager
            // 
            this.searchRemoteFolderInManager.Location = new System.Drawing.Point(6, 47);
            this.searchRemoteFolderInManager.Name = "searchRemoteFolderInManager";
            this.searchRemoteFolderInManager.Size = new System.Drawing.Size(301, 23);
            this.searchRemoteFolderInManager.TabIndex = 1;
            this.searchRemoteFolderInManager.Text = "Procurar";
            this.searchRemoteFolderInManager.UseVisualStyleBackColor = true;
            this.searchRemoteFolderInManager.Click += new System.EventHandler(this.button4_Click);
            // 
            // directoryTextBoxManager
            // 
            this.directoryTextBoxManager.Location = new System.Drawing.Point(6, 19);
            this.directoryTextBoxManager.Name = "directoryTextBoxManager";
            this.directoryTextBoxManager.Size = new System.Drawing.Size(301, 20);
            this.directoryTextBoxManager.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.lastDaysTextBoxManager);
            this.groupBox8.Controls.Add(this.lastDaysRadioManager);
            this.groupBox8.Controls.Add(this.lastWeekRadioManager);
            this.groupBox8.Controls.Add(this.lastMonthManager);
            this.groupBox8.Controls.Add(this.fullBackupRadioManager);
            this.groupBox8.Location = new System.Drawing.Point(6, 106);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(334, 145);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "O que fazer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(124, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "dias";
            // 
            // lastDaysTextBoxManager
            // 
            this.lastDaysTextBoxManager.Enabled = false;
            this.lastDaysTextBoxManager.Location = new System.Drawing.Point(77, 90);
            this.lastDaysTextBoxManager.Name = "lastDaysTextBoxManager";
            this.lastDaysTextBoxManager.Size = new System.Drawing.Size(41, 20);
            this.lastDaysTextBoxManager.TabIndex = 4;
            this.lastDaysTextBoxManager.Text = "15";
            // 
            // lastDaysRadioManager
            // 
            this.lastDaysRadioManager.AutoSize = true;
            this.lastDaysRadioManager.Location = new System.Drawing.Point(9, 91);
            this.lastDaysRadioManager.Name = "lastDaysRadioManager";
            this.lastDaysRadioManager.Size = new System.Drawing.Size(62, 17);
            this.lastDaysRadioManager.TabIndex = 3;
            this.lastDaysRadioManager.Text = "Ultimos ";
            this.lastDaysRadioManager.UseVisualStyleBackColor = true;
            this.lastDaysRadioManager.CheckedChanged += new System.EventHandler(this.ManagerRadioCheckedChanged);
            // 
            // lastWeekRadioManager
            // 
            this.lastWeekRadioManager.AutoSize = true;
            this.lastWeekRadioManager.Location = new System.Drawing.Point(9, 67);
            this.lastWeekRadioManager.Name = "lastWeekRadioManager";
            this.lastWeekRadioManager.Size = new System.Drawing.Size(96, 17);
            this.lastWeekRadioManager.TabIndex = 2;
            this.lastWeekRadioManager.Text = "Ultima Semana";
            this.lastWeekRadioManager.UseVisualStyleBackColor = true;
            this.lastWeekRadioManager.CheckedChanged += new System.EventHandler(this.ManagerRadioCheckedChanged);
            // 
            // lastMonthManager
            // 
            this.lastMonthManager.AutoSize = true;
            this.lastMonthManager.Location = new System.Drawing.Point(9, 43);
            this.lastMonthManager.Name = "lastMonthManager";
            this.lastMonthManager.Size = new System.Drawing.Size(77, 17);
            this.lastMonthManager.TabIndex = 1;
            this.lastMonthManager.Text = "Ultimo Mês";
            this.lastMonthManager.UseVisualStyleBackColor = true;
            this.lastMonthManager.CheckedChanged += new System.EventHandler(this.ManagerRadioCheckedChanged);
            // 
            // fullBackupRadioManager
            // 
            this.fullBackupRadioManager.AutoSize = true;
            this.fullBackupRadioManager.Checked = true;
            this.fullBackupRadioManager.Location = new System.Drawing.Point(9, 20);
            this.fullBackupRadioManager.Name = "fullBackupRadioManager";
            this.fullBackupRadioManager.Size = new System.Drawing.Size(109, 17);
            this.fullBackupRadioManager.TabIndex = 0;
            this.fullBackupRadioManager.TabStop = true;
            this.fullBackupRadioManager.Text = "Backup Completo";
            this.fullBackupRadioManager.UseVisualStyleBackColor = true;
            this.fullBackupRadioManager.CheckedChanged += new System.EventHandler(this.ManagerRadioCheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.whenMonthManager);
            this.groupBox9.Controls.Add(this.whenDayOfWeekManager);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.whenDayOfMonthManager);
            this.groupBox9.Controls.Add(this.whenMinuteManager);
            this.groupBox9.Controls.Add(this.whenHourManager);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Location = new System.Drawing.Point(6, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(334, 81);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Quando executar";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Use * para qualquer.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(295, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Mês";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(214, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Dia do Mês";
            // 
            // whenMonthManager
            // 
            this.whenMonthManager.Location = new System.Drawing.Point(295, 33);
            this.whenMonthManager.MaxLength = 2;
            this.whenMonthManager.Name = "whenMonthManager";
            this.whenMonthManager.Size = new System.Drawing.Size(27, 20);
            this.whenMonthManager.TabIndex = 17;
            this.whenMonthManager.Text = "*";
            // 
            // whenDayOfWeekManager
            // 
            this.whenDayOfWeekManager.FormattingEnabled = true;
            this.whenDayOfWeekManager.Items.AddRange(new object[] {
            "Domingo",
            "Segunda",
            "Terça",
            "Quarta",
            "Quinta",
            "Sexta",
            "Sábado",
            "Qualquer"});
            this.whenDayOfWeekManager.Location = new System.Drawing.Point(87, 33);
            this.whenDayOfWeekManager.Name = "whenDayOfWeekManager";
            this.whenDayOfWeekManager.Size = new System.Drawing.Size(121, 21);
            this.whenDayOfWeekManager.TabIndex = 16;
            this.whenDayOfWeekManager.Text = "Qualquer";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(84, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "Dia da Semana";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Minuto";
            // 
            // whenDayOfMonthManager
            // 
            this.whenDayOfMonthManager.Location = new System.Drawing.Point(229, 33);
            this.whenDayOfMonthManager.MaxLength = 2;
            this.whenDayOfMonthManager.Name = "whenDayOfMonthManager";
            this.whenDayOfMonthManager.Size = new System.Drawing.Size(27, 20);
            this.whenDayOfMonthManager.TabIndex = 13;
            this.whenDayOfMonthManager.Text = "*";
            // 
            // whenMinuteManager
            // 
            this.whenMinuteManager.Location = new System.Drawing.Point(42, 33);
            this.whenMinuteManager.MaxLength = 2;
            this.whenMinuteManager.Name = "whenMinuteManager";
            this.whenMinuteManager.Size = new System.Drawing.Size(27, 20);
            this.whenMinuteManager.TabIndex = 12;
            this.whenMinuteManager.Text = "*";
            // 
            // whenHourManager
            // 
            this.whenHourManager.Location = new System.Drawing.Point(9, 33);
            this.whenHourManager.MaxLength = 2;
            this.whenHourManager.Name = "whenHourManager";
            this.whenHourManager.Size = new System.Drawing.Size(27, 20);
            this.whenHourManager.TabIndex = 11;
            this.whenHourManager.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Hora";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(533, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Apagar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // scheduleList
            // 
            this.scheduleList.FormattingEnabled = true;
            this.scheduleList.Location = new System.Drawing.Point(6, 6);
            this.scheduleList.Name = "scheduleList";
            this.scheduleList.Size = new System.Drawing.Size(260, 264);
            this.scheduleList.TabIndex = 0;
            this.scheduleList.Click += new System.EventHandler(this.scheduleList_SelectedIndexChanged);
            this.scheduleList.SelectedIndexChanged += new System.EventHandler(this.scheduleList_SelectedIndexChanged);
            // 
            // currentRequests
            // 
            this.currentRequests.Controls.Add(this.cleanFailedRequests);
            this.currentRequests.Controls.Add(this.cleanCurrentRequests);
            this.currentRequests.Controls.Add(this.requestsView);
            this.currentRequests.Location = new System.Drawing.Point(4, 22);
            this.currentRequests.Name = "currentRequests";
            this.currentRequests.Padding = new System.Windows.Forms.Padding(3);
            this.currentRequests.Size = new System.Drawing.Size(943, 375);
            this.currentRequests.TabIndex = 3;
            this.currentRequests.Text = "Backups Correntes";
            this.currentRequests.UseVisualStyleBackColor = true;
            // 
            // cleanCurrentRequests
            // 
            this.cleanCurrentRequests.Location = new System.Drawing.Point(6, 8);
            this.cleanCurrentRequests.Name = "cleanCurrentRequests";
            this.cleanCurrentRequests.Size = new System.Drawing.Size(108, 23);
            this.cleanCurrentRequests.TabIndex = 10;
            this.cleanCurrentRequests.Text = "Limpar";
            this.cleanCurrentRequests.UseVisualStyleBackColor = true;
            this.cleanCurrentRequests.Click += new System.EventHandler(this.cleanCurrentRequests_Click);
            // 
            // requestsView
            // 
            this.requestsView.AllowUserToAddRows = false;
            this.requestsView.AllowUserToDeleteRows = false;
            this.requestsView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.requestsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.requestsView.Location = new System.Drawing.Point(6, 37);
            this.requestsView.Name = "requestsView";
            this.requestsView.Size = new System.Drawing.Size(931, 335);
            this.requestsView.TabIndex = 9;
            // 
            // findDirectory
            // 
            this.findDirectory.HelpRequest += new System.EventHandler(this.findDirectory_HelpRequest);
            // 
            // requestUpdate
            // 
            this.requestUpdate.Interval = 800;
            this.requestUpdate.Tick += new System.EventHandler(this.requestUpdate_Tick);
            // 
            // serviceStatusUpdate
            // 
            this.serviceStatusUpdate.Enabled = true;
            this.serviceStatusUpdate.Interval = 1000;
            this.serviceStatusUpdate.Tick += new System.EventHandler(this.serviceStatusUpdate_Tick);
            // 
            // cleanFailedRequests
            // 
            this.cleanFailedRequests.Location = new System.Drawing.Point(120, 8);
            this.cleanFailedRequests.Name = "cleanFailedRequests";
            this.cleanFailedRequests.Size = new System.Drawing.Size(108, 23);
            this.cleanFailedRequests.TabIndex = 11;
            this.cleanFailedRequests.Text = "Limpar Falhas";
            this.cleanFailedRequests.UseVisualStyleBackColor = true;
            this.cleanFailedRequests.Click += new System.EventHandler(this.cleanFailedRequests_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 414);
            this.Controls.Add(this.contentManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Configurador do Exchange manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contentManager.ResumeLayout(false);
            this.initialConfig.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.backupConfig.ResumeLayout(false);
            this.backupConfig.PerformLayout();
            this.scheduleBox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.scheduleManager.ResumeLayout(false);
            this.managerBox.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.currentRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl contentManager;
        private System.Windows.Forms.TabPage initialConfig;
        private System.Windows.Forms.TabPage backupConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox serverPassTextBox;
        private System.Windows.Forms.TextBox serverUserTextBox;
        private System.Windows.Forms.TextBox serverIPtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveServerConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label serviceDirectoryLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label serviceNumSchedules;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox mailboxList;
        private System.Windows.Forms.Button startCreateSchedule;
        private System.Windows.Forms.GroupBox scheduleBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton fullBackupRadio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox whenMonth;
        private System.Windows.Forms.ComboBox whenDayOfWeek;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox whenDayOfMonth;
        private System.Windows.Forms.TextBox whenMinute;
        private System.Windows.Forms.TextBox whenHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox lastDaysTextBox;
        private System.Windows.Forms.RadioButton lastDaysRadio;
        private System.Windows.Forms.RadioButton lastWeekRadio;
        private System.Windows.Forms.RadioButton lastMonth;
        private System.Windows.Forms.Button createSchedule;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FolderBrowserDialog findDirectory;
        private System.Windows.Forms.Button searchRemoteFolderInConfig;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.TabPage scheduleManager;
        private System.Windows.Forms.ListBox scheduleList;
        private System.Windows.Forms.GroupBox managerBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button searchRemoteFolderInManager;
        private System.Windows.Forms.TextBox directoryTextBoxManager;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox lastDaysTextBoxManager;
        private System.Windows.Forms.RadioButton lastDaysRadioManager;
        private System.Windows.Forms.RadioButton lastWeekRadioManager;
        private System.Windows.Forms.RadioButton lastMonthManager;
        private System.Windows.Forms.RadioButton fullBackupRadioManager;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox whenMonthManager;
        private System.Windows.Forms.ComboBox whenDayOfWeekManager;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox whenDayOfMonthManager;
        private System.Windows.Forms.TextBox whenMinuteManager;
        private System.Windows.Forms.TextBox whenHourManager;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage currentRequests;
        private System.Windows.Forms.DataGridView requestsView;
        private System.Windows.Forms.Button cleanCurrentRequests;
        private System.Windows.Forms.Timer requestUpdate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label serviceStatus;
        private System.Windows.Forms.Button stopServiceButton;
        private System.Windows.Forms.Button startServiceButton;
        private System.Windows.Forms.Timer serviceStatusUpdate;
        private System.Windows.Forms.Button cleanFailedRequests;
    }
}

