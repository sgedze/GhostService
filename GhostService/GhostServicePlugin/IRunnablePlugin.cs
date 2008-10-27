using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A Plugin that will only be run, it will require no visual setup
    /// </summary>
    public interface IRunnablePlugin : IPlugin
    {
        ushort Interval { get; }
        PluginRunType RunType { get; }
        bool PluginActive { get; set; }
        bool CalculateIntervalFromBase { get; }
        void Init();
        void Start();
        void InitAndStart();
        //void CleanUp();
    }
}
