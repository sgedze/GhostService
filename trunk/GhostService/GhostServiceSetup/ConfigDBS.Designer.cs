namespace GhostService
{
    partial class ConfigDBS
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveDB = new System.Windows.Forms.Button();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.lbDBs = new System.Windows.Forms.ListBox();
            this.ofdDatabases = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRun = new System.Windows.Forms.Button();
            this.edtQuery = new System.Windows.Forms.TextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database list";
            // 
            // btnRemoveDB
            // 
            this.btnRemoveDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDB.Location = new System.Drawing.Point(387, 156);
            this.btnRemoveDB.Name = "btnRemoveDB";
            this.btnRemoveDB.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDB.TabIndex = 6;
            this.btnRemoveDB.Text = "Remove";
            this.btnRemoveDB.UseVisualStyleBackColor = true;
            this.btnRemoveDB.Click += new System.EventHandler(this.btnRemoveDB_Click);
            // 
            // btnAddDB
            // 
            this.btnAddDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDB.Location = new System.Drawing.Point(306, 156);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(75, 23);
            this.btnAddDB.TabIndex = 5;
            this.btnAddDB.Text = "Add";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // lbDBs
            // 
            this.lbDBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDBs.FormattingEnabled = true;
            this.lbDBs.Location = new System.Drawing.Point(19, 44);
            this.lbDBs.Name = "lbDBs";
            this.lbDBs.Size = new System.Drawing.Size(443, 95);
            this.lbDBs.TabIndex = 4;
            // 
            // ofdDatabases
            // 
            this.ofdDatabases.Filter = "MS Access Databases|*.mdb|Database Connection Files|*.cfg";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbDBs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddDB);
            this.panel1.Controls.Add(this.btnRemoveDB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 186);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 186);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRun);
            this.splitContainer1.Panel1.Controls.Add(this.edtQuery);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvResult);
            this.splitContainer1.Size = new System.Drawing.Size(505, 215);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 9;
            this.splitContainer1.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(387, 61);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // edtQuery
            // 
            this.edtQuery.AcceptsReturn = true;
            this.edtQuery.AcceptsTab = true;
            this.edtQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtQuery.Location = new System.Drawing.Point(0, 0);
            this.edtQuery.Multiline = true;
            this.edtQuery.Name = "edtQuery";
            this.edtQuery.Size = new System.Drawing.Size(505, 59);
            this.edtQuery.TabIndex = 0;
            this.edtQuery.Text = "select * from sys_divisions";
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(505, 125);
            this.dgvResult.TabIndex = 0;
            // 
            // ConfigDBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "ConfigDBS";
            this.Size = new System.Drawing.Size(505, 401);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveDB;
        private System.Windows.Forms.Button btnAddDB;
        private System.Windows.Forms.ListBox lbDBs;
        public System.Windows.Forms.OpenFileDialog ofdDatabases;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox edtQuery;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnRun;
    }
}