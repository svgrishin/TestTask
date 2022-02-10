using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class MRForm : Form
    {
        public Form1 mainForm;
        
        public MRForm(Form1 f)
        {
            mainForm = f;
            InitializeComponent();  
        }

        private void listBox_MR_DoubleClick(object sender, EventArgs e)
        {
            mainForm.getFromMR(listBox_MR.SelectedIndex + 1);
            this.Visible = false;
            mainForm.Enabled = true;
        }
    }
}
