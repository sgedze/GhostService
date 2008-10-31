using System;
using System.Windows.Forms;
using GhostService.GhostServicePlugin;
using Korbitec.AutoUpdate.ClientUpdates;
using System.IO;
using System.Threading;
using System.Net;

namespace GhostServicePluginGSUpdates
{
    public partial class GSUpdateVPlugin : EventAutoUpdatePluginBase, IVisualPlugin
    {
        #region To save to XML (defaults)
        private const string KEY = "GhostService";
        private const string MENU_PATH1 = "GhostService";
        private const string MENU_PATH2 = "Auto Updates";
        private const string PLUGIN_NAME = "GhostService Auto Updates";
        private const ushort INTERVAL = 60;
        private const PluginRunType RUNTYPE = PluginRunType.PerInterval;
        private const bool DOWNLOAD_UPDATE = true;
        private const bool APPLY_DOWNLOADED_UPDATE = true;
        private const bool CALCULATE_INTERVAL_FROM_BASE = false;
        private const bool PLUGIN_ACTIVE = true;        
        private string AUTOUPDATE_SERVER = @"http://autoupdate.korbitec.com/AutoUpdateServer/Service.svc";
        private string OLD_AUTOUPDATE_SERVER = @"http://sqltestpc.korbitec.int/AutoUpdateServer/Service.svc";
        #endregion               
        
        protected ClientUpdater _clientUpdater;        

        #region constructors
        public GSUpdateVPlugin()
        {
            InitializeComponent();

            //read config file or create one
            LoadOrBuildConfigFile(this.Name);
        }

        #endregion

        #region properties
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

        #region work
        public void CheckForUpdatesNow(bool downLoadUpdate, bool applyDownloadedUpdate, ClientUpdater clientUpdater)
        {
            Status("Checking for update: " + this.Key);

            if (clientUpdater.UpdateAvailable())
            {
                /*try
                {
                    DoAnyNotificationWork();
                }
                catch (Exception)
                {Do Something}*/

                //do other work
                if (downLoadUpdate)
                {
                    Status("Downloading update: " + this.Key);
                    clientUpdater.DownloadLatestUpdate();

                    if (clientUpdater.UpdateDownloaded())
                    {
                        Status("Copying update: " + this.Key);

                        if (applyDownloadedUpdate)
                        {
                            Status("Waiting to apply update: " + this.Key);

                            lock (ServerInformation.UpdateReadyForInstallObj)
                            {
                                //zero means dont wait - run the update if threads die during update, to bad.
                                if (ServerInformation.AutoUpdateWaitForServiceMax > 0)                                    
                                {
                                    if (!windowedInstance)
                                    {
                                        TraceLog.Log("Waiting for pulse, in order to run update.");
                                        ServerInformation.UpdateReadyForInstall = true;
                                        Monitor.Wait(ServerInformation.UpdateReadyForInstallObj);
                                    }
                                }
                            
                                Status("Applying update: " + this.Key);
                                clientUpdater.ApplyUpdate(null);
                                Status("Update applied: " + this.Key);

                                //at this point it should restart and reset all. but just in case
                                ServerInformation.UpdateReadyForInstall = false;
                            }
                        }
                        else
                        {
                            Status("Update downloaded: " + this.Key);
                        }
                    }
                }
                else
                {
                    Status("There is an update available for: " + this.Key);
                }
            }
            else
            {
                Status("There is no update available for: " + this.Key);
            }
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
            if (currentSettings.PluginSettingNotExists("CalculateIntervalFromBase"))
                currentSettings.Add("CalculateIntervalFromBase", CALCULATE_INTERVAL_FROM_BASE.ToString());
            if (currentSettings.PluginSettingNotExists("PluginActive"))
                currentSettings.Add("PluginActive", PLUGIN_ACTIVE.ToString());
            if (currentSettings.PluginSettingNotExists("RunType"))
                currentSettings.Add("RunType", RUNTYPE.ToString());
            if (currentSettings.PluginSettingNotExists("AutoUpdateServer"))
                currentSettings.Add("AutoUpdateServer", AUTOUPDATE_SERVER.ToString());
                        
            currentSettings.FileName = fileName;
            currentSettings.SaveToSameXML();            
        }
                
        #endregion  
     
        #region events
        public void Activated(object sender, EventArgs e)
        {
            Activating(sender, e);
            windowedInstance = true;
        }
        public void Deactivated(object sender, EventArgs e)
        {
            Deactivating(sender, e);
        }
        public void ClientUpdaterEvents(ClientUpdater cur)
        {
            cur.DownloadComplete += updater_DownloadComplete;
            cur.DownloadFailed += updater_DownloadFailed;
            cur.DownloadSize += updater_DownloadSize;
            cur.DownloadProgress += updater_DownloadProgress;
            cur.UpdateComplete += updater_UpdateComplete;
        }
        private void btnCheckNow_Click(object sender, EventArgs e)
        {
            windowedInstance = true;
            Init();
            CheckForUpdatesNow(_settings["DownLoadUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase),
                _settings["ApplyDownloadedUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase), _clientUpdater);
        }

        #endregion
        
        #region overrides
        public override void HandleSettings(bool load)
        { /*nothing*/ }
        /*protected override void DoAnyNotificationWork()
        { nothing }*/
        protected override void StatusToLabel(string status)
        {
            lblStatus.Text = status;
            lblStatus.Visible = true;
            lblStatus.Parent.Refresh();
        }
        protected override void ProgressToBar(int position, int fullsize)
        {
            pbDownload.Minimum = 0;
            if (fullsize != 0)
                pbDownload.Maximum = fullsize;
            pbDownload.Value = position;
        }

        #endregion
        
        #region IRunnablePlugin Members
        public override void Init()
        {
            _clientUpdater = new ClientUpdater(this.Key,this.AutoUpdateServer);
            TraceLog.Log(string.Format("Created ClientNotifier for {0}, to server {1}.",this.Key, this.AutoUpdateServer));

            if (_serverInformation.ProxySet)
            {
                _clientUpdater.Proxy = Utilities.GetProxy(_serverInformation);
                if (_clientUpdater.Proxy == null)
                    _clientUpdater.Proxy = WebRequest.DefaultWebProxy;
            }
            else
                TraceLog.Log("No proxy set.");
            
            if (windowedInstance)
                ClientUpdaterEvents(_clientUpdater);
        }
        public override void Start()
        {
            TraceLog.Log(String.Concat(this.Name, " Start ", DateTime.Now.ToString()));

            CheckForUpdatesNow(_settings["DownLoadUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase),
                _settings["ApplyDownloadedUpdate"].Equals("True",StringComparison.CurrentCultureIgnoreCase), _clientUpdater);
            
            /*Status("Waiting to apply update: " + this.Key);
            TraceLog.Log("Starting phase1 now");
            Utilities.DummyTestForm(10, this.Name, "Phase 1");
            lock (ServerInformation.UpdateReadyForInstallObj)
            {
                if (ServerInformation.AutoUpdateWaitForServiceMin > 0)
                {
                    ServerInformation.UpdateReadyForInstall = true;
                    TraceLog.Log("Waiting to start phase2.");
                    Monitor.Wait(ServerInformation.UpdateReadyForInstallObj);
                }
                TraceLog.Log("Starting phase2 now");
                Utilities.DummyTestForm(10, this.Name, "Phase 2");
                ServerInformation.UpdateReadyForInstall = false;
            }*/

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
                
            }
        }

        #endregion
    }
}
