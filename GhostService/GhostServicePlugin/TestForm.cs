using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// Form used for testing. Closes itself in specified seconds. 
    /// </summary>
    internal class TestForm : Form
    {
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbl2;
        public int MaxTime;

        public TestForm(int maxTime, string title, string message)
            : base ()
        {
            this.Load += OnLoad;

            this.Height = 100;
            this.Width = 400;
            this.Text = title;
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(Ticked);

            MaxTime = maxTime;

            lbl = new Label();
            lbl.Text = "0";
            lbl.Parent = this;
            lbl.Top = 25;
            lbl.Left = 5;

            lbl2 = new Label();
            lbl2.Text = message;
            lbl2.Parent = this;
            lbl2.Top = 5;
            lbl2.Left = 5;
        }

        public void OnLoad(object sender, EventArgs e)
        {
            tmr.Start();
        }

        private void Ticked(object sender, EventArgs e)
        {
            if (0 == MaxTime)
                this.Close();
            else
                MaxTime -= 1;

            lbl.Text = MaxTime.ToString();
        }

    }

}
