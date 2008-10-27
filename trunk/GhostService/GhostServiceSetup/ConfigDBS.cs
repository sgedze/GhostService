using System;
using System.Windows.Forms;
using GhostService.GhostServicePlugin;

namespace GhostService
{
    public partial class ConfigDBS : BaseEventPanelPlugin
    {
        //keep a reference so changes can register
        private PluginServerInformation _serverInformation;

        public ConfigDBS()
        {
            InitializeComponent();

            this.Text = "Databases";
        }

        public void LoadDbs(ref PluginServerInformation psi)
        {
            if (psi == null)
                return;

            _serverInformation = psi;
            
            foreach (Db d in psi.DBs)
                lbDBs.Items.Add(d.ConfigFilePath);
        }

        private void AddDB()
        {
            if (ofdDatabases.ShowDialog() == DialogResult.OK)
            {
                lbDBs.Items.Add(ofdDatabases.FileName);
                _serverInformation.DBs.Add(new Db(ofdDatabases.FileName));
            }
        }

        private void RemoveSelectedBD()
        {
            if (lbDBs.SelectedIndex > -1)
            {
                _serverInformation.RemoveDB(lbDBs.SelectedItem.ToString());
                lbDBs.Items.Remove(lbDBs.SelectedItem);                
            }
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            AddDB();
        }

        private void btnRemoveDB_Click(object sender, EventArgs e)
        {
            RemoveSelectedBD();
        }
        
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (lbDBs.SelectedItem != null)
            {
                //GhostConveyServerInstall db = new GhostConveyServerInstall(lbDBs.SelectedItem.ToString());
                //db.WriteNotificationMsgToUserList(Utilities.UPDATE_NOTIFICATION_MSG);
                                
            }
        }

        public override void Activated(object sender, EventArgs e)
        {}
        public override void Deactivated(object sender, EventArgs e)
        {
            this.AsPanel.Visible = false;
        }
    }
}
