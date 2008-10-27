using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Used to keep track of threads. 
    /// </summary>
    public class ThreadList
    {
        private Dictionary<Type, ThreadWorker> threadList;
        public string TraceFileName
        { get; set; }

        public ThreadList()
        {
            threadList = new Dictionary<Type, ThreadWorker>();
        }

        public bool AcceptThread(Type key)
        {
            bool Success = true;

            if (threadList.ContainsKey(key))
            {
                if (threadList[key] != null)
                    Success &= (!threadList[key].IsRunning);
                /*else
                    Success &= (threadList[key] == null);*/
            }

            //might need other checks here

            return Success;
        }

        public void AddThread(Type key, Thread thread)
        {
            if (threadList.ContainsKey(key))
                threadList[key].AddThread(thread);
            else
                threadList.Add(key, new ThreadWorker(thread));
        }

        public void StartThread(Type key)
        {
            threadList[key].Start();
        }

        public string ToString()
        {
            string strList = "";

            foreach (Type type in threadList.Keys)
            {
                strList += string.Format("Key:{0}, {1}\r", type.ToString(), threadList[type].ToString());
            }
            return strList;
        }
        
        public List<List<string>> ToCollection()
        {
            List<List<string>> items = new List<List<string>>();
            List<string> item;

            foreach (Type key in threadList.Keys)
            {
                item = threadList[key].ToCollection();
                item.Add(key.ToString());
                items.Add(item);
            }

            return items;
        }

        public void CleanUpOldItems()
        {
            CleanUpList(Utilities._DefaultThreadTimeSpan);
        }

        private void CleanUpList(TimeSpan MaxAge)
        {
            List<Type> threadsToDelete = new List<Type>();

            foreach (Type type in threadList.Keys)
            {
                if (threadList[type].IsRunningFor(MaxAge))
                {
                    threadsToDelete.Add(type);
                    continue;
                }

                if (threadList[type].IsOlder(Utilities._DefaultThreadWorkerTimeSpan))
                    threadsToDelete.Add(type);
            }

            foreach (Type type in threadsToDelete)
            {
                if (threadList[type].IsRunning)
                    threadList[type].Abort();
                //threadList[s] = null;
                threadList.Remove(type);
                TraceLog.Log(string.Concat("Attempted to remove old thread ", type.ToString()), TraceFileName);
            }
        }

        public int ThreadCount
        { get { return threadList.Count; } }

        public void KillThreadsNow()
        {
            foreach (Type type in threadList.Keys)
            {
                threadList[type].Abort();
                TraceLog.Log(string.Format("Attempting to abort thread {0} ", type.ToString()), TraceFileName);
            }
        }

        public bool HasRunningThreads
        {
            get 
            {
                return HasRunningThreadsOtherThan("");
            }
        }

        public bool HasRunningThreadsOtherThan(string type)
        { 
            foreach (Type t in threadList.Keys)
            {
                if (t.Name == type)
                    continue;

                if (threadList[t].IsRunning)
                    return true;
            }

            return false;
        }

        /* testing
        public void testthreadrefresh()
        {
            //for (int i = threadList.Count-1; i >= 0; i--)

            List<string> threadsToDelete = new List<string>();
            foreach (string s in threadList.Keys)
            {                
                if (threadList[s].IsOlder(Utilities._59Secs))
                {
                    if (!threadList[s].IsRunning)
                        threadsToDelete.Add(s);      
                }

            }

            foreach (string s in threadsToDelete)
            {
                threadList[s].Abort();
                threadList[s] = null;
                threadList.Remove(s);
            }
        
        }*/
    }

}
