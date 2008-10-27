using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GhostService.GhostServicePlugin;
using System.IO;
using System.Reflection;

namespace GhostService
{
    public partial class InstalledPlugins : BaseEventPanelPlugin
    {
        public InstalledPlugins()
        {
            InitializeComponent();
            this.Text = "Installed Plugins";
        }
        private void AddItem(Assembly assembly)
        {
            ListViewItem item = new ListViewItem();
            item.Text = Path.GetFileName(assembly.Location);
            item.SubItems.Add(assembly.ImageRuntimeVersion);
            item.SubItems.Add(Path.GetDirectoryName(assembly.Location));
            lvPlugins.Items.Add(item);
        }

        public void PopulateAssemblies(string filePath)
        {
            this.ClearItems();

            string[] pluginDLLs = Directory.GetFiles(filePath, Utilities.DLL_FILTER_NAME, SearchOption.AllDirectories);
            string[] pluginEXEs = Directory.GetFiles(filePath, Utilities.EXE_FILTER_NAME, SearchOption.AllDirectories);

            foreach (string dll in pluginDLLs)
            {
                Assembly asm = null;
                asm = Assembly.LoadFile(dll);
                if (asm != null)
                {
                    this.AddItem(asm);
                }
            }

            foreach (string exe in pluginEXEs)
            {
                Assembly asm = null;
                asm = Assembly.LoadFile(exe);
                if (asm != null)
                {
                    this.AddItem(asm);
                }
            }
        }

        private void ClearItems()
        {
            lvPlugins.Items.Clear();
        }

        public override void Activated(object sender, EventArgs e)
        { }
        public override void Deactivated(object sender, EventArgs e)
        { this.AsPanel.Visible = false; }
    }
}
