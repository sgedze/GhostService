using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A collection of settings for a plugin
    /// </summary>
    public class PluginSettings
    {      
        public string FileName
        { get; set; }
        public string PluginName
        { get; set; }
        private Dictionary<string, PluginSetting> _pluginSettings;

        public PluginSettings(string PluginName)
        {
            _pluginSettings = new Dictionary<string, PluginSetting>();
            this.PluginName = PluginName;
        }

        public PluginSettings(string FileName, string PluginName) :
            this(PluginName)
        {
            this.FileName = FileName;
            LoadFromXML(FileName);
        }

        public void Add(string key, string value, bool hidden)
        {
            _pluginSettings.Add(key, new PluginSetting(key,value,hidden));
        }

        public void Add(string key, string value)
        {
            this.Add(key, value, false);
        }
        
        public string this[string key] 
        {
            get
            { 
                return _pluginSettings[key].StringValue;
            }
            set
            { _pluginSettings[key].StringValue = value; }
        }
        
        public void SaveToSameXML()
        {
            SaveToNewXML(this.FileName, this.PluginName);
        }

        public void SaveToNewXML(string FilePath, string PluginName)
        {
            XmlDocument doc = new XmlDocument();

            XmlWriter xmlWriter = XmlWriter.Create(FileName, Utilities._TheXMLSettings());

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(PluginName);
            xmlWriter.WriteStartElement("Settings");

            foreach (string s in _pluginSettings.Keys)
            {
                if (!_pluginSettings[s].HiddenSetting)
                    xmlWriter.WriteElementString(s, _pluginSettings[s].StringValue);
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public bool PluginSettingNotExists(string Key)
        {
            return (!_pluginSettings.ContainsKey(Key));
        }

        public void LoadFromXML(string FileName)
        {
            this.FileName = FileName;

            if (!File.Exists(FileName))
                return;

            XmlDocument doc = new XmlDocument();

            using (XmlReader xr = XmlReader.Create(FileName))
                doc.Load(xr);


            foreach (XmlNode node in doc.ChildNodes)
            {
                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    foreach (XmlNode deepestNode in innerNode.ChildNodes)
                    {
                        this.Add(deepestNode.Name, innerNode[deepestNode.Name].InnerText, false);
                    }
                }
            }
        }
    }
}
