namespace GhostService
{
    partial class GhostServiceSetupF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GhostServiceSetupF));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.ghostConveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ghostServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installedPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ghostConveyToolStripMenuItem,
            this.ghostServiceToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msMain.Size = new System.Drawing.Size(526, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip2";
            // 
            // ghostConveyToolStripMenuItem
            // 
            this.ghostConveyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureDatabasesToolStripMenuItem});
            this.ghostConveyToolStripMenuItem.Name = "ghostConveyToolStripMenuItem";
            this.ghostConveyToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ghostConveyToolStripMenuItem.Text = "GhostConvey";
            // 
            // configureDatabasesToolStripMenuItem
            // 
            this.configureDatabasesToolStripMenuItem.Name = "configureDatabasesToolStripMenuItem";
            this.configureDatabasesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.configureDatabasesToolStripMenuItem.Text = "Configure Databases";
            // 
            // ghostServiceToolStripMenuItem
            // 
            this.ghostServiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceManagementToolStripMenuItem,
            this.installedPluginsToolStripMenuItem});
            this.ghostServiceToolStripMenuItem.Name = "ghostServiceToolStripMenuItem";
            this.ghostServiceToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.ghostServiceToolStripMenuItem.Text = "GhostService";
            // 
            // serviceManagementToolStripMenuItem
            // 
            this.serviceManagementToolStripMenuItem.Name = "serviceManagementToolStripMenuItem";
            this.serviceManagementToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.serviceManagementToolStripMenuItem.Text = "Service Management";
            // 
            // installedPluginsToolStripMenuItem
            // 
            this.installedPluginsToolStripMenuItem.Name = "installedPluginsToolStripMenuItem";
            this.installedPluginsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.installedPluginsToolStripMenuItem.Text = "Installed Plugins";
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(526, 402);
            this.pnlMain.TabIndex = 5;
            // 
            // GhostServiceSetupF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 448);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GhostServiceSetupF";
            this.Text = "GhostService Plugin Setup";
            this.Load += new System.EventHandler(this.GhostServiceSetup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GhostServiceSetup_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem ghostConveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ghostServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installedPluginsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
    }
}

