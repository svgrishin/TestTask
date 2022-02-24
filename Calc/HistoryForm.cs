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
    public partial class HistoryForm: Form
    {
        Form1 calcForm;
        public HistoryForm(Form1 f)
        {
            InitializeComponent();
            calcForm = f;
        }

        private void HistoryList_DoubleClick(object sender, EventArgs e)
        {
            calcForm.loadMe(HistoryList.SelectedIndex);
            calcForm.comboBox1.Items.Add(HistoryList.Items[HistoryList.SelectedIndex]);
            
            Close();
        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryList.Items.Clear();
            Visible = false;
            calcForm.Enabled = true;
            e.Cancel = true;
        }
    }
}
