using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Used in threadlist as a single item.
    /// </summary>
    internal class ThreadWorker
    {
        private Thread thread;
        private DateTime startDate;
        private DateTime addDate;

        public ThreadWorker(Thread thread)
        {
            this.addDate = DateTime.Now;
            this.thread = thread;
        }

        public int RunMinutes
        {
            get
            {
                TimeSpan timediff = DateTime.Now.Subtract(startDate);

                return (int)timediff.TotalMinutes;
            }
        }

        public int RunDays
        {
            get
            {
                TimeSpan timediff = DateTime.Now.Subtract(startDate);

                return (int)timediff.TotalDays;
            }
        }

        public bool IsOlder(TimeSpan timespan)
        {
            return (DateTime.Now.Subtract(startDate).TotalSeconds >= timespan.TotalSeconds);
        }

        public bool IsRunningFor(TimeSpan timespan)
        {
            return (this.IsRunning && (DateTime.Now.Subtract(startDate).TotalMilliseconds >= timespan.TotalMilliseconds));
        }

        public bool IsRunningSince(DateTime datetime)
        {
            return (this.IsRunning && (startDate >= datetime));
        }

        public bool IsRunning
        {
            get { return (thread.ThreadState == System.Threading.ThreadState.Running); }
        }

        public void Start()
        {
            this.startDate = DateTime.Now;
            this.thread.Start();
        }

        public System.Threading.ThreadState ThreadState
        {
            get { return this.thread.ThreadState; }
        }

        public void AddThread(Thread thread)
        {
            this.thread = thread;
        }

        public string ToString()
        {
            return string.Format("Date added:{0}, Date started:{1}, Thread:{2}, ThreadState:{3}", addDate.ToString(), startDate.ToString(), thread.ToString(), thread.ThreadState.ToString());
        }

        public List<string> ToCollection()
        {
            List<string> items = new List<string>();

            items.Add(addDate.ToString());
            items.Add(startDate.ToString());
            items.Add(thread.ThreadState.ToString());

            return items;
        }

        public void Abort()
        {
            this.thread.Abort();
            //AppDomain ad = this.thread.GetDomain();            
        }
    }
}
