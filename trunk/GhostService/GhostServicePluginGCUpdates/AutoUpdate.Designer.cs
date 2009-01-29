namespace GhostServicePluginGCUpdates
{
    partial class GCUpdateVPlugin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.btnCheckNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDBs = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbStepbyStep = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEmailNotify = new System.Windows.Forms.CheckBox();
            this.tbEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGCNotify = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.gbDloadPath = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.bnBrowse = new System.Windows.Forms.Button();
            this.tbDownloadPath = new System.Windows.Forms.TextBox();
            this.cbCopy = new System.Windows.Forms.CheckBox();
            this.cbApply = new System.Windows.Forms.CheckBox();
            this.cbDLoad = new System.Windows.Forms.CheckBox();
            this.ofdDatabases = new System.Windows.Forms.OpenFileDialog();
            this.cbCopyFile = new System.Windows.Forms.CheckBox();
            this.gbDownloadPath = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbNoDLoad = new System.Windows.Forms.CheckBox();
            this.cbNoApply = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbDloadPath.SuspendLayout();
            this.gbDownloadPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(440, 377);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblStatus1);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.pbDownload);
            this.tabPage1.Controls.Add(this.btnCheckNow);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbDBs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(432, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GhostConvey Database(s)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatus1.Location = new System.Drawing.Point(19, 199);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(51, 13);
            this.lblStatus1.TabIndex = 12;
            this.lblStatus1.Text = "Nothing";
            this.lblStatus1.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatus.Location = new System.Drawing.Point(19, 186);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Nothing";
            this.lblStatus.Visible = false;
            // 
            // pbDownload
            // 
            this.pbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownload.Location = new System.Drawing.Point(22, 236);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(377, 23);
            this.pbDownload.TabIndex = 10;
            // 
            // btnCheckNow
            // 
            this.btnCheckNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckNow.Location = new System.Drawing.Point(233, 286);
            this.btnCheckNow.Name = "btnCheckNow";
            this.btnCheckNow.Size = new System.Drawing.Size(166, 23);
            this.btnCheckNow.TabIndex = 9;
            this.btnCheckNow.Text = "Check for updates now ...";
            this.btnCheckNow.UseVisualStyleBackColor = true;
            this.btnCheckNow.Click += new System.EventHandler(this.btnCheckNow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Database list";
            // 
            // lbDBs
            // 
            this.lbDBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDBs.FormattingEnabled = true;
            this.lbDBs.Location = new System.Drawing.Point(22, 37);
            this.lbDBs.Name = "lbDBs";
            this.lbDBs.Size = new System.Drawing.Size(385, 95);
            this.lbDBs.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(432, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notify Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbStepbyStep);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbEmailNotify);
            this.groupBox2.Controls.Add(this.tbEmailAddress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(27, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 170);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notification via Email";
            // 
            // cbStepbyStep
            // 
            this.cbStepbyStep.AutoSize = true;
            this.cbStepbyStep.Location = new System.Drawing.Point(31, 140);
            this.cbStepbyStep.Name = "cbStepbyStep";
            this.cbStepbyStep.Size = new System.Drawing.Size(190, 17);
            this.cbStepbyStep.TabIndex = 7;
            this.cbStepbyStep.Text = "Include step by step status reports.";
            this.cbStepbyStep.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Service Management.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(335, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "This option will try and notify you via the email settings supplied under ";
            // 
            // cbEmailNotify
            // 
            this.cbEmailNotify.AutoSize = true;
            this.cbEmailNotify.Location = new System.Drawing.Point(16, 19);
            this.cbEmailNotify.Name = "cbEmailNotify";
            this.cbEmailNotify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEmailNotify.Size = new System.Drawing.Size(59, 17);
            this.cbEmailNotify.TabIndex = 1;
            this.cbEmailNotify.Text = "Enable";
            this.cbEmailNotify.UseVisualStyleBackColor = true;
            this.cbEmailNotify.Click += new System.EventHandler(this.cbEmailNotify_Click);
            // 
            // tbEmailAddress
            // 
            this.tbEmailAddress.Location = new System.Drawing.Point(31, 106);
            this.tbEmailAddress.Name = "tbEmailAddress";
            this.tbEmailAddress.Size = new System.Drawing.Size(324, 20);
            this.tbEmailAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Notify email address (separated by \';\')";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbGCNotify);
            this.groupBox1.Location = new System.Drawing.Point(27, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification via GhostConvey";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "or more users the privilege in GhostConvey\'s setup.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "when they log on to GhostConvey. To complete this selection grant one";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "This option will make use of GhostConvey to send a message to user(s)";
            // 
            // cbGCNotify
            // 
            this.cbGCNotify.AutoSize = true;
            this.cbGCNotify.Location = new System.Drawing.Point(16, 19);
            this.cbGCNotify.Name = "cbGCNotify";
            this.cbGCNotify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGCNotify.Size = new System.Drawing.Size(59, 17);
            this.cbGCNotify.TabIndex = 0;
            this.cbGCNotify.Text = "Enable";
            this.cbGCNotify.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.gbDloadPath);
            this.tabPage3.Controls.Add(this.cbApply);
            this.tabPage3.Controls.Add(this.cbDLoad);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(432, 351);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Settings";
            this.tabPage3.UseVisualStyleBackColor = true;            
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(23, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(207, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Notify me of new updates (mandatory).";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // gbDloadPath
            // 
            this.gbDloadPath.Controls.Add(this.label16);
            this.gbDloadPath.Controls.Add(this.bnBrowse);
            this.gbDloadPath.Controls.Add(this.tbDownloadPath);
            this.gbDloadPath.Controls.Add(this.cbCopy);
            this.gbDloadPath.Location = new System.Drawing.Point(23, 100);
            this.gbDloadPath.Name = "gbDloadPath";
            this.gbDloadPath.Size = new System.Drawing.Size(377, 121);
            this.gbDloadPath.TabIndex = 7;
            this.gbDloadPath.TabStop = false;
            this.gbDloadPath.Text = "Download options";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(156, 12);
            this.label16.TabIndex = 13;
            this.label16.Text = "Do NOT make use of mapped drives.";
            // 
            // bnBrowse
            // 
            this.bnBrowse.Location = new System.Drawing.Point(303, 60);
            this.bnBrowse.Name = "bnBrowse";
            this.bnBrowse.Size = new System.Drawing.Size(25, 23);
            this.bnBrowse.TabIndex = 7;
            this.bnBrowse.Text = "...";
            this.bnBrowse.UseVisualStyleBackColor = true;
            this.bnBrowse.Click += new System.EventHandler(this.bnBrowse_Click);
            // 
            // tbDownloadPath
            // 
            this.tbDownloadPath.Location = new System.Drawing.Point(21, 62);
            this.tbDownloadPath.Name = "tbDownloadPath";
            this.tbDownloadPath.Size = new System.Drawing.Size(276, 20);
            this.tbDownloadPath.TabIndex = 6;
            // 
            // cbCopy
            // 
            this.cbCopy.AutoSize = true;
            this.cbCopy.Location = new System.Drawing.Point(21, 28);
            this.cbCopy.Name = "cbCopy";
            this.cbCopy.Size = new System.Drawing.Size(189, 17);
            this.cbCopy.TabIndex = 5;
            this.cbCopy.Text = "Make a copy of downloaded file ...";
            this.cbCopy.UseVisualStyleBackColor = true;
            this.cbCopy.CheckedChanged += new System.EventHandler(this.cbCopy_CheckedChanged);
            // 
            // cbApply
            // 
            this.cbApply.AutoSize = true;
            this.cbApply.Location = new System.Drawing.Point(23, 70);
            this.cbApply.Name = "cbApply";
            this.cbApply.Size = new System.Drawing.Size(221, 17);
            this.cbApply.TabIndex = 4;
            this.cbApply.Text = "Automatically apply downloaded updates.";
            this.cbApply.UseVisualStyleBackColor = true;
            // 
            // cbDLoad
            // 
            this.cbDLoad.AutoSize = true;
            this.cbDLoad.Location = new System.Drawing.Point(23, 47);
            this.cbDLoad.Name = "cbDLoad";
            this.cbDLoad.Size = new System.Drawing.Size(181, 17);
            this.cbDLoad.TabIndex = 2;
            this.cbDLoad.Text = "Automatically download updates.";
            this.cbDLoad.UseVisualStyleBackColor = true;
            this.cbDLoad.Click += new System.EventHandler(this.cbNoDLoad_Click);
            // 
            // ofdDatabases
            // 
            this.ofdDatabases.Filter = "MS Access Databases|*.mdb|Database Connection Files|*.cfg";
            this.ofdDatabases.FilterIndex = 2;
            // 
            // cbCopyFile
            // 
            this.cbCopyFile.AutoSize = true;
            this.cbCopyFile.Location = new System.Drawing.Point(31, 29);
            this.cbCopyFile.Name = "cbCopyFile";
            this.cbCopyFile.Size = new System.Drawing.Size(267, 17);
            this.cbCopyFile.TabIndex = 6;
            this.cbCopyFile.Text = "Don\'t apply the update automatically, just notify me.";
            this.cbCopyFile.UseVisualStyleBackColor = true;
            // 
            // gbDownloadPath
            // 
            this.gbDownloadPath.Controls.Add(this.cbCopyFile);
            this.gbDownloadPath.Location = new System.Drawing.Point(25, 81);
            this.gbDownloadPath.Name = "gbDownloadPath";
            this.gbDownloadPath.Size = new System.Drawing.Size(360, 100);
            this.gbDownloadPath.TabIndex = 7;
            this.gbDownloadPath.TabStop = false;
            this.gbDownloadPath.Text = "groupBox3";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(189, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Make a copy of downloaded file ...";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(276, 20);
            this.textBox2.TabIndex = 6;
            // 
            // cbNoDLoad
            // 
            this.cbNoDLoad.AutoSize = true;
            this.cbNoDLoad.Location = new System.Drawing.Point(23, 47);
            this.cbNoDLoad.Name = "cbNoDLoad";
            this.cbNoDLoad.Size = new System.Drawing.Size(184, 17);
            this.cbNoDLoad.TabIndex = 2;
            this.cbNoDLoad.Text = "Automatically download  updates.";
            this.cbNoDLoad.UseVisualStyleBackColor = true;
            this.cbNoDLoad.Click += new System.EventHandler(this.cbNoDLoad_Click);
            // 
            // cbNoApply
            // 
            this.cbNoApply.AutoSize = true;
            this.cbNoApply.Location = new System.Drawing.Point(23, 70);
            this.cbNoApply.Name = "cbNoApply";
            this.cbNoApply.Size = new System.Drawing.Size(221, 17);
            this.cbNoApply.TabIndex = 4;
            this.cbNoApply.Text = "Automatically apply downloaded updates.";
            this.cbNoApply.UseVisualStyleBackColor = true;
            // 
            // GCUpdateVPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GCUpdateVPlugin";
            this.Size = new System.Drawing.Size(440, 377);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gbDloadPath.ResumeLayout(false);
            this.gbDloadPath.PerformLayout();
            this.gbDownloadPath.ResumeLayout(false);
            this.gbDownloadPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbDLoad;
        private System.Windows.Forms.TextBox tbEmailAddress;
        private System.Windows.Forms.CheckBox cbEmailNotify;
        private System.Windows.Forms.CheckBox cbGCNotify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDBs;
        private System.Windows.Forms.CheckBox cbApply;
        private System.Windows.Forms.CheckBox cbCopyFile;
        private System.Windows.Forms.GroupBox gbDloadPath;
        private System.Windows.Forms.GroupBox gbDownloadPath;
        private System.Windows.Forms.CheckBox cbCopy;
        private System.Windows.Forms.Button bnBrowse;
        private System.Windows.Forms.TextBox tbDownloadPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Button btnCheckNow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbStepbyStep;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox cbNoDLoad;
        private System.Windows.Forms.CheckBox cbNoApply;

    }
}

