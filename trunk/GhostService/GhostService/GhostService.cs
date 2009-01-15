using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.Reflection;
using System.Threading;
using GhostService.GhostServicePlugin;
using System.Xml;
using System.Collections.Generic;

namespace GhostService
{
    public partial class GhostService : ServiceBase
    {
        private PluginServerInformation _serverInformation;
        private WorkItems _workItems;
        private System.Timers.Timer minuteTimer;
        //private System.Threading.Timer minuteTimer;
        private ThreadList _threadList;
        private int startCounter = 1; //by the time of the first tick it is one minute.
        private int waitingCounter = 0;
                  
        public GhostService()
        {
            InitializeComponent();

            _workItems = new WorkItems();

            _serverInformation = new PluginServerInformation();

            _threadList = new ThreadList();           
        }

        protected override void OnStart(string[] args)
        {               
            /*Need to watch this file for changes*/
            _serverInformation.LoadFromXML(Utilities.RelativeServiceSetupFile(Assembly.GetExecutingAssembly().Location));

            TraceLog.TraceLogFileName = _serverInformation.TraceFileName;

            //System.Windows.Forms.MessageBox.Show("DEBUG DLL version: " + Assembly.GetExecutingAssembly().FullName);
            TraceLog.Log(String.Format("Service started version: {0}, TestMode: {1}",Assembly.GetExecutingAssembly().FullName,_serverInformation.ServiceSettingsTest.ToString()));

            if (_serverInformation.ServiceSettingsTest)
            {
                RunInTestMode();
            }
            else
            {

                LoadRunnablePlugins(Utilities.RelativePluginDirectory(Assembly.GetExecutingAssembly().Location), Utilities.PLUGIN_FILTER_NAME);

                minuteTimer = new System.Timers.Timer();//new TimerCallback(TimerTick), null, 100, 60000); 
                minuteTimer.Interval = 60000; //minute
                minuteTimer.Elapsed += TimerTick;

                minuteTimer.Start();
            }
        }

