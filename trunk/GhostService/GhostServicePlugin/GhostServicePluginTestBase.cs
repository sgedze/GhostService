using System;
using System.Collections.Generic;
using System.Text;
using GhostService.GhostServicePlugin;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Handy for testing, forms the basis of a "random" runnable plugin
    /// </summary>
    public class GhostServicePluginTestBase: IRunnablePlugin
    {
        private ushort pluginInterval;
        private PluginServerInformation _serInfo;
        //private int runtype;

        public GhostServicePluginTestBase()
        {
            pluginInterval = 1;//(ushort)new Random().Next(1, 4);
            //runtype = new Random().Next(0, 2);
        }
        
        #region IRunnablePlugin Members

        public ushort Interval
        {
            get { return pluginInterval; }
        }

        public PluginRunType RunType
        {
            get { return PluginRunType.PerInterval /*(PluginRunType) runtype*/; }
        }

        public bool PluginActive
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public bool CalculateIntervalFromBase
        {
            get { return false; }
        }

        public void Init()
        {
            
        }

        public void Start()
        {
            try
            {
                Utilities.SendTestEmail(this.ServerInformation, "justint@korbitec.com");
            }
            catch (Exception e)
            {
                TraceLog.Log(e);
            }
        }

        public void InitAndStart()
        {
            Start();
            //Utilities.DummyTestForm(new Random().Next(3,20), this.Key);
        }

        #endregion

        #region IPlugin Members

        public string Key
        {
            get { return pluginInterval.ToString(); }
        }

        public PluginServerInformation ServerInformation
        {
            get
            {
                return _serInfo;
            }
            set
            {
                _serInfo = value;
            }
        }

        #endregion
    }
}
