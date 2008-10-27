namespace GhostConveyApplicationUpdateDescControl
{
    partial class DialogItemDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOK = new System.Windows.Forms.Button();
            this.tbSQL = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSQLResult = new System.Windows.Forms.TextBox();
            this.tbCompareResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(262, 226);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // tbSQL
            // 
            this.tbSQL.Location = new System.Drawing.Point(12, 83);
            this.tbSQL.Multiline = true;
            this.tbSQL.Name = "tbSQL";
            this.tbSQL.Size = new System.Drawing.Size(325, 72);
            this.tbSQL.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(115, 26);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(222, 20);
            this.tbName.TabIndex = 2;
            // 
            // tbSQLResult
            // 
            this.tbSQLResult.Location = new System.Drawing.Point(115, 161);
            this.tbSQLResult.Name = "tbSQLResult";
            this.tbSQLResult.Size = new System.Drawing.Size(222, 20);
            this.tbSQLResult.TabIndex = 3;
            // 
            // tbCompareResult
            // 
            this.tbCompareResult.Location = new System.Drawing.Point(115, 187);
            this.tbCompareResult.Name = "tbCompareResult";
            this.tbCompareResult.Size = new System.Drawing.Size(222, 20);
            this.tbCompareResult.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Descriptive Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SQL Result";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Compare Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SQL";
            // 
            // DialogItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 259);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCompareResult);
            this.Controls.Add(this.tbSQLResult);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbSQL);
            this.Controls.Add(this.btOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogItemDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Details";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TextBox tbSQL;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSQLResult;
        private System.Windows.Forms.TextBox tbCompareResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}