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
    public partial class Form1 : Form
    {
        Calculator calc = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('1');
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('2');
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('3');
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('4');
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('5');
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('6');
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('7');
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('8');
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('9');
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") label1.Text = calc.inputValues("0,");
            else label1.Text = calc.inputValues('0');
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            calc.resetArgs();
            Array.Clear(calc.args, 0, 1);
            calc.calcFunc = null;
            label1.Text = "0";
        }

        private void btn_bspace_Click(object sender, EventArgs e)
        {
            label1.Text = calc.deleteSymbol();
        }

        private void btn_Negative_Click(object sender, EventArgs e)
        {
            calc.minus = !calc.minus;
            label1.Text = calc.inputValues("-");
        }

        private void btn_Coma_Click(object sender, EventArgs e)
        {
            if (calc.arg.Contains(',') == false)
            {
                if (calc.arg == "") label1.Text = calc.inputValues("0,");
                else label1.Text = calc.inputValues(',');
            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            funcClick(calc.summ, sender);
        }

        private void funcClick(Func<double> f, object sender)
        {
            if (f != calc.calcFunc)
            {
                calc.args[1] = calc.args[0];
                if (calc.calcFunc != null) calc.index = true;
            }

            if (calc.calcFunc == f && calc.arg != "") calc.index = true;

            calc.resultBtnCheck(f);
            
            calc.tryToGetArg(calc.arg);

            switch (calc.index)
            {
                case true:
                    {
                        calc.calcFunc = f;
                    }
                    break;
                case false:
                    {
                        try
                        {
                            calc.getResult(calc.calcFunc);
                        }
                        catch
                        {
                            calc.getResult(f);
                        }
                        label1.Text = calc.disp;
                        calc.calcFunc = f;
                    }
                    break;
            }
            calc.arg = "";

            calc.btnType = true;
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            funcClick(calc.multiply, sender);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            funcClick(calc.divide, sender);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            funcClick(calc.differens, sender);
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            calc.isResultBtn = false;

            if (calc.btnType == true && calc.isResultPresent!= true)
            {
                calc.args[1] = calc.args[0];                
                calc.getResult(calc.calcFunc);
                label1.Text = calc.disp;
            }
            else
            {
                funcClick(calc.calcFunc, sender);
                calc.isResultBtn = true;
            }
            calc.index = false;
            calc.isResultPresent = true;
        }

        private void btn_SQRT_Click(object sender, EventArgs e)
        {
            calc.extraFunc(calc.sqrtOf);
            label1.Text = calc.displayOut(calc.disp); 
        }

        private void btn_SQR_Click(object sender, EventArgs e)
        {
            calc.extraFunc(calc.sqrOf);
            label1.Text = calc.displayOut(calc.disp);
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            short i = Convert.ToInt16(calc.index);
            calc.resPresCheck();

            int l = calc.args.Length - 1;
            calc.args[i] = calc.mr2[l];

            if (calc.isResultPresent == false && calc.index == false) calc.calcFunc = null;
            calc.index = !calc.index;

            calc.btnType = false;

            label1.Text = calc.displayOut(Convert.ToString(calc.args[i]));
            calc.arg = "";
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            getMR(calc.mr2.Length - 1);
            //btn_MList.Enabled = true;
        }

        public void getMR(int indexOf)
        {
            try
            {
                calc.mr2[indexOf] += Convert.ToDouble(calc.arg);
            }
            catch
            {
                calc.mr2[indexOf] = calc.args[0];
                calc.arg = Convert.ToString(calc.mr2[indexOf]);
            }

            calc.btnType = true;

            setMrList(indexOf);

            this.Text = Convert.ToString(calc.mr2[indexOf]);

            btn_MList.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            calc.mr2 = new double[1];
            btn_MList.Enabled = false;
            listBox_MR.Visible = false;
            listBox_MR.Items.Clear();
            switchMRButtons();
        }

        private void btn_MMinus_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") calc.mr -= Math.Abs(calc.args[0]);
            else
            {
                calc.mr -= Math.Abs(Convert.ToDouble(calc.arg));
                calc.args[0] = calc.mr;
            }

            calc.arg = "";
            calc.index = true;

            this.Text = Convert.ToString(calc.mr);
        }

        private void btn_MS_Click(object sender, EventArgs e)
        {
            int l = calc.mr2.Length-1;
            if (calc.mr2.Length > 0)
            {
                Array.Resize(ref calc.mr2, l + 2);
                l++;
            }
            getMR(l);
        }

        private void btn_MList_Click(object sender, EventArgs e)
        {
            listBox_MR.Visible = !listBox_MR.Visible;
            switchMRButtons();
        }

        public void setMrList(int indexOf)
        {
            this.listBox_MR.Items.Add(calc.mr2[indexOf]);
        }

        public void switchMRButtons()
        {
            btn_MR.Enabled = !btn_MR.Enabled;
            btn_MS.Enabled = !btn_MS.Enabled;
        }
    }
}

