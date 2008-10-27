using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A runnable item that can be run by the service
    /// </summary>
    public class Runnable
    {

        //maybe in future, but only want to activate once i run it
        //public IRunnablePlugin runnablePlugin;

        private string assemblyPath;
        private int interval;
        private DateTime startDate;
        private bool calculateIntervalFromBase;
        private int minOfTheWeek;
        public int MinOfTheWeek
        {
            get { return minOfTheWeek; }
            set { minOfTheWeek = value; }
        }
        private Type assemblyType;
        public Type AssemblyType
        { get { return assemblyType; } }
        private PluginRunType runType;
        public PluginRunType RunType
        { get { return runType; } }

        public Runnable()
        { }
        public Runnable(int Interval, string AssemblyPath, Type AssemblyType, bool CalculateIntervalFromBase, PluginRunType runType)
        {
            this.interval = Interval;
            this.assemblyPath = AssemblyPath;
            this.assemblyType = AssemblyType;
            this.calculateIntervalFromBase = CalculateIntervalFromBase;
            this.runType = runType;
            this.minOfTheWeek = -1;

            TraceLog.Log(string.Format("Created runnable workitem: {0}.", AssemblyType.ToString()));
        }

        public void CalculateNewMinOfWeek()
        {            
            if (this.MinOfTheWeek == -1) //first calculate
            {
                if (this.calculateIntervalFromBase)
                {
                    this.minOfTheWeek = this.interval;
                    if (this.RunType == PluginRunType.OnceAWeek)
                    {
                        if (this.minOfTheWeek < Utilities.DateToMinuteOfWeek(DateTime.Now))
                            this.minOfTheWeek += Utilities.MINS_IN_WEEK;
                    }
                    else
                    {
                        while (this.minOfTheWeek < Utilities.DateToMinuteOfWeek(DateTime.Now))
                            this.minOfTheWeek += this.interval;
                    }
                }
                else
                    this.minOfTheWeek = Utilities.DateToMinuteOfWeek(DateTime.Now.AddMinutes((new Random()).Next(Utilities.MIN_RANDOM_SEED, Utilities.MAX_RANDOM_SEED)));
            }
            else //second ++ calculate
            {
                if (this.runType == PluginRunType.OnceAWeek) //cant be first calculate
                    this.minOfTheWeek += Utilities.MINS_IN_WEEK;
                else  //lets use Utils here iso just "incrementing" it
                    this.minOfTheWeek = Utilities.DateToMinuteOfWeek(DateTime.Now) + this.interval;
            }

            TraceLog.Log(string.Format("Calculated runnable {0} runtime at: {1}.", this.AssemblyType.ToString(),MinOfTheWeek.ToString()));
        }

        public void ResetMinOfWeek()
        {
            TraceLog.Log(string.Format("Reset runnable {0} runtime.", this.AssemblyType.ToString()));
            this.MinOfTheWeek = -1;
            CalculateNewMinOfWeek();            
        }

        public string ToString()
        {
            return String.Format("Key:{0},Key to date:{1},Interval:{2},Calc Interval from base:{3},Run type:{6},Assembly Type:{5},Assembly Path:{4}",
                MinOfTheWeek, Utilities.MinuteOfWeekToDate(MinOfTheWeek).ToString(), interval, calculateIntervalFromBase,
                assemblyPath, AssemblyType.ToString(), runType.ToString());
        }

        public List<string> ToCollection()
        {
            List<string> items = new List<string>();

            items.Add(MinOfTheWeek.ToString());
            items.Add(Utilities.MinuteOfWeekToDate(MinOfTheWeek).ToString());
            items.Add(interval.ToString());
            items.Add(calculateIntervalFromBase.ToString());
            items.Add(runType.ToString());
            items.Add(AssemblyType.ToString());
            items.Add(assemblyPath);

            return items;
        }
    }

}
