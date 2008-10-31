using System;
using System.Windows.Forms;
using System.ServiceProcess;
using GhostService.GhostServicePlugin;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Drawing;
using System.Net;

namespace GhostService
{
    public partial class ServiceMaint : BaseEventPanelPlugin
    {
        private PluginServerInformation _serverInformation;
        private bool _pickUpTraceFile = false;
        private bool _restartService = false;

        public ServiceMaint(PluginServerInformation psi)
        {
            InitializeComponent();
            this._serverInformation = psi;
            SetTraceFile(psi.TraceFileName);
            SetStartupDelay(psi.StartupDelay);
            SetUseDefaultProxySettings(psi.ProxySet, psi.UseDefaultProxySettings);
            SetProxySettings(psi.ProxyUserName, psi.ProxyPassword, psi.ProxyDomain, psi.ProxyServer, psi.ProxyPort);           
            elGhostService.Source = Utilities.SERVICE_NAME;
            this.Text = "Service Manager";
            SetupTraceView();
        }

        private void ResetProgressbar()
        {
            pbStartStop.Value = 0;
            pbStartStop.Minimum = 0;
            pbStartStop.Step = 2;
            pbStartStop.Maximum = 100;
        }

        private void ProgressbarStep()
        {
            if (pbStartStop.Value == pbStartStop.Maximum)
                ResetProgressbar();

            pbStartStop.PerformStep();
        }

        private void RefreshStatus()
        {
            scGS.Refresh();
            switch(scGS.Status)
            {
                case ServiceControllerStatus.Running:
                    {
                        ButtonStatus(false, true, true);
                        ResetProgressbar();
                        lblServiceName.Text = string.Format("{0} is running.", Utilities.SERVICE_NAME);
                        lblServiceStatus.Text = string.Format("Stop service ({0}), to use reset option.", Utilities.SERVICE_NAME);
                        break;
                    }
                case ServiceControllerStatus.Stopped:
                    {
                        ButtonStatus(true, false, false);
                        ResetProgressbar();
                        lblServiceName.Text = string.Format("{0} is not running.", Utilities.SERVICE_NAME);
                        lblServiceStatus.Text = string.Format("Service ({0}), not running.", Utilities.SERVICE_NAME);
                        break;
                    }
                case ServiceControllerStatus.StopPending:
                    {
                        ButtonStatus(false, false, false);
                        ProgressbarStep();
                        lblServiceName.Text = string.Format("{0} is busy stopping ...", Utilities.SERVICE_NAME);
                        lblServiceStatus.Text = string.Format("Stop service ({0}), to use reset option.", Utilities.SERVICE_NAME);
                        break;
                    }
                case ServiceControllerStatus.StartPending:
                    {
                        ButtonStatus(false, false, false);
                        ProgressbarStep();
                        lblServiceName.Text = string.Format("{0} is busy starting ...", Utilities.SERVICE_NAME);
                        lblServiceStatus.Text = string.Format("Stop service ({0}), to use reset option.", Utilities.SERVICE_NAME);
                        break;
                    }
                default:
                    {
                        ButtonStatus(true, true, true);
                        lblServiceName.Text = Utilities.SERVICE_NAME;
                        break;
                    }
            }
        }

        private void ButtonStatus(bool Start, bool Stop, bool Restart)
        {            
            btnStart.Enabled = Start;
            btnStop.Enabled = Stop;
            //maybe later
            //btnRestart.Enabled = Restart;
            pbStartStop.Visible = !Start && !Stop;

            btnReset.Enabled = Start;
        }

