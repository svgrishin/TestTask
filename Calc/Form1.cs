﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace Calc
{
    public partial class Form1 : Form
    {
        delegate void mrDeleg();
        mrDeleg mDeleg;


        public Calculator calc = new Calculator();
        public Calculator[] calcs = new Calculator[0];
        public HistoryForm hf;
        public MRForm mf;
        public Form1()
        {
            InitializeComponent();
            hf = new HistoryForm(this);
            mf = new MRForm(this);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            inputVal('1');
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            inputVal('2');
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            inputVal('3');
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            inputVal('4');
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            inputVal('5');
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            inputVal('6');
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            inputVal('7');
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            inputVal('8');
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            inputVal('9');
        }

        private void inputVal(char c)
        {
            label1.Text = calc.inputValues(c, this);
            setTextSize();
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") typeZeroComa();
            else label1.Text = calc.inputValues('0', this);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            resetCalc();
            Array.Clear(calc.args, 0, 1);
            label1.Text = "0";
        }

        private void btn_bspace_Click(object sender, EventArgs e)
        {
            label1.Text = calc.deleteSymbol();
            setTextSize();
        }

        private void btn_Negative_Click(object sender, EventArgs e)
        {
            calc.minus = !calc.minus;
            inputVal('-');
        }

        private void btn_Coma_Click(object sender, EventArgs e)
        {
            if (calc.arg.Contains(',') == false)
            {
                if (calc.arg == "")
                {
                    typeZeroComa();
                }
                else label1.Text = calc.inputValues(',', this);
            }
        }

        public void typeZeroComa()
        {
            label1.Text = calc.inputValues('0', this);
            label1.Text = calc.inputValues(',', this);
        }

        public void setTextSize()
        {
            float fSize = label1.Font.Size;
            float s = TextRenderer.MeasureText(label1.Text, label1.Font).Width;
            if (s > label1.Width)
            {
                while(label1.Width<s)
                {
                    fSize--;
                    label1.Font = new Font("Arial", fSize);
                    s= TextRenderer.MeasureText(label1.Text, label1.Font).Width;
                }
            }
            else
            
                while (label1.Width > s+fSize && label1.Font.Size<30)
                {
                    fSize++;
                    label1.Font = new Font("Arial", fSize);
                    s = TextRenderer.MeasureText(label1.Text, label1.Font).Width;
                }
            
        }

        private void btn_Func_Click(Calculator.funcDeleg f, bool isExtraFunc)
        {
            if (isExtraFunc == true)
            {
                label1.Text = calc.extraFunc(f);
                saveStatus();
                setTextSize();
            }
            else funcClick(f);
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            btn_click("+", new Calculator.CalcFunction().summ, false);
        }

        
        private void funcClick(Calculator.funcDeleg f)
        {
            calc.resBtnFlag = false;

            switch (calc.index)
            {
                case false:
                    {
                        calc.fDeleg = f;
                        calc.tryToGetArg(calc.arg);
                        calc.funcFlag = true;
                        break;
                    }
                case true:
                    {
                        calc.tryToGetArg(calc.arg);
                        calc.getResult(calc.fDeleg);
                        calc.funcFlag = true;
                        calc.fDeleg = f;
                        break;
                    }
            }

            label1.Text = calc.disp;
            calc.minus = false;
        }


        private void btn_click(string s, Calculator.funcDeleg f, bool isExtraFunc)
        {
            calc.symbol = s;

            if (calc.funcFlag == true)
            {
                calc.fDeleg = f;
                calc.resBtnFlag = false;
            }
            else
            {
                btn_Func_Click(f, isExtraFunc);
                setTextSize();
            }
        }
        
        private void btn_multiply_Click(object sender, EventArgs e)
        {
            btn_click("×", new Calculator.CalcFunction().multiply, false);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            btn_click("÷", new Calculator.CalcFunction().divide, false);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            btn_click("-", new Calculator.CalcFunction().differens, false);
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            calc.tryToGetArg(calc.arg);
            
            calc.resBtnFlag = true;
            calc.funcFlag = true;
            
            calc.getResult(calc.fDeleg);

            label1.Text = calc.disp;

            setTextSize();
        }

        private void btn_SQRT_Click(object sender, EventArgs e)
        {
            calc.symbol = "√";
            calc.fDeleg = new Calculator.CalcFunction().sqrtOf;
            btn_Func_Click(calc.fDeleg, true);
        }

        private void btn_SQR_Click(object sender, EventArgs e)
        {
            calc.symbol = "^";
            calc.fDeleg = new Calculator.CalcFunction().sqrOf;
            btn_Func_Click(calc.fDeleg, true);
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            mr_Click(mDeleg = new mrDeleg(getFromMR));
            
            getFromMR(calc.mr.Length-1);
            label1.Text = calc.arg;
        }

        private void mr_Click(mrDeleg md)
        {
            calc.mrFlag = true;
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, 1);
        }

        public void setMR(int indexOf, int negative)
        {
            try
            {
                calc.mr[indexOf] += calc.arg;
            }
            catch
            {
                calc.mr[indexOf] = calc.args[0].ToString();
                calc.arg = calc.mr[indexOf];
            }

            setMrList(indexOf);

            //calc.btnType = true;
            calc.funcFlag = true;
            calc.resBtnFlag = true;

            btn_MList.Enabled = true;
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            calc.mr = new string[1];
            btn_MList.Enabled = false;
            mf.listBox_MR.Items.Clear();
            switchMRButtons();
        }

        private void btn_MMinus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, -1);
        }

        private void btn_MS_Click(object sender, EventArgs e)
        {
            int l = calc.mr.Length - 1;

            if (calc.mr.Length > 0)
            {
                Array.Resize(ref calc.mr, l + 2);
                l++;
            }
            setMR(l, 1);
        }

        private void btn_MList_Click(object sender, EventArgs e)
        {
            mf.Left = Left + (Width - hf.Width) / 2;
            mf.Top = Top + (Height - hf.Height) / 2;
            mf.Show();
            Enabled = false;
            switchMRButtons();
        }

        public void setMrList(int indexOf)
        {
            try
            {
                mf.listBox_MR.Items[calc.mr.Length - 1] = calc.mr[indexOf];
            }
            catch
            {
                mf.listBox_MR.Items.Add(calc.mr[indexOf]);
            }
        }

        public void switchMRButtons()
        {
            btn_MR.Enabled = !btn_MR.Enabled;
            btn_MS.Enabled = !btn_MS.Enabled;
        }

        public void getFromMR(int indexOf)
        {
            ////вызов из памяти может произойти при двух обстоятельствах:
            ////  1.  Ожидание ввода второго аргумента при наличии первого
            ////  2.  Ожидание ввода первого аргумента (характерно для случаев
            ////      вызова памяти после "=")
            ////при случае 2 нужно подготовить калькулятор к заполнению с первого аргумента

            //short i = Convert.ToInt16(calc.index);


            //calc.args[i] = calc.mr[indexOf];

            ////if (calc.isResultPresent == false && calc.index == false) calc.resetFunc();

            //calc.index = !calc.index;
            //calc.btnType = false;

            //label1.Text = calc.displayOut(Convert.ToString(calc.args[i]));
            //calc.arg = "";

            calc.arg = calc.mr[indexOf];

        }

        private void listBox_MR_DoubleClick(object sender, EventArgs e)
        {
            int index = 
            getFromMR(mf.listBox_MR.SelectedIndex + 1);
            //calc.funcFlag = true;
            calc.resBtnFlag = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            calc.symbol = "1/";
            calc.fDeleg = new Calculator.CalcFunction().fraction;
            btn_Func_Click(calc.fDeleg, true);
        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            if (calcs.Length == 0)
            {
                string[] s = File.ReadAllLines("c:/temp/calc.json");
                int i = calcs.Length;
                foreach (string str in s)
                {
                    try
                    {
                        calcs[i] = JsonConvert.DeserializeObject<Calculator>(str);
                    }
                    catch
                    {
                        Array.Resize(ref calcs, i+1);
                        calcs[i] = JsonConvert.DeserializeObject<Calculator>(str);
                    }
                    hf.HistoryList.Items.Add(calcs[i].resultString);
                    i++;
                }
            }
            hf.Left = Left + (Width-hf.Width) / 2;
            hf.Top = Top + (Height-hf.Height) / 2;
            Enabled = false;
            hf.Show();
        }

        public void saveMe()
        {
            addCalc();
            try
            {
                saveCalc();
            }
            catch { this.Text = "Не удалось сохранить в файл"; }
        }

        public void loadMe(int i)
        {
            calc = new Calculator(calcs[i]);
            
            label1.Text = calc.displayOut(calc.disp);

            resetCalc();

            calc.arg = calc.args[0].ToString();
        }

        public void resetCalc()
        {
            calc.resetCalc();
            label1.Font = new Font("Arial", 30);
        }

        private void addCalc()
        {
            int i = calcs.Length;
            Array.Resize(ref calcs, i + 1);
            calcs[i] = new Calculator(calc);   
        }

        private void saveCalc()
        {
            Calculator c = new Calculator(calc);
            //c.calcFuncOf = null;
            //c.previousCalcFunc = null;
            c.fDeleg = null;
            
            string s = JsonConvert.SerializeObject(c);

            File.AppendAllText("c:/temp/calc.json", s + "\n");
        }

        private void addToCalcList(Calculator c)
        {
            hf.HistoryList.Items.Add(c.resultString);
            comboBox1.Items.Add(c.resultString);
        }

        private void getResult(Calculator.funcDeleg cf)
        {
            calc.getResult(cf);
            saveStatus();
        }

        private void saveStatus()
        {
            saveMe();
            if (calc.resultString != "") addToCalcList(calc);
            calc.resultString = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMe(comboBox1.SelectedIndex);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            setTextSize();
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            //setTextSize(); динамичное изменение размера шрифта, но выглядит не очень
        }
    }
}