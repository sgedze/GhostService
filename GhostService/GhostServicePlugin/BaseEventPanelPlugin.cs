using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Can be used as a base tabbed plugin that is known to the visual container
    /// </summary>
    public class BaseEventPanelPlugin : BasePanelPlugin
    {
        public BaseEventPanelPlugin()
        { }
        public virtual void Activated(object sender, EventArgs e)
        { throw new NotImplementedException(); }
        public virtual void Deactivated(object sender, EventArgs e)
        { throw new NotImplementedException(); }
    }
}
