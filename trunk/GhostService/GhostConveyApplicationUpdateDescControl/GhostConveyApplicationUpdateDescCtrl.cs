using System;
using System.Windows.Forms;
using GhostService.GhostServicePlugin;
using System.IO;
using System.Reflection;

namespace GhostConveyApplicationUpdateDescControl
{
    public partial class GhostConveyApplicationUpdateDescCrl : UserControl
    {        
        public GhostConveyApplicationUpdateDescCrl()
        {
            InitializeComponent();
        }

        private string fileName;        

        private void btAdd_Click(object sender, EventArgs e)
        {

            using (DialogItemDetails did = new DialogItemDetails())
            {
                if (did.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(did.Description);
                    item.SubItems.Add(did.SQL);
                    item.SubItems.Add(did.SQLResult);
                    item.SubItems.Add(did.CompareResult);
                    lvChecks.Items.Add(item);
                }
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            
        }

        private void CreateOutputFile()
        {
            ApplicationUpdateDescription aud = new ApplicationUpdateDescription();

            foreach (ListViewItem lvi in lvChecks.Items)
            {
                if (lvi.Checked)
                    aud.Checks.Add(new UpdateCheck(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, (CheckType)Convert.ToInt32(lvi.SubItems[4].Text)));
            }
            aud.UserMessage = tbUserMessage.Text;

            aud.SaveToNewXML(fileName);
            //save is call when we change processed
            //aud.Processed = false;
        }

        private void HandleList(bool load)
        {
            ApplicationUpdateDescription aud = new ApplicationUpdateDescription();
            string filename = string.Concat(Assembly.GetExecutingAssembly().Location, ".xml");

            if (load)
            {
                if (File.Exists(filename))
                {
                    aud.Filename = filename;
                    foreach (UpdateCheck check in aud.Checks)
                    {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(check.CheckDescription);
                        item.SubItems.Add(check.Check);
                        item.SubItems.Add(check.PassResult);
                        item.SubItems.Add(Convert.ToInt32(check.TheCheckType).ToString());
                        lvChecks.Items.Add(item);
                    }
                    tbUserMessage.Text = aud.UserMessage;
                }                
            }
            else
            {
                foreach (ListViewItem lvi in lvChecks.Items)
                {
                    aud.Checks.Add(new UpdateCheck(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, (CheckType)Convert.ToInt32(lvi.SubItems[4].Text)));
                }
                aud.UserMessage = tbUserMessage.Text;

                aud.SaveToNewXML(filename);
                //save is call when we change processed
                //aud.Processed = false;
            }
        }

        private void GhostConveyApplicationUpdateDescCrl_Load(object sender, EventArgs e)
        {
            HandleList(true);
        }

        private void GhostConveyApplicationUpdateDescCrl_Leave(object sender, EventArgs e)
        {            
        }

        public void Close()
        {
            HandleList(false);
        }

        public void Close(string outputFilePath)
        {
            HandleList(false);
            fileName = Path.Combine(outputFilePath, "ApplicationUpdateDescription.xml");
            CreateOutputFile();
        }

        public void CreateOutputFile(string outputFilePath)
        {
            HandleList(false);
            fileName = Path.Combine(outputFilePath, "ApplicationUpdateDescription.xml");
            CreateOutputFile();
            //return fileName;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (lvChecks.SelectedItems.Count > 0)
            {

            }
        }

    }
}
