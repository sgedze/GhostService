using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Used as a trace log, apparently with static TraceListener it is thread safe
    /// </summary>
    public static class TraceLog
    {
        private static TextWriterTraceListener textWriterTraceListener;

        public static string traceLogFileName;
        public static string TraceLogFileName
        {
            get { return traceLogFileName; }
            set { traceLogFileName = value; }
        }
        
        public static void Log(string msgToLog, string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return;

            if (textWriterTraceListener == null)
            {
                textWriterTraceListener = new TextWriterTraceListener(filename);
                Trace.Listeners.Add(textWriterTraceListener);
                Trace.AutoFlush = true;
            }
            Trace.WriteLine(string.Format("{0} : {1}", DateTime.Now.ToString(), msgToLog));
            Trace.WriteLine("");
        }

        public static void Log(string traceMsg)
        {
            Log(traceMsg, traceLogFileName);
        }
        public static void Log(Exception exception)
        {
            Log(exception.ToString(), traceLogFileName);
        }

    }
}
