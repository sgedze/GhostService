using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Can be used as a base tabbed plugin that is known to the visual container
    /// </summary>
    public class BaseTabPlugin : UserControl
    {
        protected TabPage _tabpage;

        public BaseTabPlugin()
        { }

        public TabPage AsTabPage
        {
            get
            {
                if (_tabpage == null)
                {
                    _tabpage = new TabPage(this.Text);
                    this.Parent = _tabpage;
                }
                return _tabpage;
            }
        }
    }
}
