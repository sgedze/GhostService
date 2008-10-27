using System;
using System.Windows.Forms;
using System.Reflection;
using GhostService.GhostServicePlugin;
using System.IO;

namespace GhostService
{
    public partial class GhostServiceSetupF : Form
    {
        private ConfigDBS _configDBS;
        private PluginServerInformation _serverInformation;
        private ServiceMaint _serviceMaint;
        private InstalledPlugins _installedPlugins;

        private Panel ActivePanel
        { 
            get 
            {
                foreach (Control control in pnlMain.Controls)                
                {
                    if (control.Visible)
                    {
                        if (control is Panel)
                            return (control as Panel);
                    }
                }
                
                return null;
            }
        }

        public GhostServiceSetupF()
        {
            InitializeComponent();            
        }

        #region For load up
        public void LoadVisualPlugins(string DirectoryPath, string PluginFileFilter)
        {
            string path = DirectoryPath;
                        
            string[] pluginDLLs = Directory.GetFiles(path, PluginFileFilter);

            foreach (string dll in pluginDLLs)
            {                
                Assembly asm = null;
                asm = Assembly.LoadFile(dll);                    
                if (asm != null)
                {
                    foreach (Type type in asm.GetTypes())
                    {
                        if (type.Name.Contains("VPlugin")) 
                        {
                            try
                            {
                                IVisualPlugin ivp = (IVisualPlugin)Activator.CreateInstance(type);
                                ivp.MyHost(pnlMain);

                                ivp.ServerInformation = _serverInformation;
                                AddMenuItem(ivp.MenuPath, msMain, ivp);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(string.Concat("Not all plugins will be loaded. ",e.Message,e.InnerException), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                TraceLog.Log(string.Concat("LoadVisualPlugins ", e.Message, " ", e.ToString()));
                            }
                        }
                    }
                }             
            }            
        }

        private void UserControlShow(UserControl userControl)
        {
            if (userControl is BaseEventPanelPlugin)
            {
                (userControl as BaseEventPanelPlugin).AsPanel.Parent = pnlMain;
                (userControl as BaseEventPanelPlugin).AsPanel.Visible = true;
                (userControl as BaseEventPanelPlugin).AsPanel.Dock = DockStyle.Fill; 
            }
            userControl.Dock = DockStyle.Fill;            
        }

        private void LoadAndSetupDatabases(string FileName)
        {            
            _configDBS = new ConfigDBS();
            configureDatabasesToolStripMenuItem.Click += CallDeactivating;            
            configureDatabasesToolStripMenuItem.Click += LoadDbForm;
            configureDatabasesToolStripMenuItem.Click += CallActivating;
            _serverInformation = new PluginServerInformation();
            _serverInformation.LoadFromXML(FileName);
            TraceLog.TraceLogFileName = _serverInformation.TraceFileName;
            _configDBS.LoadDbs(ref _serverInformation);            
        }

        private void LoadServiceConfiguration()
        {
            _serviceMaint = new ServiceMaint(_serverInformation);
            serviceManagementToolStripMenuItem.Click += CallDeactivating; //deactivate current
            serviceManagementToolStripMenuItem.Click += LoadServiceManagementForm;
            serviceManagementToolStripMenuItem.Click += CallActivating; //activate current
        }

        private void LoadInstalledPlugins(string directoryPath)
        {
            _installedPlugins = new InstalledPlugins();
            _installedPlugins.PopulateAssemblies(directoryPath);            
            installedPluginsToolStripMenuItem.Click += CallDeactivating;
            installedPluginsToolStripMenuItem.Click += LoadInstalledPluginsForm;
            installedPluginsToolStripMenuItem.Click += CallActivating;
        }

        private void handleSettings(bool Load)
        {
            //NOTE: Remember if you are saving something for Service portion it is
            //probably better in an xml file than in Settings.
            if (Load)
            {
                //nothing yet
            }
            else
            {
                //save setup/service xml
                _serverInformation.SaveToSameXML();
                //save all active visual plugins
                TabsAllDeactivate();

            }
        }

        private void TabsAllDeactivate()
        {
            foreach (Control ctrl in pnlMain.Controls)
            {
                if (ctrl.Controls[0] is BaseEventPanelPlugin)
                    (ctrl.Controls[0] as BaseEventPanelPlugin).Deactivated(null, null);
                else if (ctrl.Controls[0] is IVisualPlugin)
                    (ctrl.Controls[0] as IVisualPlugin).Deactivated(null, null);
            }
        }
        #endregion

        #region Build Menu
        public ToolStripMenuItem FindMenuItem(ToolStripItemCollection tsic, string Name)
        {
            foreach (ToolStripMenuItem tsi in tsic)
            {
                if (tsi.Text.Equals(Name))
                {
                    return tsi;
                }
            }
            return null;
        }

        public void AddMenuItem(String[] MenuItemName, MenuStrip theMenu, IVisualPlugin ivp)
        {
            ToolStripItemCollection tsic = theMenu.Items;
            ToolStripMenuItem tsmi;

            for (int i = 0; i < MenuItemName.Length; i++)
            {
                tsmi = null;

                tsmi = FindMenuItem(tsic, MenuItemName[i]);

                if (tsmi == null)
                {
                    tsmi = new ToolStripMenuItem(MenuItemName[i]);
                    tsic.Add(tsmi);
                }

                tsic = tsmi.DropDownItems;
                if (i == MenuItemName.Length - 1)
                {
                    tsmi.Click += CallDeactivating; //deactivate current
                    tsmi.Click += ivp.ClickShow;
                    tsmi.Click += CallActivating; //activate current
                }
            }
        }

        public ToolStripMenuItem AddInvisibleItem(String MenuItemName, MenuStrip theMenu)
        {
            ToolStripMenuItem tsmi;
            tsmi = FindMenuItem(theMenu.Items, MenuItemName);
            if (tsmi == null)
            {
                tsmi = new ToolStripMenuItem();
                tsmi.Text = MenuItemName;
                tsmi.Visible = false;
                theMenu.Items.Add(tsmi);
            }
            return tsmi;
        }       
        #endregion

        #region Custom events
        void CallActivating(object sender, EventArgs e)
        {
            if (ActivePanel != null)
            {
                if (ActivePanel.Controls[0] is BaseEventPanelPlugin)
                    (ActivePanel.Controls[0] as BaseEventPanelPlugin).Activated(sender, e);
                else if (ActivePanel.Controls[0] is IVisualPlugin)
                    (ActivePanel.Controls[0] as IVisualPlugin).Activated(sender, e); 
            }
            
        }

        void CallDeactivating(object sender, EventArgs e)
        {
            if (ActivePanel != null)
            {
                if (ActivePanel.Controls[0] is BaseEventPanelPlugin)
                    (ActivePanel.Controls[0] as BaseEventPanelPlugin).Deactivated(sender, e);
                else if (ActivePanel.Controls[0] is IVisualPlugin)
                    (ActivePanel.Controls[0] as IVisualPlugin).Deactivated(sender, e);
            }

        }
        
        private void LoadDbForm(Object sender, EventArgs e)
        {
            UserControlShow(_configDBS);
        }

        private void LoadServiceManagementForm(Object sender, EventArgs e)
        {
            UserControlShow(_serviceMaint);
        }

        private void LoadInstalledPluginsForm(Object sender, EventArgs e)
        {
            UserControlShow(_installedPlugins);
        }

        #endregion
        
        #region Form events
        private void GhostServiceSetup_Load(object sender, EventArgs e)
        {
            //These are "plugins" known to setup
            LoadAndSetupDatabases(Utilities.CurrentAssemblySettingFile(Assembly.GetExecutingAssembly().Location));
            LoadServiceConfiguration();
            LoadInstalledPlugins(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //These are plugins unknown to setup
            LoadVisualPlugins(Utilities.RelativePluginDirectory(Assembly.GetExecutingAssembly().Location), Utilities.PLUGIN_FILTER_NAME);                           
        }

        private void GhostServiceSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            handleSettings(false);
        }       
        #endregion

    }


}
