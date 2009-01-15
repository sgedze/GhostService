using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Can be used as a base for a Visual plugin
    /// </summary>
    public class BasePartialVisualPlugin : BasePanelPlugin
    {
        protected PluginSettings _settings;
        protected PluginServerInformation _serverInformation;
        protected Control _parent;
        protected bool _busyLoadingSettingsToUI;

        public delegate void ActivateOrDeactivate(object sender, EventArgs e);

        public ActivateOrDeactivate Activating
        { get; set; }
        public ActivateOrDeactivate Deactivating
        { get; set; }

        #region Construtors
        public BasePartialVisualPlugin()
        {
            this.Load += new System.EventHandler(this.Activate);
            Activating += this.Activate;
            Deactivating += this.Deactivate;

            try
            {
                //should be created by service
                if (!EventLog.SourceExists(Utilities.SERVICE_NAME))
                    EventLog.CreateEventSource(Utilities.SERVICE_NAME, Utilities.EVENTLOG_LOG_NAME);
            }
            catch (Exception e)
            { LogErrorToEventLog(e, "BasePartialVisualPlugin"); }
        }

        #endregion 

        #region IVisualPlugin Members
        public void MyHost(Control parent)
        {
            this._parent = parent;
            this.Text = _settings["PluginName"];
        }
        public void ClickShow(object sender, EventArgs e)
        {
            this.AsPanel.Parent = this._parent;
            this.AsPanel.Visible = true;// BringToFront();            
            this.AsPanel.Dock = DockStyle.Fill;
            this.Dock = DockStyle.Fill;
            //this.Activating(sender, e);
        }
        public string PluginName
        {
            get
            {
                return _settings["PluginName"];
            }
        }

        #endregion

        #region IRunnablePlugin Members
        public bool PluginActive
        {
            get
            {
                return _settings["PluginActive"].Equals("True",StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["PluginActive"] = value.ToString();
                //this is vital info, so we dont want to lose it.
                _settings.SaveToSameXML();
            }
        }
        public ushort Interval
        {
            get
            {
                return Convert.ToUInt16(_settings["Interval"]);
            }
        }
        public PluginRunType RunType
        {
            get
            {
                try
                {
                    return Korbitec.Utilities.EnumUtils.Parse<PluginRunType>(_settings["RunType"], true);
                }
                catch (Exception e)
                {
                    LogErrorToEventLog(e, "RunType, invalid, changed to PerInterval.");
                    return PluginRunType.PerInterval;
                }
            }
        }
        public bool CalculateIntervalFromBase
        {
            get
            {
                return _settings["CalculateIntervalFromBase"].Equals("True",StringComparison.CurrentCultureIgnoreCase);
            }
        }
        public virtual void Init()
        { throw new NotImplementedException(); }
        public virtual void Start()
        { throw new NotImplementedException(); }
        public void InitAndStart()
        {
            try
            {
                Init();
                Start();
                if (this.RunType == PluginRunType.OnceOnly)
                    PluginActive = false;
            }
            catch (Exception e)
            {
                LogErrorToEventLog(e, "InitAndStart");
            }
        }

        #endregion

        #region IPlugin Members

        public string Key
        {
            get
            {
                return _settings["Key"];
            }
        }

        #endregion

        #region all virtual
        public virtual void HandleSettings(bool load)
        { throw new NotImplementedException(); }
        public virtual void BuildNewPluginSettings(ref PluginSettings currentSettings, string name, string fileName)
        { throw new NotImplementedException(); }

        #endregion

        #region Work      
        public void LoadOrBuildConfigFile(string name)
        {
            string fileName = string.Format("{0}.xml", Path.GetFileName(Assembly.GetCallingAssembly().Location));
            fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);

            try
            {
                //create empty
                _settings = new PluginSettings(name);
                //read in details
                if (File.Exists(fileName))
                    _settings.LoadFromXML(fileName);
                //add new entries
                BuildNewPluginSettings(ref _settings, name, fileName);
            }
            catch (Exception e)
            {
                LogErrorToEventLog(e, "LoadOrBuildConfigFile");
            }

        }
        public void LogErrorToEventLog(Exception e, string error)
        {
            string err = BuildMessageFromException(e, error);

            LogMessageToTrace(err);

            try
            {
                //should be created by service
                if (!EventLog.SourceExists(Utilities.SERVICE_NAME))
                    EventLog.CreateEventSource(Utilities.SERVICE_NAME, Utilities.EVENTLOG_LOG_NAME);

                EventLog.WriteEntry(Utilities.SERVICE_NAME, err, EventLogEntryType.Error);
            }
            catch (Exception ex)
            { TraceLog.Log(string.Format("EventLog Failure: {0}",ex.ToString())); }                                              
        }
        public void LogMessageToTrace(string message)
        {
            TraceLog.Log(message);
        }
        public void LogExceptionToTrace(Exception exception)
        {
            TraceLog.Log(BuildMessageFromException(exception,""));
        }
        public void LogExceptionToTrace(Exception exception,string message)
        {
            TraceLog.Log(BuildMessageFromException(exception, message));
        }
        private string BuildMessageFromException(Exception exception, string exceptionfrom)
        {
            return string.Format("Plugin:{0}, Message:{1}, Full:{2}, Procedure:{3}", this.Name, exception.Message, exception.ToString(), exceptionfrom);
        }
        private void Activate(object sender, EventArgs e)
        {
            try
            {
                this._busyLoadingSettingsToUI = true;
                HandleSettings(true);
            }
            catch (Exception ex)
            {
                LogErrorToEventLog(ex, "_Load");
            }
            finally
            {
                this._busyLoadingSettingsToUI = false;
            }
        }
        private void Deactivate(object sender, EventArgs e)
        {
            try
            {
                HandleSettings(false);
                this._settings.SaveToSameXML();
                this.AsPanel.Visible = false;
            }
            catch (Exception ex)
            {
                LogErrorToEventLog(ex, "_Leaving");
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BasePartialVisualPlugin
            // 
            this.Name = "BasePartialVisualPlugin";
            this.ResumeLayout(false);

        }

        #endregion      
    }    
}