        private void SetTraceFile(string fileName)
        {
            edtTraceFile.Text = fileName;
            _serverInformation.TraceFileName = fileName;
            _serverInformation.SaveToSameXML();
            _pickUpTraceFile = !string.IsNullOrEmpty(fileName);
            if (_pickUpTraceFile)
            {
                try
                {
                    sfwTraceFile.Filter = Path.GetFileName(string.Concat(_serverInformation.TraceFileName, "trigger.xml"));
                    sfwTraceFile.Path = Path.GetDirectoryName(_serverInformation.TraceFileName);
                    sfwTraceFile.EnableRaisingEvents = _pickUpTraceFile;
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("Path might be invalid, please see following error: {0}",e.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                
            }
        }

        private void SetStartupDelay(string delay)
        {
            _restartService = !_serverInformation.StartupDelay.Equals(delay);

            try
            {
                nudDelay.Value = Convert.ToInt16(delay);
            }
            catch
            {
                nudDelay.Value = 3;
            }
            
            _serverInformation.StartupDelay = nudDelay.Value.ToString();
            _serverInformation.SaveToSameXML();
        }

        private void SetUseDefaultProxySettings(bool proxySet, bool useDefault)
        {
            _serverInformation.ProxySet = proxySet;
            cbSetProxy.Checked = proxySet;
            _serverInformation.UseDefaultProxySettings = (useDefault && proxySet);
            cbDefault.Checked = (useDefault && proxySet);
            _serverInformation.SaveToSameXML();
            cbDefault.Enabled = proxySet;
            gbManual.Enabled = (!(useDefault && proxySet));
            gbProxyUser.Enabled = (!(useDefault && proxySet));
        }

        private void ProxySettingsChanged()
        {
            SetProxySettings(tbProxyUser.Text,tbProxyPass.Text,tbProxyDomain.Text,tbProxyServer.Text,tbProxyPort.Text);
        }
        private void SetProxySettings(string user, string password, string domain, string proxyserver, string proxyport)
        {
            _serverInformation.ProxyUserName = user;
            _serverInformation.ProxyPassword = password;
            _serverInformation.ProxyDomain = domain;
            _serverInformation.ProxyServer = proxyserver;
            _serverInformation.ProxyPort = proxyport;

            tbProxyDomain.Text = domain;
            tbProxyPass.Text = password;
            tbProxyPort.Text = proxyport;
            tbProxyServer.Text = proxyserver;
            tbProxyUser.Text = user;
                        
            _serverInformation.SaveToSameXML();            
        }

        private void PromptRestartService()
        {
            MessageBox.Show("For these changes to take effect, the service needs to be restarted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void FillView(string filename)
        {
            XmlDocument doc = new XmlDocument();

            using (XmlReader xr = XmlReader.Create(filename))
                doc.Load(xr);

            foreach (XmlNode node in doc.ChildNodes)
            {
                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    if (innerNode.Name.Equals("DateLog"))
                        tbTime.Text = innerNode.InnerText;
                    else if (innerNode.Name.Equals("CurDateToMinOfWeek"))
                        tbMin.Text = innerNode.InnerText;
                    else if (innerNode.Name.Equals("WorkItems"))
                    {
                        lvWork.Items.Clear();
                        foreach (XmlNode workitem in innerNode.ChildNodes)
                        {
                            ListViewItem item = new ListViewItem();
                            foreach (XmlNode workitemcol in workitem.ChildNodes)
                            {
                                if (string.IsNullOrEmpty(item.Text))
                                    item.Text = workitemcol.InnerText;
                                else
                                    item.SubItems.Add(workitemcol.InnerText);
                            }
                            lvWork.Items.Add(item);
                        }
                    }
                    else if (innerNode.Name.Equals("Threads"))
                    {
                        lvThreads.Items.Clear();
                        foreach (XmlNode threaditem in innerNode.ChildNodes)
                        {
                            ListViewItem item = new ListViewItem();
                            foreach (XmlNode threaditemcol in threaditem.ChildNodes)
                            {
                                if (string.IsNullOrEmpty(item.Text))
                                    item.Text = threaditemcol.InnerText;
                                else
                                    item.SubItems.Add(threaditemcol.InnerText);

                                if (threaditemcol.Name.Equals("Thread_State"))
                                {
                                    switch (threaditemcol.InnerText)
                                    {
                                        case "Stopped":
                                            item.BackColor = Color.Crimson;
                                            item.ForeColor = Color.White;
                                            break;
                                        case "Running":
                                            item.BackColor = Color.DarkGreen;
                                            item.ForeColor = Color.White;
                                            break;
                                        default:
                                            item.BackColor = Color.White;
                                            item.ForeColor = Color.Black;
                                            break;
                                    }
                                }
                            }
                            lvThreads.Items.Add(item);
                        }
                    }
                }
            } /**/
        }
        
        private void SetupTraceView()
        {
            lvWork.Clear();
            lvWork.Columns.Add("Key", 50, HorizontalAlignment.Left);
            lvWork.Columns.Add("Key To Date", 150, HorizontalAlignment.Left);
            lvWork.Columns.Add("Interval", 50, HorizontalAlignment.Left);
            lvWork.Columns.Add("Calc From Base", 100, HorizontalAlignment.Left);
            lvWork.Columns.Add("Run Type", 100, HorizontalAlignment.Left);
            lvWork.Columns.Add("Assembly Type", 100, HorizontalAlignment.Left);
            lvWork.Columns.Add("Assembly Path", 200, HorizontalAlignment.Left);
            lvWork.View = View.Details;

            lvThreads.Clear();
            lvThreads.Columns.Add("Key", 100, HorizontalAlignment.Left);
            lvThreads.Columns.Add("Date Added", 150, HorizontalAlignment.Left);
            lvThreads.Columns.Add("Date Started", 150, HorizontalAlignment.Left);
            lvThreads.Columns.Add("Thread State", 100, HorizontalAlignment.Left);
            lvThreads.View = View.Details;
        }
        
        public override void Activated(object sender, EventArgs e)
        {
            RefreshTimer.Start();
            sfwTraceFile.EnableRaisingEvents = _pickUpTraceFile;
        }
        
        public override void Deactivated(object sender, EventArgs e)
        {
            RefreshTimer.Stop();
            sfwTraceFile.EnableRaisingEvents = false;
            if ((edtTraceFile.Text.Length > 0))
                MessageBox.Show("Please note leaving GhostService in trace mode will effect its speed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (_restartService)
            {
                PromptRestartService();
                _restartService = false;
            }

            this.AsPanel.Visible = false;
        }

        private void ReadEventLogAndDisplay()
        {
            lvEvents.Clear();
            lvEvents.Columns.Add("Date Time", 100,HorizontalAlignment.Left);
            lvEvents.Columns.Add("Event Type", 100,HorizontalAlignment.Left);
            lvEvents.Columns.Add("Event Message", 100,HorizontalAlignment.Left);
            lvEvents.View = View.Details;

            EventLog log = new EventLog("Application",".");

            EventLogEntryCollection logEntryCol = log.Entries;

            foreach(EventLogEntry entry in logEntryCol)
            {
                if(entry.Source.IndexOf(Utilities.SERVICE_NAME) != -1)
                {
                    ListViewItem item = lvEvents.Items.Add(entry.TimeGenerated.ToString());

                        switch(entry.EntryType.ToString())
                        {
                            case "Error" :
                                    item.BackColor = Color.Crimson;
                                    item.ForeColor = Color.White;
                                    break;
                            case "Warning" :
                                    item.BackColor = Color.Yellow;
                                    item.ForeColor = Color.Black;
                                    break;
                            default :
                                    item.BackColor = Color.White;
                                    item.ForeColor = Color.Black;
                                    break;
                        }

                    item.SubItems.Add(entry.EntryType.ToString());
                    item.SubItems.Add(entry.Message);

                }
            }

            foreach(ColumnHeader col in lvEvents.Columns)
            {
                    col.Width = -2;
            }
        }
                
        #region events
        private void btnStopTrace_Click(object sender, EventArgs e)
        {
            SetTraceFile("");
            PromptRestartService();
        }
        private void ServiceMaint_Load(object sender, EventArgs e)
        {
            scGS.ServiceName = Utilities.SERVICE_NAME;
            Activated(sender, e);
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (sfdTraceFile.ShowDialog() == DialogResult.OK)
            {
                SetTraceFile(sfdTraceFile.FileName);
                PromptRestartService();
            }
        }
        private void sfwTraceFile_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            //reload last section
            string filename = string.Concat(_serverInformation.TraceFileName, ".xml");
            if (File.Exists(filename))
            {
                FillView(filename);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            scGS.Stop();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            scGS.Start();
            _restartService = false;
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
        }
        private void nudDelay_Leave(object sender, EventArgs e)
        {
            SetStartupDelay(nudDelay.Value.ToString());
        }
        private void cbDefault_Click(object sender, EventArgs e)
        {
            SetUseDefaultProxySettings(cbSetProxy.Checked, cbDefault.Checked);
            PromptRestartService();
        }
        private void tbProxyServer_TextChanged(object sender, EventArgs e)
        {
            ProxySettingsChanged();
        }
        private void tpAppEvents_Enter(object sender, EventArgs e)
        {
            if (lvEvents.Items.Count < 1)
                ReadEventLogAndDisplay();
        }
        private void btnEventsRefresh_Click(object sender, EventArgs e)
        {
            ReadEventLogAndDisplay();
        }
        #endregion 
    }
}
