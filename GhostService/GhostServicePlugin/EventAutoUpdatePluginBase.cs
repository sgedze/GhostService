using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Korbitec.AutoUpdate.ClientUpdates;

namespace GhostService.GhostServicePlugin
{
    public class EventAutoUpdatePluginBase : BasePartialVisualPlugin
    {
        protected bool windowedInstance = false;

        #region AutoUpdate Event Handlers

        // NOTE: All the Invoke calls are necessary to prevent UI
        // CrossThreadExceptions

        protected void updater_DownloadFailed(object sender, ActionFailedEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status("Download Failed!");
                }
            ));
        }
        protected virtual void updater_DownloadComplete(object sender, ActionCompleteEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status("Download Complete!");
                }
            ));
        }
        protected void updater_DownloadProgress(object sender, ProgressEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status((int)e.Progress, 0);
                }
            ));
        }
        protected void updater_DownloadSize(object sender, ProgressEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status(0, (int)e.Progress);
                }
            ));
        }
        protected void updater_UpdateComplete(object sender, ActionCompleteEventArgs e)
        {
            Invoke(new CrossAppDomainDelegate(
                delegate()
                {
                    Status("The application must be restarted to finalise the application update.");
                }
            ));
        }

        #endregion

        protected virtual void StatusToLabel(string status)
        { }

        protected virtual void StatusToLabel(string status, string statusNextLine)
        { }

        protected virtual void ProgressToBar(int position, int fullsize)
        { }

        protected void Status(string status)
        {
            if (windowedInstance)
                StatusToLabel(status);

            LogMessageToTrace(string.Concat("Status: ", status));
        }

        protected void Status(string status, string statusnextLine)
        {
            if (windowedInstance)
                StatusToLabel(status, statusnextLine);

            LogMessageToTrace(string.Concat("Status: ",status," ",statusnextLine));
        }

        protected void Status(int position, int fullposition)
        {
            if (windowedInstance)
                ProgressToBar(position, fullposition);

            LogMessageToTrace(string.Concat("Status: pos ",position.ToString(), " fullpos ", fullposition.ToString()));
        }
    }
}