        private void RebuildDebugProcessList()
        {
            if (_serverInformation.TraceEnabled)
            {
                XmlDocument doc = new XmlDocument();

                XmlWriter xmlWriter = XmlWriter.Create(string.Concat(_serverInformation.TraceFileName,".xml"), Utilities._TheXMLSettings());

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("run");
                xmlWriter.WriteElementString("DateLog", DateTime.Now.ToString());
                xmlWriter.WriteElementString("CurDateToMinOfWeek", Utilities.DateToMinuteOfWeek(DateTime.Now).ToString());

                xmlWriter.WriteStartElement("WorkItems");
                foreach (List<string> s in _workItems.ToCollection())
                {
                    xmlWriter.WriteStartElement("WorkItem"); 
                    xmlWriter.WriteElementString("Key", s[0]);
                    xmlWriter.WriteElementString("Key_to_date", s[1]);
                    xmlWriter.WriteElementString("Interval", s[2]);
                    xmlWriter.WriteElementString("Calc_Interval_from_base", s[3]);
                    xmlWriter.WriteElementString("Run_type", s[4]);
                    xmlWriter.WriteElementString("Assembly_Type", s[5]);
                    xmlWriter.WriteElementString("Assembly_Path", s[6]);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                                
                xmlWriter.WriteStartElement("Threads"); 
                foreach (List<string> s in _threadList.ToCollection())
                {
                    xmlWriter.WriteStartElement("Thread"); 
                    xmlWriter.WriteElementString("Key", s[3]);
                    xmlWriter.WriteElementString("Date_added", s[0]);
                    xmlWriter.WriteElementString("Date_started", s[1]);
                    xmlWriter.WriteElementString("Thread_State", s[2]);
                    xmlWriter.WriteEndElement();
                }
                 
                xmlWriter.WriteEndElement();
                xmlWriter.Close();

                //used as a trigger for the setup prog to read the file above.
                File.WriteAllText(string.Concat(_serverInformation.TraceFileName, "trigger.xml"), DateTime.Now.ToString());
            }

            TraceLog.Log(string.Format("Min Of week :{0}",Utilities.DateToMinuteOfWeek(DateTime.Now).ToString()));
            TraceLog.Log("Worklist to come.");
            TraceLog.Log(_workItems.ToString());
            TraceLog.Log("Threadlist to come.");
            TraceLog.Log(_threadList.ToString());
        }

        private void LoadRunnablePlugins(string DirectoryPath, string PluginFileFilter)
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
                        if (type.Name.Contains("VPlugin") || type.Name.Contains("RPlugin"))
                        {
                            try
                            {                                
                                IRunnablePlugin irp = (IRunnablePlugin)Activator.CreateInstance(type);
                                TraceLog.Log(string.Format("Found assembly: {0}, Loading as: {1}, Runtype: {2}", dll, type.ToString(), irp.RunType.ToString()));
                                _workItems.Add(irp, dll, type);
                                irp = null;
                            }
                            catch (Exception e)
                            {
                                this.EventLog.WriteEntry(string.Concat(e.Message,e.InnerException),EventLogEntryType.Error);
                                TraceLog.Log(e);
                            }
                        }
                    }
                }
            }
        }

        protected override void OnStop()
        {
            if (!_serverInformation.ServiceSettingsTest)
            {
                minuteTimer.Dispose();
                //this might cause problems
                _threadList.KillThreadsNow();                
            }
            
            TraceLog.Log("Service stopped version: " + Assembly.GetExecutingAssembly().FullName);
        }

        private void TimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            //so we cant call TimerTick twice.
            minuteTimer.Stop();

            try
            {
                if (StartDelayed())
                    return;

                //If new week we need to recalc SOME items
                CheckAndApplyNewWeek();

                //Start this "tick's" items
                CheckAndStartWorkItem();

                //Trace movement
                RebuildDebugProcessList();
            }
            catch (Exception ex)
            {
                this.EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                TraceLog.Log(ex);
            }
            finally
            {
                minuteTimer.Start();
            }
        }

        private bool StartDelayed()
        {
            try
            {
                if (startCounter < _serverInformation.StartupDelayInt)
                {
                    TraceLog.Log(string.Format("{0} start delayed. Now:{1},Delayed for:{2} ", Utilities.SERVICE_NAME, startCounter, _serverInformation.StartupDelayInt));
                    startCounter++;                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        
        private void CheckAndApplyNewWeek()
        {
            //this might cause problems ... lets see how it goes
            //so i fixed it with workitems.isnewweek.
            if //((Utilities.DateToMinuteOfWeek(DateTime.Now) == 0) ||
                /*(Utilities.DateToMinuteOfWeek(DateTime.Now) == 1) ||*/
                (_workItems.IsNewWeek)//)
            {
                _workItems.NewWeek();
                _threadList.CleanUpOldItems();
            }
        }

        private void CheckAndStartWorkItem()
        {
            if (IsUpdateAvailableAndWaiting)
                return;

            while (_workItems.NextRun() <= Utilities.DateToMinuteOfWeek(DateTime.Now))
            {
                //we going to run something so reset the wait time counter.
                waitingCounter = 0;
                
                //have to pop it first else because of the threads a million will start
                Type type = _workItems.Pop();

                if (_threadList.AcceptThread(type))
                {
                    //Create it
                    IRunnablePlugin irp = (IRunnablePlugin)Activator.CreateInstance(type);
                    irp.ServerInformation = _serverInformation;

                    //thread it
                    System.Threading.Thread t = new Thread(new ThreadStart(irp.InitAndStart));
                    _threadList.AddThread(type, t);
                    _threadList.StartThread(type);
                }
            }
        }

        private bool IsUpdateAvailableAndWaiting
        {
            get
            {
                lock (_serverInformation.UpdateReadyForInstallObj)
                {
                    if (_serverInformation.UpdateReadyForInstall)
                    {
                        TraceLog.Log("WaitingForUpdate is set, wait for control of service to apply update");

                        
                        if (_threadList.HasRunningThreadsOtherThan(Utilities.SERVICE_WAITFOR_TYPE_OTHER_THAN))
                        {
                            waitingCounter++;
                            //we cant wait any longer lets run tasks and try again later
                            if (_serverInformation.AutoUpdateWaitForServiceMax <= waitingCounter)
                            {
                                TraceLog.Log("Reached max waiting period for service. Going to force install now.");
                                _serverInformation.UpdateReadyForInstall = true;
                                Monitor.Pulse(_serverInformation.UpdateReadyForInstallObj);
                                waitingCounter = 0;
                                return false;
                            }
                            else
                                return true;
                        }
                        else
                        {
                            _serverInformation.UpdateReadyForInstall = true;
                            Monitor.Pulse(_serverInformation.UpdateReadyForInstallObj);
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        private void RunInTestMode()
        {
            TraceLog.Log(string.Format("Service Tests Passed: {0}",
            Utilities.DoOnSiteTests(_serverInformation).ToString()));
            this.Stop();
        }

    }
}
