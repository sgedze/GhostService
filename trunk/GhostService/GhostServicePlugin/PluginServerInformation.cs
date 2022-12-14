using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Information send to each plugin about the server
    /// </summary>
    public class PluginServerInformation
    {

        private Dictionary<string, string> _settings;
        private string fileName;

        #region Properties
        public List<Db> DBs
        { get; set; }        
        private object _updateReadyForInstall;
        public object UpdateReadyForInstallObj
        { 
            get
            {
                TraceLog.Log("UpdateReadyForInstallObj called.");
                if (_updateReadyForInstall == null)
                {
                    TraceLog.Log("UpdateReadyForInstallObj created.");
                    _updateReadyForInstall = new Object();
                }
                return _updateReadyForInstall;
            }
        }
        private bool updateReadyForInstall;
        public bool UpdateReadyForInstall
        {
            get 
            {
                TraceLog.Log(string.Format("UpdateReadyForInstall get {0}.", updateReadyForInstall.ToString()));
                return updateReadyForInstall;
            }
            set
            {
                TraceLog.Log(string.Format("UpdateReadyForInstall set {0}.", updateReadyForInstall.ToString()));
                updateReadyForInstall = value;
            }
        }
        public PluginServerInformation()
        {
            DBs = new List<Db>();
            _settings = new Dictionary<string, string>();
        }
        public string TraceFileName
        {
            get
            {
                return _settings["TraceFilename"];
            }

            set
            {
                _settings["TraceFilename"] = value;
                TraceLog.TraceLogFileName = value;
            }
        }
        public bool TraceEnabled
        {
            get
            {
                return (!string.IsNullOrEmpty(TraceFileName));
            }
        }
        public string StartupDelay
        {
            get
            { return _settings["StartupDelay"]; }

            set
            { _settings["StartupDelay"] = value; }
        }
        public int AutoUpdateWaitForServiceMax
        {
            get
            { return Convert.ToInt32(_settings["AutoUpdateWaitForServiceMax"]); }

            set
            { _settings["AutoUpdateWaitForServiceMax"] = value.ToString(); }
        }
        public int StartupDelayInt
        {
            get
            { return Convert.ToInt16(_settings["StartupDelay"]); }

            set
            { _settings["StartupDelay"] = value.ToString(); }
        }
        public bool UseDefaultProxySettings
        {
            get
            {
                return _settings["UseDefaultProxySettings"].Equals("True",StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["UseDefaultProxySettings"] = value.ToString();
            }
        }
        public bool ProxyCachedCredentials
        {
            get
            {
                return _settings["ProxyCachedCredentials"].Equals("True", StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["ProxyCachedCredentials"] = value.ToString();
            }
        }
        public bool ProxySet
        {
            get
            {
                return _settings["ProxySet"].Equals("True", StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["ProxySet"] = value.ToString();
            }
        }
        public string ProxyServer
        {
            get
            {
                return _settings["ProxyServer"];
            }

            set
            {
                _settings["ProxyServer"] = value;
            }
        }
        public string ProxyPort
        {
            get
            {
                return _settings["ProxyPort"];
            }

            set
            {
                _settings["ProxyPort"] = value;
            }
        }
        public string ProxyUserName
        {
            get
            {
                return _settings["ProxyUserName"];
            }

            set
            {
                _settings["ProxyUserName"] = value;
            }
        }
        public string ProxyPassword
        {
            get
            {                
                return _settings["ProxyPassword"];
            }

            set
            {
                _settings["ProxyPassword"] = value;
            }
        }
        public string ProxyDomain
        {
            get
            {
                return _settings["ProxyDomain"];
            }

            set
            {
                _settings["ProxyDomain"] = value;
            }
        }
        public bool SMTPSecureConnection
        {
            get
            {
                return _settings["SMTPSecureConnection"].Equals("True", StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["SMTPSecureConnection"] = value.ToString();
            }
        }
        public string SMTPPassword
        {
            get
            {                
                return _settings["SMTPPassword"];
            }

            set
            {
                _settings["SMTPPassword"] = value;
            }
        }
        public string SMTPDefaultFromAddress
        {
            get
            {                
                return _settings["SMTPDefaultFromAddress"];
            }

            set
            {
                _settings["SMTPDefaultFromAddress"] = value;
            }
        }
        public string SMTPUsername
        {
            get
            {                
                return _settings["SMTPUsername"];
            }

            set
            {
                _settings["SMTPUsername"] = value;
            }
        }
        public string SMTPServer
        {
            get
            {                
                return _settings["SMTPServer"];
            }

            set
            {
                _settings["SMTPServer"] = value;
            }
        }
        public bool ServiceSettingsTest
        {
            get
            {
                return _settings["ServiceSettingsTest"].Equals("True", StringComparison.CurrentCultureIgnoreCase);
            }

            set
            {
                _settings["ServiceSettingsTest"] = value.ToString();
            }
        }

        #endregion 

        #region work
        public void RemoveDB(string dBConfigPath)
        {
            foreach (Db db in DBs)
                if (db.ConfigFilePath.Equals(dBConfigPath))
                {
                    DBs.Remove(db);
                    break;
                }
        }
        /*public void Log(string traceMsg)
        {
            TraceLog.Log(traceMsg, TraceFileName);
        }
        public void Log(Exception exception)
        {
            TraceLog.Log(exception.ToString(), TraceFileName);
        }*/
        private void AddNewSettings()
        {
            //add settings            
            if (!_settings.ContainsKey("TraceFilename"))
                _settings.Add("TraceFilename", "");

            if (!_settings.ContainsKey("StartupDelay"))
                _settings.Add("StartupDelay", "3");

            if (!_settings.ContainsKey("AutoUpdateWaitForServiceMax"))
                _settings.Add("AutoUpdateWaitForServiceMax", Utilities.MAX_MIN_WAIT_UPDATE.ToString());

            if (!_settings.ContainsKey("ProxySet"))
                _settings.Add("ProxySet", "True");
            
            if (!_settings.ContainsKey("UseDefaultProxySettings"))
                _settings.Add("UseDefaultProxySettings", "True");

            if (!_settings.ContainsKey("ProxyServer"))
                _settings.Add("ProxyServer", "");

            if (!_settings.ContainsKey("ProxyPort"))
                _settings.Add("ProxyPort", "");
       
            if (!_settings.ContainsKey("ProxyUserName"))
                _settings.Add("ProxyUserName", "");

            if (!_settings.ContainsKey("ProxyPassword"))
                _settings.Add("ProxyPassword", "");

            if (!_settings.ContainsKey("ProxyDomain"))
                _settings.Add("ProxyDomain", "");

            if (!_settings.ContainsKey("ProxyCachedCredentials"))
                _settings.Add("ProxyCachedCredentials", "False");

            if (!_settings.ContainsKey("SMTPDefaultFromAddress"))
                _settings.Add("SMTPDefaultFromAddress", "");

            if (!_settings.ContainsKey("SMTPUsername"))
                _settings.Add("SMTPUsername", "");

            if (!_settings.ContainsKey("SMTPPassword"))
                _settings.Add("SMTPPassword", "");

            if (!_settings.ContainsKey("SMTPServer"))
                _settings.Add("SMTPServer", "");

            if (!_settings.ContainsKey("SMTPSecureConnection"))
                _settings.Add("SMTPSecureConnection", "False");

            if (!_settings.ContainsKey("ServiceSettingsTest"))
                _settings.Add("ServiceSettingsTest", "False");

            //remove settings
            if (_settings.ContainsKey("UseMAPI"))
                _settings.Remove("UseMAPI");
        }

        #endregion

        #region xml work
        public void SaveToSameXML()
        {
            SaveToNewXML(this.fileName);
        }
        public void SaveToNewXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            XmlWriter xmlWriter = XmlWriter.Create(fileName, Utilities._TheXMLSettings());

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Setup");
            xmlWriter.WriteStartElement("Databases");
            foreach (Db db in DBs)
            {
                xmlWriter.WriteStartElement("Database");
                xmlWriter.WriteElementString("Path", db.ConfigFilePath);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Settings");

            foreach (string s in _settings.Keys)
            {
                if (s.ToLower().Contains("password"))
                    xmlWriter.WriteElementString(s, string.Concat("@@",Utilities.Encrypt(_settings[s])));
                else                    
                    xmlWriter.WriteElementString(s, _settings[s]);
            }

            xmlWriter.WriteEndElement();
            xmlWriter.Close();

        }
        public void LoadFromXML(string fileName)
        {
            this.fileName = fileName;

            if (!File.Exists(fileName))
            {
                AddNewSettings();
                SaveToSameXML();
                return;
            }

            XmlDocument doc = new XmlDocument();

            using (XmlReader xr = XmlReader.Create(fileName))
                doc.Load(xr);

            foreach (XmlNode xml in doc.ChildNodes)
                foreach (XmlNode node in xml.ChildNodes)
                {
                    if (node.Name.Equals("Databases"))
                        foreach (XmlNode database in node.ChildNodes)
                        {
                            DBs.Add(new GhostConveyServerInstall(database["Path"].InnerText));
                        }
                    else if (node.Name.Equals("Settings"))
                    {
                        foreach (XmlNode innerNode in node.ChildNodes)
                        {
                            if (innerNode.Name.ToLower().Contains("password"))
                            {
                                if (node[innerNode.Name].InnerText.StartsWith("@@"))
                                    _settings.Add(innerNode.Name, Utilities.Decrypt(node[innerNode.Name].InnerText.Substring(2)));
                                else
                                    _settings.Add(innerNode.Name, node[innerNode.Name].InnerText);
                                    
                            }
                            else
                                _settings.Add(innerNode.Name, node[innerNode.Name].InnerText);
                        }
                    }
                }

            //this will add new items to xml that developers want to add
            AddNewSettings();

            //if new ones have been added just save it
            SaveToSameXML();
        }
        
        #endregion

    }
}
