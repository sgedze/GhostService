using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Can be used as a base tabbed plugin that is known to the visual container
    /// </summary>
    public class BasePanelPlugin : UserControl
    {
        protected Panel _panel;

        public BasePanelPlugin()
        { }

        public Panel AsPanel
        {
            get
            {
                if (_panel == null)
                {
                    _panel = new Panel();
                    this.Parent = _panel;
                }
                return _panel;
            }
        }
    }
}
