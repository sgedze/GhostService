using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Base Interface for a plugin, not recognised yet, more for future use
    /// </summary>
    public interface IPlugin
    {
        String Key { get; }
        PluginServerInformation ServerInformation { get; set; }
    }
}
