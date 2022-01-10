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

        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            funcClick(calc.summ);
        }

        private void funcClick(Func<double> f)
        {
            if (calc.calcFunc != f)
            {
                calc.getArgs(calc.calcFunc);
                
                calc.calcFunc = f;
            }
            else calc.getArgs(f);

            label1.Text = calc.displayOut(calc.disp);
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            funcClick(calc.multiply);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            funcClick(calc.divide);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            funcClick(calc.differens);
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            calc.resultBtn();
            label1.Text = calc.displayOut(calc.disp);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_SQRT_Click(object sender, EventArgs e)
        {
            funcClick(calc.powerOf);
            
            //calc.resultBtn();
            //calc.resultBtn();
        }
    }
}
