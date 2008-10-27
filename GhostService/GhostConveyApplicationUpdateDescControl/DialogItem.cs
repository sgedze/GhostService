using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GhostConveyApplicationUpdateDescControl
{
    public partial class DialogItemDetails : Form
    {
        public DialogItemDetails()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string Description
        {
            get
            { return tbName.Text; }
        }
        public string SQL
        {
            get
            { return tbSQL.Text; }
        }        
        public string CompareResult
        {
            get
            { return tbCompareResult.Text; }
        }
        public string SQLResult
        {
            get
            { return tbSQLResult.Text; }
        }
    }
}
