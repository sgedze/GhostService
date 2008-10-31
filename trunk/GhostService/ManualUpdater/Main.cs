using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Korbitec.AutoUpdate.ClientUpdates;
using System.Net;

namespace ManualUpdater
{
    public partial class MainUpdater : Form
    {
        protected ClientUpdater _clientUpdater;  
        
        public MainUpdater()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Status("Creating connection");
                _clientUpdater = new ClientUpdater(tbProduct.Text, tbURL.Text);
                _clientUpdater.Proxy = WebRequest.DefaultWebProxy;

                Status("Checking for update");
                if (_clientUpdater.UpdateAvailable())
                {
                    Status("Downloading update");
                    _clientUpdater.DownloadLatestUpdate();

                    Status("Update downloaded");
                    if (_clientUpdater.UpdateDownloaded())
                    {
                        Status("Applying update");
                        _clientUpdater.ApplyUpdate(null);
                        Status("Update applied");
                    }
                }
                else
                {
                    Status("There is no update available");
                }
            }
            catch (Exception ex)
            {
                Status("Error occured");
                MessageBox.Show("Error occured, " + ex.ToString());
            }
        }

        private void Status(string text)
        {
            slStatus.Text = text;
            ssStatus.Refresh();
        }
    }
}
