using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GhostService.GhostServicePlugin;
using Korbitec.AutoUpdate.ClientUpdates;
using System.IO;
using System.Net;

namespace GhostServicePluginGCUpdates
{
    public partial class GCUpdateVPlugin : EventAutoUpdatePluginBase, IVisualPlugin
    {
        #region To save to XML (defaults)
        private const string KEY = "GhostConvey";
        private const string MENU_PATH1 = "GhostConvey";
        private const string MENU_PATH2 = "Auto Updates";
        private const string PLUGIN_NAME = "GhostConvey Auto Updates";
        private const ushort INTERVAL = 1400;
        private const bool DOWNLOAD_UPDATE = true;
        private const bool APPLY_DOWNLOADED_UPDATE = true;
        private const bool CALCULATE_INTERVAL_FROM_BASE = true;
        private const bool PLUGIN_ACTIVE = true;
        private const string AUTO_UPDATE_SERVER = @"http://autoupdate.korbitec.com/AutoUpdateServer/Service.svc";
        private string OLD_AUTO_UPDATE_SERVER = @"http://sqltestpc.korbitec.int/AutoUpdateServer/Service.svc";
        private const bool MAKE_COPY_OF_FILE = false;
        private const string MAKE_COPY_PATH = "";
        private const bool NOTIFICATION_ACTIVE = true;
        private const PluginRunType RUNTYPE = PluginRunType.PerInterval;

        #endregion                                  
        
        protected ClientNotifier _clientNotifier;
        protected Version _productVersion;
        private GhostConveyServerInstall _ghostConveyServerInstall;

        #region Properties
        private bool NotificationActive
        {
            get { return _settings["NotificationActive"].Equals("True",StringComparison.CurrentCultureIgnoreCase); }
        }
        public string DownloadPath
        {
            get { return _settings["MakeCopyPath"]; }
            set { _settings["MakeCopyPath"] = value; }
        }
        protected string AutoUpdateServer
        {
            get
            {
                return _settings["AutoUpdateServer"];
            }
        }
        public string[] MenuPath
        {
            get
            {
                return new String[2] { _settings["MenuPath1"], _settings["MenuPath2"] };
            }
        }

        #endregion

        #region Constructors 
        public GCUpdateVPlugin()
        {
            InitializeComponent();

            //read config file or create one
            LoadOrBuildConfigFile(this.Name);
        }
        #endregion

        #region events
        public void Activated(object sender, EventArgs e)
        {
            Activating(sender, e);
            windowedInstance = true;
            FillDBBox(_serverInformation.DBs);
        }
        public void Deactivated(object sender, EventArgs e)
        {
            Deactivating(sender, e);
        }
        public void ClientUpdaterEvents(ClientNotifier cur)
        {
            cur.DownloadComplete += updater_DownloadComplete;
            cur.DownloadFailed += updater_DownloadFailed;
            cur.DownloadSize += updater_DownloadSize;
            cur.DownloadProgress += updater_DownloadProgress;
            cur.UpdateComplete += updater_UpdateComplete;
        }
        private void btnCheckNow_Click(object sender, EventArgs e)
        {
            /*string amsg = "";
            ClientNotifier __cli = new ClientNotifier(this.Key, new Version("10.3.4.15"), this.AutoUpdateServer);
            bool abool = __cli.UpdateAvailable();
            abool = CheckAndProcessAppDesc(new GhostConveyServerInstall(lbDBs.SelectedItem.ToString()), __cli, ref amsg);
            
            (new ApplicationUpdateDescription()).CreateSampleFile(@"c:\temp\test.xml");
            return;*/

            //the button was pushed so it is visual
            windowedInstance = true;

            Init();

            //save ui changes to settings
            HandleSettings(false);
            //save settings to xml
            _settings.SaveToSameXML();

            Start();
        }
        private void bnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tbDownloadPath.Text = folderBrowserDialog1.SelectedPath;
        }
        private void cbNoDLoad_Click(object sender, EventArgs e)
        {
            gbDloadPath.Enabled = !cbNoDLoad.Checked;
            cbCopy.Checked = gbDloadPath.Enabled ? cbCopy.Checked : false;
        }
                
        #endregion 

