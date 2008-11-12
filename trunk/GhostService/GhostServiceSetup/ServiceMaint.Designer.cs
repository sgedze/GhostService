namespace GhostService
{
    partial class ServiceMaint
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
            this.scGS = new System.ServiceProcess.ServiceController();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.sfdTraceFile = new System.Windows.Forms.SaveFileDialog();
            this.sfwTraceFile = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tpPluginOptions = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblServiceStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbStartStop = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.gbTrace = new System.Windows.Forms.GroupBox();
            this.btnStopTrace = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.edtTraceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lvWork = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lvThreads = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tpAppEvents = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnEventsRefresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbCachedCreds = new System.Windows.Forms.CheckBox();
            this.cbSetProxy = new System.Windows.Forms.CheckBox();
            this.gbProxyUser = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbProxyDomain = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbProxyPass = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbProxyUser = new System.Windows.Forms.TextBox();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbProxyPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbProxyServer = new System.Windows.Forms.TextBox();
            this.cbDefault = new System.Windows.Forms.CheckBox();
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.tbSMTPTest = new System.Windows.Forms.Button();
            this.cbUseMAPI = new System.Windows.Forms.CheckBox();
            this.gbEmailOptions = new System.Windows.Forms.GroupBox();
            this.cbSecureConn = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbDefaultAddress = new System.Windows.Forms.TextBox();
            this.gbSMTP = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbSMTPServer = new System.Windows.Forms.TextBox();
            this.gbSMTPUser = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbSMTPPassword = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbSMTPUser = new System.Windows.Forms.TextBox();
            this.elGhostService = new System.Diagnostics.EventLog();
            this.dataSet1 = new System.Data.DataSet();
            this.dataSet2 = new System.Data.DataSet();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sfwTraceFile)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpPluginOptions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbTrace.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tpAppEvents.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbProxyUser.SuspendLayout();
            this.gbManual.SuspendLayout();
            this.tpEmail.SuspendLayout();
            this.gbEmailOptions.SuspendLayout();
            this.gbSMTP.SuspendLayout();
            this.gbSMTPUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elGhostService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 500;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // sfdTraceFile
            // 
            this.sfdTraceFile.Filter = "Text Files|*.txt";
            // 
            // sfwTraceFile
            // 
            this.sfwTraceFile.EnableRaisingEvents = true;
            this.sfwTraceFile.SynchronizingObject = this;
            this.sfwTraceFile.Changed += new System.IO.FileSystemEventHandler(this.sfwTraceFile_Changed);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tpPluginOptions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 478);
            this.panel1.TabIndex = 0;
            // 
            // tpPluginOptions
            // 
            this.tpPluginOptions.Controls.Add(this.tabPage3);
            this.tpPluginOptions.Controls.Add(this.tabPage1);
            this.tpPluginOptions.Controls.Add(this.tpAppEvents);
            this.tpPluginOptions.Controls.Add(this.tabPage2);
            this.tpPluginOptions.Controls.Add(this.tpEmail);
            this.tpPluginOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpPluginOptions.Location = new System.Drawing.Point(0, 0);
            this.tpPluginOptions.Name = "tpPluginOptions";
            this.tpPluginOptions.SelectedIndex = 0;
            this.tpPluginOptions.Size = new System.Drawing.Size(615, 478);
            this.tpPluginOptions.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.gbTrace);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(607, 452);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Service";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.lblServiceStatus);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(38, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 135);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings Reset";
            this.groupBox3.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(19, 96);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Restore plugin defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lblServiceStatus
            // 
            this.lblServiceStatus.AutoSize = true;
            this.lblServiceStatus.Location = new System.Drawing.Point(16, 71);
            this.lblServiceStatus.Name = "lblServiceStatus";
            this.lblServiceStatus.Size = new System.Drawing.Size(37, 13);
            this.lblServiceStatus.TabIndex = 3;
            this.lblServiceStatus.Text = "Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(415, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "setting files have been corrupted. The service should not be running when this is" +
                " used.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(423, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "This will reset and rebuild the settings files for all plugins. Make use of this " +
                "when the XML";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudDelay);
            this.groupBox2.Location = new System.Drawing.Point(38, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 93);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "minutes before processing starts.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "restart your computer.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Use this to delay processing of the service at startup. Helpful for when you ";
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(19, 59);
            this.nudDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(43, 20);
            this.nudDelay.TabIndex = 0;
            this.nudDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDelay.Leave += new System.EventHandler(this.nudDelay_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbStartStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lblServiceName);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnRestart);
            this.groupBox1.Location = new System.Drawing.Point(38, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Status";
            // 
            // pbStartStop
            // 
            this.pbStartStop.Location = new System.Drawing.Point(19, 48);
            this.pbStartStop.Name = "pbStartStop";
            this.pbStartStop.Size = new System.Drawing.Size(258, 23);
            this.pbStartStop.TabIndex = 4;
            this.pbStartStop.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(110, 81);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(16, 26);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(71, 13);
            this.lblServiceName.TabIndex = 3;
            this.lblServiceName.Text = "ServiceName";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(19, 81);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(202, 81);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // gbTrace
            // 
            this.gbTrace.Controls.Add(this.btnStopTrace);
            this.gbTrace.Controls.Add(this.btnBrowse);
            this.gbTrace.Controls.Add(this.edtTraceFile);
            this.gbTrace.Controls.Add(this.label1);
            this.gbTrace.Location = new System.Drawing.Point(38, 136);
            this.gbTrace.Name = "gbTrace";
            this.gbTrace.Size = new System.Drawing.Size(457, 61);
            this.gbTrace.TabIndex = 5;
            this.gbTrace.TabStop = false;
            this.gbTrace.Text = "Trace Options";
            // 
            // btnStopTrace
            // 
            this.btnStopTrace.Location = new System.Drawing.Point(365, 20);
            this.btnStopTrace.Name = "btnStopTrace";
            this.btnStopTrace.Size = new System.Drawing.Size(75, 23);
            this.btnStopTrace.TabIndex = 3;
            this.btnStopTrace.Text = "Stop Trace";
            this.btnStopTrace.UseVisualStyleBackColor = true;
            this.btnStopTrace.Click += new System.EventHandler(this.btnStopTrace_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(300, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // edtTraceFile
            // 
            this.edtTraceFile.Location = new System.Drawing.Point(91, 22);
            this.edtTraceFile.Name = "edtTraceFile";
            this.edtTraceFile.ReadOnly = true;
            this.edtTraceFile.Size = new System.Drawing.Size(203, 20);
            this.edtTraceFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output file:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trace";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 396);
            this.panel3.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(601, 396);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lvWork);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(601, 165);
            this.panel5.TabIndex = 2;
            // 
            // lvWork
            // 
            this.lvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWork.Location = new System.Drawing.Point(0, 0);
            this.lvWork.Name = "lvWork";
            this.lvWork.Size = new System.Drawing.Size(601, 165);
            this.lvWork.TabIndex = 1;
            this.lvWork.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 20);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Work list (\"scheduled\" items)";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lvThreads);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(601, 187);
            this.panel6.TabIndex = 3;
            // 
            // lvThreads
            // 
            this.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvThreads.Location = new System.Drawing.Point(0, 0);
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(601, 187);
            this.lvThreads.TabIndex = 2;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(601, 20);
            this.panel4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Thread list (items busy running)";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbMin);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.tbTime);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(601, 50);
            this.panel7.TabIndex = 11;
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(374, 20);
            this.tbMin.Name = "tbMin";
            this.tbMin.ReadOnly = true;
            this.tbMin.Size = new System.Drawing.Size(100, 20);
            this.tbMin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Min of week";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time of log";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(83, 20);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(135, 20);
            this.tbTime.TabIndex = 7;
            // 
            // tpAppEvents
            // 
            this.tpAppEvents.Controls.Add(this.panel11);
            this.tpAppEvents.Controls.Add(this.panel10);
            this.tpAppEvents.Location = new System.Drawing.Point(4, 22);
            this.tpAppEvents.Name = "tpAppEvents";
            this.tpAppEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tpAppEvents.Size = new System.Drawing.Size(607, 452);
            this.tpAppEvents.TabIndex = 4;
            this.tpAppEvents.Text = "Application Events";
            this.tpAppEvents.UseVisualStyleBackColor = true;
            this.tpAppEvents.Enter += new System.EventHandler(this.tpAppEvents_Enter);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lvEvents);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(601, 413);
            this.panel11.TabIndex = 1;
            // 
            // lvEvents
            // 
            this.lvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEvents.Location = new System.Drawing.Point(0, 0);
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(601, 413);
            this.lvEvents.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvEvents.TabIndex = 0;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnEventsRefresh);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(3, 416);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(601, 33);
            this.panel10.TabIndex = 0;
            // 
            // btnEventsRefresh
            // 
            this.btnEventsRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventsRefresh.Location = new System.Drawing.Point(523, 6);
            this.btnEventsRefresh.Name = "btnEventsRefresh";
            this.btnEventsRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnEventsRefresh.TabIndex = 1;
            this.btnEventsRefresh.Text = "Refresh";
            this.btnEventsRefresh.UseVisualStyleBackColor = true;
            this.btnEventsRefresh.Click += new System.EventHandler(this.btnEventsRefresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbCachedCreds);
            this.tabPage2.Controls.Add(this.cbSetProxy);
            this.tabPage2.Controls.Add(this.gbProxyUser);
            this.tabPage2.Controls.Add(this.gbManual);
            this.tabPage2.Controls.Add(this.cbDefault);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 452);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "Proxy Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbCachedCreds
            // 
            this.cbCachedCreds.AutoSize = true;
            this.cbCachedCreds.Location = new System.Drawing.Point(36, 186);
            this.cbCachedCreds.Name = "cbCachedCreds";
            this.cbCachedCreds.Size = new System.Drawing.Size(323, 17);
            this.cbCachedCreds.TabIndex = 6;
            this.cbCachedCreds.Text = "Use cached credentials (might require changes to service user)";
            this.cbCachedCreds.UseVisualStyleBackColor = true;
            this.cbCachedCreds.Click += new System.EventHandler(this.cbDefault_Click);
            // 
            // cbSetProxy
            // 
            this.cbSetProxy.AutoSize = true;
            this.cbSetProxy.Location = new System.Drawing.Point(36, 29);
            this.cbSetProxy.Name = "cbSetProxy";
            this.cbSetProxy.Size = new System.Drawing.Size(70, 17);
            this.cbSetProxy.TabIndex = 5;
            this.cbSetProxy.Text = "Set proxy";
            this.cbSetProxy.UseVisualStyleBackColor = true;
            this.cbSetProxy.Click += new System.EventHandler(this.cbDefault_Click);
            // 
            // gbProxyUser
            // 
            this.gbProxyUser.Controls.Add(this.label15);
            this.gbProxyUser.Controls.Add(this.tbProxyDomain);
            this.gbProxyUser.Controls.Add(this.label14);
            this.gbProxyUser.Controls.Add(this.tbProxyPass);
            this.gbProxyUser.Controls.Add(this.label13);
            this.gbProxyUser.Controls.Add(this.tbProxyUser);
            this.gbProxyUser.Location = new System.Drawing.Point(36, 209);
            this.gbProxyUser.Name = "gbProxyUser";
            this.gbProxyUser.Size = new System.Drawing.Size(457, 136);
            this.gbProxyUser.TabIndex = 4;
            this.gbProxyUser.TabStop = false;
            this.gbProxyUser.Text = "Proxy User Details";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Domain:";
            // 
            // tbProxyDomain
            // 
            this.tbProxyDomain.Location = new System.Drawing.Point(123, 97);
            this.tbProxyDomain.Name = "tbProxyDomain";
            this.tbProxyDomain.Size = new System.Drawing.Size(137, 20);
            this.tbProxyDomain.TabIndex = 14;
            this.tbProxyDomain.Leave += new System.EventHandler(this.tbProxyServer_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Password:";
            // 
            // tbProxyPass
            // 
            this.tbProxyPass.Location = new System.Drawing.Point(123, 60);
            this.tbProxyPass.Name = "tbProxyPass";
            this.tbProxyPass.Size = new System.Drawing.Size(137, 20);
            this.tbProxyPass.TabIndex = 12;
            this.tbProxyPass.UseSystemPasswordChar = true;
            this.tbProxyPass.Leave += new System.EventHandler(this.tbProxyServer_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Username:";
            // 
            // tbProxyUser
            // 
            this.tbProxyUser.Location = new System.Drawing.Point(123, 24);
            this.tbProxyUser.Name = "tbProxyUser";
            this.tbProxyUser.Size = new System.Drawing.Size(137, 20);
            this.tbProxyUser.TabIndex = 10;
            this.tbProxyUser.Leave += new System.EventHandler(this.tbProxyServer_TextChanged);
            // 
            // gbManual
            // 
            this.gbManual.Controls.Add(this.label12);
            this.gbManual.Controls.Add(this.tbProxyPort);
            this.gbManual.Controls.Add(this.label9);
            this.gbManual.Controls.Add(this.tbProxyServer);
            this.gbManual.Location = new System.Drawing.Point(36, 100);
            this.gbManual.Name = "gbManual";
            this.gbManual.Size = new System.Drawing.Size(457, 69);
            this.gbManual.TabIndex = 3;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "Proxy Server";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(309, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Port:";
            // 
            // tbProxyPort
            // 
            this.tbProxyPort.Location = new System.Drawing.Point(344, 26);
            this.tbProxyPort.Name = "tbProxyPort";
            this.tbProxyPort.Size = new System.Drawing.Size(56, 20);
            this.tbProxyPort.TabIndex = 2;
            this.tbProxyPort.Leave += new System.EventHandler(this.tbProxyServer_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Proxy Server:";
            // 
            // tbProxyServer
            // 
            this.tbProxyServer.AcceptsReturn = true;
            this.tbProxyServer.Location = new System.Drawing.Point(124, 26);
            this.tbProxyServer.Name = "tbProxyServer";
            this.tbProxyServer.Size = new System.Drawing.Size(172, 20);
            this.tbProxyServer.TabIndex = 0;
            this.tbProxyServer.Leave += new System.EventHandler(this.tbProxyServer_TextChanged);
            // 
            // cbDefault
            // 
            this.cbDefault.AutoSize = true;
            this.cbDefault.Location = new System.Drawing.Point(36, 61);
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.Size = new System.Drawing.Size(284, 17);
            this.cbDefault.TabIndex = 2;
            this.cbDefault.Text = "Use default settings (GhostService will settings from IE)";
            this.cbDefault.UseVisualStyleBackColor = true;
            this.cbDefault.Click += new System.EventHandler(this.cbDefault_Click);
            // 
            // tpEmail
            // 
            this.tpEmail.Controls.Add(this.tbSMTPTest);
            this.tpEmail.Controls.Add(this.cbUseMAPI);
            this.tpEmail.Controls.Add(this.gbEmailOptions);
            this.tpEmail.Controls.Add(this.gbSMTP);
            this.tpEmail.Controls.Add(this.gbSMTPUser);
            this.tpEmail.Location = new System.Drawing.Point(4, 22);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(607, 452);
            this.tpEmail.TabIndex = 6;
            this.tpEmail.Text = "Email Settings";
            this.tpEmail.UseVisualStyleBackColor = true;
            // 
            // tbSMTPTest
            // 
            this.tbSMTPTest.Location = new System.Drawing.Point(392, 29);
            this.tbSMTPTest.Name = "tbSMTPTest";
            this.tbSMTPTest.Size = new System.Drawing.Size(101, 22);
            this.tbSMTPTest.TabIndex = 2;
            this.tbSMTPTest.Text = "Send Test Email";
            this.tbSMTPTest.UseVisualStyleBackColor = true;
            this.tbSMTPTest.Click += new System.EventHandler(this.tbSMTPTest_Click);
            // 
            // cbUseMAPI
            // 
            this.cbUseMAPI.AutoSize = true;
            this.cbUseMAPI.Location = new System.Drawing.Point(36, 29);
            this.cbUseMAPI.Name = "cbUseMAPI";
            this.cbUseMAPI.Size = new System.Drawing.Size(259, 17);
            this.cbUseMAPI.TabIndex = 1;
            this.cbUseMAPI.Text = "Use MAPI (might require changes to service user)";
            this.cbUseMAPI.UseVisualStyleBackColor = true;
            this.cbUseMAPI.Click += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // gbEmailOptions
            // 
            this.gbEmailOptions.Controls.Add(this.label16);
            this.gbEmailOptions.Controls.Add(this.cbSecureConn);
            this.gbEmailOptions.Controls.Add(this.label19);
            this.gbEmailOptions.Controls.Add(this.tbDefaultAddress);
            this.gbEmailOptions.Location = new System.Drawing.Point(36, 62);
            this.gbEmailOptions.Name = "gbEmailOptions";
            this.gbEmailOptions.Size = new System.Drawing.Size(457, 95);
            this.gbEmailOptions.TabIndex = 3;
            this.gbEmailOptions.TabStop = false;
            this.gbEmailOptions.Text = "Email Options";
            // 
            // cbSecureConn
            // 
            this.cbSecureConn.AutoSize = true;
            this.cbSecureConn.Location = new System.Drawing.Point(15, 59);
            this.cbSecureConn.Name = "cbSecureConn";
            this.cbSecureConn.Size = new System.Drawing.Size(119, 17);
            this.cbSecureConn.TabIndex = 5;
            this.cbSecureConn.Text = "Secure connection.";
            this.cbSecureConn.UseVisualStyleBackColor = true;
            this.cbSecureConn.Click += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Default from address:";
            // 
            // tbDefaultAddress
            // 
            this.tbDefaultAddress.Location = new System.Drawing.Point(123, 24);
            this.tbDefaultAddress.Name = "tbDefaultAddress";
            this.tbDefaultAddress.Size = new System.Drawing.Size(217, 20);
            this.tbDefaultAddress.TabIndex = 4;
            this.tbDefaultAddress.Leave += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // gbSMTP
            // 
            this.gbSMTP.Controls.Add(this.label20);
            this.gbSMTP.Controls.Add(this.tbSMTPServer);
            this.gbSMTP.Location = new System.Drawing.Point(36, 173);
            this.gbSMTP.Name = "gbSMTP";
            this.gbSMTP.Size = new System.Drawing.Size(457, 69);
            this.gbSMTP.TabIndex = 6;
            this.gbSMTP.TabStop = false;
            this.gbSMTP.Text = "SMTP Server";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "SMTP Server:";
            // 
            // tbSMTPServer
            // 
            this.tbSMTPServer.AcceptsReturn = true;
            this.tbSMTPServer.Location = new System.Drawing.Point(124, 26);
            this.tbSMTPServer.Name = "tbSMTPServer";
            this.tbSMTPServer.Size = new System.Drawing.Size(216, 20);
            this.tbSMTPServer.TabIndex = 7;
            this.tbSMTPServer.Leave += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // gbSMTPUser
            // 
            this.gbSMTPUser.Controls.Add(this.label17);
            this.gbSMTPUser.Controls.Add(this.tbSMTPPassword);
            this.gbSMTPUser.Controls.Add(this.label18);
            this.gbSMTPUser.Controls.Add(this.tbSMTPUser);
            this.gbSMTPUser.Location = new System.Drawing.Point(36, 264);
            this.gbSMTPUser.Name = "gbSMTPUser";
            this.gbSMTPUser.Size = new System.Drawing.Size(457, 99);
            this.gbSMTPUser.TabIndex = 8;
            this.gbSMTPUser.TabStop = false;
            this.gbSMTPUser.Text = "SMTP User Details";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Password:";
            // 
            // tbSMTPPassword
            // 
            this.tbSMTPPassword.Location = new System.Drawing.Point(123, 60);
            this.tbSMTPPassword.Name = "tbSMTPPassword";
            this.tbSMTPPassword.Size = new System.Drawing.Size(137, 20);
            this.tbSMTPPassword.TabIndex = 10;
            this.tbSMTPPassword.UseSystemPasswordChar = true;
            this.tbSMTPPassword.Leave += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Username:";
            // 
            // tbSMTPUser
            // 
            this.tbSMTPUser.Location = new System.Drawing.Point(123, 24);
            this.tbSMTPUser.Name = "tbSMTPUser";
            this.tbSMTPUser.Size = new System.Drawing.Size(137, 20);
            this.tbSMTPUser.TabIndex = 9;
            this.tbSMTPUser.Leave += new System.EventHandler(this.cbSMTPDefault_Click);
            // 
            // elGhostService
            // 
            this.elGhostService.Log = "Application";
            this.elGhostService.SynchronizingObject = this;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "NewDataSet";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(121, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "(Also To address for test.)";
            // 
            // ServiceMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ServiceMaint";
            this.Size = new System.Drawing.Size(615, 478);
            this.Load += new System.EventHandler(this.ServiceMaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfwTraceFile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tpPluginOptions.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbTrace.ResumeLayout(false);
            this.gbTrace.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tpAppEvents.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbProxyUser.ResumeLayout(false);
            this.gbProxyUser.PerformLayout();
            this.gbManual.ResumeLayout(false);
            this.gbManual.PerformLayout();
            this.tpEmail.ResumeLayout(false);
            this.tpEmail.PerformLayout();
            this.gbEmailOptions.ResumeLayout(false);
            this.gbEmailOptions.PerformLayout();
            this.gbSMTP.ResumeLayout(false);
            this.gbSMTP.PerformLayout();
            this.gbSMTPUser.ResumeLayout(false);
            this.gbSMTPUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elGhostService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ServiceProcess.ServiceController scGS;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.SaveFileDialog sfdTraceFile;
        private System.IO.FileSystemWatcher sfwTraceFile;
        private System.Windows.Forms.Panel panel1;
        private System.Diagnostics.EventLog elGhostService;
        private System.Windows.Forms.TabControl tpPluginOptions;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pbStartStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.GroupBox gbTrace;
        private System.Windows.Forms.Button btnStopTrace;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox edtTraceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TabPage tpAppEvents;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnEventsRefresh;
        private System.Data.DataSet dataSet1;
        private System.Data.DataSet dataSet2;
        private System.Windows.Forms.ListView lvWork;
        private System.Windows.Forms.ListView lvThreads;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.CheckBox cbDefault;
        private System.Windows.Forms.TextBox tbProxyServer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbProxyPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbProxyUser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbProxyDomain;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbProxyPass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbProxyUser;
        private System.Windows.Forms.CheckBox cbSetProxy;
        private System.Windows.Forms.CheckBox cbCachedCreds;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.GroupBox gbSMTP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbSMTPServer;
        private System.Windows.Forms.GroupBox gbSMTPUser;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbSMTPPassword;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbSMTPUser;
        private System.Windows.Forms.GroupBox gbEmailOptions;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbDefaultAddress;
        private System.Windows.Forms.CheckBox cbSecureConn;
        private System.Windows.Forms.CheckBox cbUseMAPI;
        private System.Windows.Forms.Button tbSMTPTest;
        private System.Windows.Forms.Label label16;
    }
}