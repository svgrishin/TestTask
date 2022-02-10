namespace Calc
{
    partial class MRForm
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
            this.listBox_MR = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_MR
            // 
            this.listBox_MR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_MR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_MR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_MR.FormattingEnabled = true;
            this.listBox_MR.IntegralHeight = false;
            this.listBox_MR.ItemHeight = 31;
            this.listBox_MR.Location = new System.Drawing.Point(0, 0);
            this.listBox_MR.Name = "listBox_MR";
            this.listBox_MR.Size = new System.Drawing.Size(273, 330);
            this.listBox_MR.TabIndex = 4;
            this.listBox_MR.DoubleClick += new System.EventHandler(this.listBox_MR_DoubleClick);
            // 
            // MRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 330);
            this.Controls.Add(this.listBox_MR);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MRForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MRForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MRForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBox_MR;
    }
}