        #region Work (utils)
        protected string[] AllZipFiles(string path)
        { 
            return Directory.GetFiles(path, Utilities.ZIP_FILTER_NAME);            
        }
        protected void MakeCopyOfDownload(ClientNotifier clientNotifier, string downloadpath)
        {
            if (!clientNotifier.UpdateDownloaded())
                return;

            if (string.IsNullOrEmpty(downloadpath))
                return;
            
            try
            {
                string fullPath = string.Concat(downloadpath, "\\", clientNotifier.ProductFamily, "\\", clientNotifier.ProductVersion, "\\");
                Directory.CreateDirectory(fullPath);

                foreach (string zip in AllZipFiles(clientNotifier.UpdateFilePath))
                    File.Copy(zip, Path.Combine(fullPath, Path.GetFileName(zip)), true);
                
                return;
            }
            catch (Exception e)
            { LogErrorToEventLog(e, "MakeCopyOfDownload"); }
        }
        private void FillDBBox(List<Db> dbs)
        {
            lbDBs.Items.Clear();
            foreach (Db db in dbs)
            {
                //if (db.IsSQLModule)
                //    lbDBs.Items.Add(db.ServerName + " - " + db.DbName);
                //else
                lbDBs.Items.Add(db.ConfigFilePath);
            }
        }
        protected void DoAnyNotificationWork(GhostConveyServerInstall ghostConveyServerInstall, string customUserMessage)
        {
            try
            {
                if (NotificationActive)
                    ghostConveyServerInstall.WriteNotificationMsgToUserList(customUserMessage);
            }
            catch (Exception e)
            { LogErrorToEventLog(e, "DoAnyNotificationWork"); }
        }
        public void CheckForUpdatesNow(bool downLoadUpdate, bool applyDownloadedUpdate, GhostConveyServerInstall ghostConveyServerInstall, ClientNotifier clientNotifier)
        {            
            string dbName = ghostConveyServerInstall.DbName;
            string customUserMessage = "";
            bool updateApplicable = clientNotifier.UpdateAvailable();
            ApplicationUpdateDescription _applicationUpdateDescription = 
                new ApplicationUpdateDescription();

            Status(string.Format("Checking for update: {0}", this.Key), dbName);

            if (updateApplicable)
            {
                _applicationUpdateDescription.Filename = clientNotifier.ApplicationUpdateDescription();
                updateApplicable = CheckAndProcessAppDesc(ghostConveyServerInstall, 
                    clientNotifier, _applicationUpdateDescription, ref customUserMessage);
            }

            if (updateApplicable)            
            {   
                try
                {
                    if (!string.IsNullOrEmpty(customUserMessage))
                        DoAnyNotificationWork(ghostConveyServerInstall, customUserMessage);
                }
                catch (Exception e)
                { LogErrorToEventLog(e, "CheckForUpdatesNow"); }

                //do other work
                if (downLoadUpdate)
                {
                    Status(string.Format("Downloading update: {0}", this.Key), dbName);

                    if (windowedInstance)
                    {
                        _ghostConveyServerInstall = ghostConveyServerInstall;
                        clientNotifier.DownloadLatestUpdateAsync();
                        //_applicationUpdateDescription[ghostConveyServerInstall.ConfigReference] = true;
                    }
                    else
                    {
                        clientNotifier.DownloadLatestUpdate();
                        _applicationUpdateDescription[ghostConveyServerInstall.ConfigReference] = 
                            ApplyDownloadedZipUpdate(_clientNotifier, ghostConveyServerInstall);
                    }

                }
                else
                {
                    Status(string.Format("There is an update available for: {0}", this.Key), dbName);
                }
            }
            else
            {
                Status(string.Format("There is no update available for: {0}", this.Key), dbName);
                if (clientNotifier.UpdateAvailable())
                    _applicationUpdateDescription[ghostConveyServerInstall.ConfigReference] = true;
            }
        }
        private bool CheckAndProcessAppDesc(GhostConveyServerInstall ghostConveyServerInstall, ClientNotifier clientNotifier, 
            ApplicationUpdateDescription applicationUpdateDescription, ref string customUserMessage)
        {
            //return whether it is applicable
            try
            {
                if (applicationUpdateDescription[ghostConveyServerInstall.ConfigReference])
                    return false;

                if (applicationUpdateDescription.Checks.Count == 0)
                {
                    customUserMessage = applicationUpdateDescription.UserMessage;
                    return true;
                }

                foreach (UpdateCheck check in applicationUpdateDescription.Checks)
                {
                    //if one check passes all do (OR)
                    if (check.CheckPassed(ghostConveyServerInstall.RunQueryStr(check.Check)))
                    {
                        customUserMessage = applicationUpdateDescription.UserMessage;
                        return true;
                    }
                }
            }
            catch (Exception e)
            { 
                TraceLog.Log(e);
                //lets assume it is applicable if anything fails.
                return true;
            }           

            return false;
        }
        protected bool ApplyZippedUpdate(string downloadFilePath, GhostConveyServerInstall ghostConveyServerInstall)
        {
            try
            {
                ghostConveyServerInstall.ApplyZippedUpdate(downloadFilePath);
                return true;
            }
            catch (Exception e)
            { 
                LogErrorToEventLog(e, "ApplyZippedUpdate");
                return false;
            }
        }
        private bool ApplyDownloadedZipUpdate(ClientNotifier clientNotifier, GhostConveyServerInstall ghostConveyServerInstall)
        {
            bool success = true;

            if (clientNotifier.UpdateDownloaded())
            {
                Status(string.Format("Copying update: {0}", this.Key), ghostConveyServerInstall.DbName);

                if (_settings["MakeCopyOfFile"].Equals("True",StringComparison.CurrentCultureIgnoreCase))
                    MakeCopyOfDownload(clientNotifier, DownloadPath);

                if (_settings["ApplyDownloadedUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase))
                {
                    Status(string.Format("Applying update: {0}", this.Key), ghostConveyServerInstall.DbName);
                    
                    foreach (string zip in AllZipFiles(clientNotifier.UpdateFilePath))
                        success = (success && ApplyZippedUpdate(zip, ghostConveyServerInstall));  //zip
                    //clientUpdater.ApplyUpdate(null);  //msi

                    Status(string.Format("Update applied: {0}", this.Key), ghostConveyServerInstall.DbName);

                    return success;
                }
                else
                {
                    Status(string.Format("Update downloaded: {0}", this.Key), ghostConveyServerInstall.DbName);                    
                }
            }
            return false;
        }
        private void CheckGCInstallUpdate(GhostConveyServerInstall ghostConveyServerInstall)
        {
            _productVersion = ghostConveyServerInstall.GCVersionFromFile;

            Init(); //will create a new cu.

            //maybe later - does not seem to work now.
            _clientNotifier.UserId = ghostConveyServerInstall.GCLicenseCode;

            CheckForUpdatesNow(_settings["DownLoadUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase),
                _settings["ApplyDownloadedUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase),
                ghostConveyServerInstall, _clientNotifier);
        }
        
        #endregion

        #region Overrides
        protected override void StatusToLabel(string status, string statusNextLine)
        {
            lblStatus1.Text = statusNextLine;
            lblStatus1.Visible = true;
            StatusToLabel(status);
            lblStatus.Parent.Refresh();
        }
        protected override void StatusToLabel(string status)
        {
            lblStatus.Text = status;
            lblStatus.Visible = true;
            lblStatus.Parent.Refresh();
        }
        public override void BuildNewPluginSettings(ref PluginSettings currentSettings, string name, string fileName)
        {

            //add new incase they dont exist
            if (currentSettings.PluginSettingNotExists("Key"))
                currentSettings.Add("Key", KEY, true);
            if (currentSettings.PluginSettingNotExists("MenuPath1"))
                currentSettings.Add("MenuPath1", MENU_PATH1, true);
            if (currentSettings.PluginSettingNotExists("MenuPath2"))
                currentSettings.Add("MenuPath2", MENU_PATH2, true);
            if (currentSettings.PluginSettingNotExists("PluginName"))
                currentSettings.Add("PluginName", PLUGIN_NAME, true);
            if (currentSettings.PluginSettingNotExists("Interval"))
                currentSettings.Add("Interval", INTERVAL.ToString());
            if (currentSettings.PluginSettingNotExists("DownLoadUpdate"))
                currentSettings.Add("DownLoadUpdate", DOWNLOAD_UPDATE.ToString());
            if (currentSettings.PluginSettingNotExists("ApplyDownloadedUpdate"))
                currentSettings.Add("ApplyDownloadedUpdate", APPLY_DOWNLOADED_UPDATE.ToString());
            if (currentSettings.PluginSettingNotExists("PluginActive"))
                currentSettings.Add("PluginActive", PLUGIN_ACTIVE.ToString());
            if (currentSettings.PluginSettingNotExists("RunType"))
                currentSettings.Add("RunType", RUNTYPE.ToString());
            if (currentSettings.PluginSettingNotExists("AutoUpdateServer"))
                currentSettings.Add("AutoUpdateServer", AUTO_UPDATE_SERVER.ToString());
            if (currentSettings.PluginSettingNotExists("MakeCopyOfFile"))
                currentSettings.Add("MakeCopyOfFile", MAKE_COPY_OF_FILE.ToString());
            if (currentSettings.PluginSettingNotExists("MakeCopyPath"))
                currentSettings.Add("MakeCopyPath", MAKE_COPY_PATH.ToString());
            if (currentSettings.PluginSettingNotExists("NotificationActive"))
                currentSettings.Add("NotificationActive", NOTIFICATION_ACTIVE.ToString());
            if (currentSettings.PluginSettingNotExists("CalculateIntervalFromBase"))
                currentSettings.Add("CalculateIntervalFromBase", CALCULATE_INTERVAL_FROM_BASE.ToString());
                        
            currentSettings.FileName = fileName;
            currentSettings.SaveToSameXML();
        }
        protected override void ProgressToBar(int position, int fullsize)
        {
            pbDownload.Minimum = 0;
            if (fullsize != 0)
                pbDownload.Maximum = fullsize;
            pbDownload.Value = position;
        }
        public override void HandleSettings(bool load)
        {
            if (load)
            {
                cbNoDLoad.Checked = _settings["DownLoadUpdate"].Equals("False");
                cbNoApply.Checked = _settings["ApplyDownloadedUpdate"].Equals("False",StringComparison.CurrentCultureIgnoreCase);
                cbCopy.Checked = _settings["MakeCopyOfFile"].Equals("True");
                cbGCNotify.Checked = _settings["NotificationActive"].Equals("True",StringComparison.CurrentCultureIgnoreCase);
                tbDownloadPath.Text = _settings["MakeCopyPath"];
                cbNoDLoad_Click(null, null);
            }
            else
            {
                _settings["DownLoadUpdate"] = (!cbNoDLoad.Checked).ToString();
                _settings["ApplyDownloadedUpdate"] = (!cbNoApply.Checked).ToString();
                _settings["MakeCopyOfFile"] = cbCopy.Checked.ToString();
                _settings["NotificationActive"] = cbGCNotify.Checked.ToString();
                _settings["MakeCopyPath"] = tbDownloadPath.Text;
            }
        }
        #region AutoUpdate Event Handlers
        protected override void updater_DownloadComplete(object sender, ActionCompleteEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status("Download Complete!");
                    if (windowedInstance)
                    {
                        if (!ApplyDownloadedZipUpdate((ClientNotifier)sender, _ghostConveyServerInstall))
                            Status("File access problem, please see eventlog.");
                    }
                }
            ));
        }
        #endregion
        
        #endregion
                
        #region IRunnablePlugin Members
        public override void Start()
        {
            TraceLog.Log(String.Concat(this.Name," Start ",DateTime.Now.ToString()));
            if (windowedInstance)
            { 
                if (lbDBs.SelectedItems.Count < 1)
                {
                    Status("Please select a database (GhostConvey Install).");
                    return;
                }

                CheckGCInstallUpdate(new GhostConveyServerInstall(lbDBs.SelectedItem.ToString()));
                return;
            }
            
            foreach (Db db in _serverInformation.DBs)
            {        
                if (!(db is GhostConveyServerInstall))
                    continue;

                CheckGCInstallUpdate((db as GhostConveyServerInstall));                
            }

            //Utilities.DummyTestForm(140, this.Name);
        }        
        public override void Init()
        {
            if (_productVersion != null)
            {
                _clientNotifier = new ClientNotifier(this.Key, _productVersion, this.AutoUpdateServer);
                TraceLog.Log(string.Format("Created ClientNotifier for {0}, ver {1}, to server {2}.",this.Key,_productVersion.ToString(), this.AutoUpdateServer));

                if (_serverInformation.ProxySet)
                {
                    _clientNotifier.Proxy = Utilities.GetProxy(_serverInformation);
                    if (_clientNotifier.Proxy == null)
                        _clientNotifier.Proxy = WebRequest.DefaultWebProxy;
                }
                else
                    TraceLog.Log("No proxy set.");
            }

            if ((windowedInstance) && (_clientNotifier != null))
            {
                ClientUpdaterEvents(_clientNotifier);
            }/**/
               
        }

        #endregion

        #region IPlugin Members
        public PluginServerInformation ServerInformation
        {
            get
            {
                return _serverInformation;
            }
            set
            {
                _serverInformation = value;
                FillDBBox(_serverInformation.DBs);
            }
        }

        #endregion
        
    }
}
