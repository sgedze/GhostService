using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A collection of runnable items sorted by time (min of week) implemented as 
    /// a sorted stack
    /// </summary>
    public class WorkItems
    {
        private List<Runnable> _workItems;
        private DateTime _workListForWeekStarting;

        public WorkItems()
        {
            _workItems = new List<Runnable>();
            _workListForWeekStarting = Utilities.GetDateOfPastSundayMorning();
        }

        public int NextRun()
        {
            if (_workItems.Count == 0)
                return Utilities.MINS_IN_WEEK + 1;
            else
                return _workItems[0].MinOfTheWeek;
        }

        public Type Pop()
        {
            //"reschedule" task if need be
            Runnable r = _workItems[0];
            Type type = r.AssemblyType;
            _workItems.Remove(_workItems[0]);

            //probably just need to recalc time here
            if (r.RunType != PluginRunType.OnceOnly)
                Add(r);

            return type;
        }

        public void Add(Runnable runnable)
        {
            try
            {
                runnable.CalculateNewMinOfWeek();
                _workItems.Add(runnable);
                _workItems.Sort(CompareRunnablesByTime);
                TraceLog.Log(string.Format("Added runnable to workitemlist:{0}, to run at: {1}.", runnable.AssemblyType.ToString(), runnable.MinOfTheWeek));
            }
            catch (Exception e)
            {
                TraceLog.Log(e);
            }            
        }

        private int CompareRunnablesByTime(Runnable x, Runnable y)
        {
            if ((x == null) || (y == null))
                return 0;

            if (x.MinOfTheWeek < y.MinOfTheWeek)
                return -1;
            else
                return 1;
        }

        public void Add(IRunnablePlugin runnablePlugin, string AssemblyPath, Type AssemblyType)
        {
            TraceLog.Log(string.Format("Will attempt creation and scheduling: {0}.",AssemblyType.ToString()));

            if (runnablePlugin.PluginActive)
            {
                TraceLog.Log(string.Format("{0} is active plugin.", AssemblyType.ToString()));
                Runnable r = new Runnable(runnablePlugin.Interval, AssemblyPath,
                        AssemblyType, runnablePlugin.CalculateIntervalFromBase,
                        runnablePlugin.RunType);
                Add(r);
            }
        }

        public string ToString()
        {
            string runList = "";
            foreach (Runnable runnable in _workItems)
            {
                runList += string.Concat(runnable.ToString(), "\n");
            }
            return runList;
        }

        public List<List<string>> ToCollection()
        {
            List<List<string>> items = new List<List<string>>();

            foreach (Runnable runnable in _workItems)
                items.Add(runnable.ToCollection());

            return items;
        }

        public bool IsNewWeek
        {
            get
            {
                //new week starts on a Sunday, work out if it is a new week relative to last recalc                

                //atleast 5 day difference
                bool isNewWeek = (DateTime.Now.Subtract(_workListForWeekStarting).TotalDays > 5);

                //so is it the next Sunday
                if (isNewWeek)
                    isNewWeek = (DateTime.Now.DayOfWeek == DayOfWeek.Sunday);

                if (isNewWeek)
                    TraceLog.Log(string.Format("New week, Listdate: {0}, Currentdate: {1}", _workListForWeekStarting.ToString(), DateTime.Now.ToString()));
                
                return isNewWeek;
            }
        }

        public void NewWeek()
        {
            int prevMinOfTheWeek;

            for (int i = 0; i < _workItems.Count; i++)
            {
                prevMinOfTheWeek = _workItems[i].MinOfTheWeek;

                if (_workItems[i].MinOfTheWeek >= Utilities.MINS_IN_WEEK)
                {
                    _workItems[i].MinOfTheWeek = _workItems[i].MinOfTheWeek % Utilities.MINS_IN_WEEK;                   
                }
                else
                { 
                    //waiting for update, probably
                    //while (_workItems[i].MinOfTheWeek < Utilities.MINS_IN_WEEK)
                    //    _workItems[i].CalculateNewMinOfWeek();

                    _workItems[i].ResetMinOfWeek();
                }
                TraceLog.Log(string.Format("New week: {0} recalculated from {2} to {1}", _workItems[i].AssemblyType.ToString(), _workItems[i].MinOfTheWeek.ToString(), prevMinOfTheWeek));
            }
            
            _workListForWeekStarting = Utilities.GetDateOfPastSundayMorning();
            
            //need to resort list
            _workItems.Sort(CompareRunnablesByTime);

            TraceLog.Log(string.Format("New week starting date: {0}", _workListForWeekStarting.ToString()));
        }

        public int ItemCount
        { get { return _workItems.Count; } }
    }
}
