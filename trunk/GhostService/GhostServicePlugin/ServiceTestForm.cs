using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GhostService.GhostServicePlugin
{
    public partial class ServiceTestForm : Form
    {
        public ServiceTestForm()
        {
            InitializeComponent();
        }

        public void Add(string comment)
        {
            lbStatus.Items.Add(comment);                        
        }

        public void Status(string comment)
        {
            tssLabel.Text = comment;
            ssStatus.Refresh();

        }
    }
}
