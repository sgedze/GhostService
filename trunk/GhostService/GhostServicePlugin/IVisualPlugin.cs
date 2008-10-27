using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A Plugin that contains a visual component for setup by user
    /// </summary>
    public interface IVisualPlugin : IRunnablePlugin
    {
        String[] MenuPath { get; }
        String PluginName { get; }
        void Show();
        void MyHost(Control Parent);
        void ClickShow(object sender, EventArgs e);
        void Activated(object sender, EventArgs e);
        void Deactivated(object sender, EventArgs e);
        Panel AsPanel { get; }
        //void LoadSettingsFromXML(string FileName);
        //void SaveSettingsToXML(string FileName);
    }
}
