using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A setting for a plugin, seems pointless now, but we might want to add other properties
    /// </summary>
    public class PluginSetting
    {
        public string Key
        {get;set;}
        public string StringValue
        {get;set;}
        public bool HiddenSetting
        { get; set; }  //hidden settings will not get saved.

        public PluginSetting(String key, string stringValue, bool hiddenSetting)
        {
            this.Key = key;
            this.StringValue = stringValue;
            this.HiddenSetting = hiddenSetting;
        }

        public string ToString()
        {
            return String.Format("{0}:{1}:{2}", Key, StringValue, HiddenSetting.ToString());
        }
    }
}
