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
            label1.Text = calc.inputValues('1', this);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('2', this);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('3', this);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('4', this);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('5', this);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('6', this);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('7', this);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('8', this);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('9', this);
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") typeZeroComa();
            else label1.Text = calc.inputValues('0', this);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            calc.resetCalc();
            Array.Clear(calc.args, 0, 1);
            calc.resetFunc();
            label1.Text = "0";
        }

        private void btn_bspace_Click(object sender, EventArgs e)
        {
            label1.Text = calc.deleteSymbol();
        }

        private void btn_Negative_Click(object sender, EventArgs e)
        {
            calc.minus = !calc.minus;
            label1.Text = calc.inputValues('-', this);
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

        private void btn_Func_Click(int i, Calculator.funcDeleg f, object sender, bool isExtraFunc)
        {
            calc.functions[0] = i;
            calc.functions[1] = i;

            calc.previousCalcFunc = calc.calcFuncOf;

            if (isExtraFunc == true) label1.Text = calc.extraFunc(f);
            else funcClick(f, sender);
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            calc.symbol = "+";
            calc.fDeleg = calc.calcFuncOf.summ;
            btn_Func_Click(1, calc.fDeleg, sender, false);
        }

        private void resetResultGetting()
        {
            calc.index = false;
            calc.isResultPresent = false;// это нужно, чтобы аргументы не сбрасывались при замене функции на горячую
        }
        
        private void funcClick(Calculator.funcDeleg f, object sender)
        {
            //когда ввод первого аргумента, потом ввод функции, а потом замена функций
            if (calc.btnType != false)
            {
                if (f != calc.fDeleg)
                    resetResultGetting();

                if (calc.fDeleg == f && calc.arg != "")
                    calc.index = true;//это нужно для того, чтобы при смене функции на горячую результат выдавался сразу при вызове результирующей функции

                if (calc.btnType == false && calc.index == true && f == calc.fDeleg)
                    resetResultGetting();
            }

            calc.resultBtnCheck(f);
            calc.tryToGetArg(calc.arg);

            //index = метка, по которой определяется, какой аргумент заполнять, 0-й или 1-й
            //в конце заполнения аргумента индекс переключается на противоположный
            //соответсвенно,
            //если индекс 1, то 1-й аргумент пустой, нужно запомнить функцию и заполнить 1-й аргумент в дальнейшем
            //если индекс 0, то оба аргумента заполнены и нужно вычислить результат в дальнейшем
            switch (calc.index)
            {
                case true: calc.fDeleg = f; break;
                //есть вероятность, что подряд будут нажаты несколько функций
                //глобальной переменной функции присваивается значение только после успешного выполнения функции
                //всегда следует пытаться выполнить функцию, согласно глобальной переменной,
                //так как обращение к процедуре может быть из кнопки "="
                //если функция изменилась, то глобальная переменная сбрасывается
                //и ожидается успешное выполнение новой функции
                case false:
                    {
                        try
                        {
                            getResult(calc, calc.fDeleg);
                        }
                        catch
                        {
                            try
                            {
                                getResult(calc, f);
                            }
                            catch
                            {
                                calc.getResult(calc.fDeleg);
                            }
                        }
                        label1.Text = calc.disp;
                        calc.fDeleg = f;
                    }
                    break;
            }
            calc.arg = "";
            calc.btnType = true;
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            calc.symbol = "×";
            calc.fDeleg = calc.calcFuncOf.multiply;
            btn_Func_Click(3, calc.fDeleg, sender, false);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            calc.symbol = "÷";
            calc.fDeleg = calc.calcFuncOf.divide;
            btn_Func_Click(4, calc.fDeleg, sender, false);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            calc.symbol = "-";
            calc.fDeleg = calc.calcFuncOf.differens;
            btn_Func_Click(2, calc.fDeleg, sender, false);
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            //есть правило, что получить результат можно
            //только если ранее результат не был получен.
            //Это правило изначально было для арифметических кнопок,
            //так как такие кнопки выполняют либо запоминание функции
            //либо получение результата
            //Кнопка "=" уникальна тем,
            //что возвращает только результат без попытки получить аргумент
            //стандартным способом. Аргумент получается в обход стандартного метода

            calc.isResultBtn = false;

            //Если "=" нажато после кнопки функции и ранее не был получен результат то необходимо
            //пройти в обход стандартного метода,
            //получить аргументы принудительно,
            //а затем принудительно вычислить результат

            if (calc.btnType == true)
            {
                calc.args[1] = calc.args[0];
                getResult(calc, calc.fDeleg);
                label1.Text = calc.disp;
            }
            //Если "=" нажато после цифры или уже был получен результат
            //то обрабатывать стандартным методом
            else
            {
                funcClick(calc.fDeleg, sender);
                calc.isResultBtn = true;
            }
            calc.index = false;
            calc.isResultPresent = true;

            calc.btnType = false;

            calc.previousCalcFunc = calc.calcFuncOf;
        }

        private void btn_SQRT_Click(object sender, EventArgs e)
        {
            calc.symbol = "√";
            calc.fDeleg = calc.calcFuncOf.sqrtOf;
            btn_Func_Click(5, calc.fDeleg, sender, true);
        }

        private void btn_SQR_Click(object sender, EventArgs e)
        {
            calc.symbol = "^";
            calc.fDeleg = calc.calcFuncOf.sqrOf;
            btn_Func_Click(6, calc.fDeleg, sender, true);
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            getFromMR(calc.mr.Length-1);
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, 1);
        }

        public void setMR(int indexOf, int negative)
        {
            try
            {
                calc.mr[indexOf] += Convert.ToDouble(calc.arg) * negative;
            }
            catch
            {
                calc.mr[indexOf] = calc.args[0];
                calc.arg = Convert.ToString(calc.mr[indexOf]);
            }

            setMrList(indexOf);

            calc.btnType = true;
            btn_MList.Enabled = true;
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            calc.mr = new double[1];
            btn_MList.Enabled = false;
            //listBox_MR.Visible = false;
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
            //вызов из памяти может произойти при двух обстоятельствах:
            //  1.  Ожидание ввода второго аргумента при наличии первого
            //  2.  Ожидание ввода первого аргумента (характерно для случаев
            //      вызова памяти после "=")
            //при случае 2 нужно подготовить калькулятор к заполнению с первого аргумента

            short i = Convert.ToInt16(calc.index);

            calc.resultPresentCheck();

            //calc.args[i] = calc.mr[indexOf];
            calc.args[i] = calc.mr[indexOf];

            if (calc.isResultPresent == false && calc.index == false) calc.resetFunc();

            calc.index = !calc.index;
            calc.btnType = false;

            label1.Text = calc.displayOut(Convert.ToString(calc.args[i]));
            calc.arg = "";
        }

        private void listBox_MR_DoubleClick(object sender, EventArgs e)
        {
            getFromMR(mf.listBox_MR.SelectedIndex + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 7;
            calc.functions[1] = 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            hf.Left = Left + (Width-hf.Width) / 2;
            hf.Top = Top + (Height-hf.Height) / 2;
            Enabled = false;
            hf.Show();
        }

        public void saveMe()
        {
            addCalc();
            saveCalc();
        }

        public void loadMe(int i)
        {
            calc = new Calculator(calcs[i]);
            label1.Text = calc.displayOut(calc.disp);
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
            c.calcFuncOf = null;
            c.previousCalcFunc = null;
            
            string s = JsonConvert.SerializeObject(c);

            File.AppendAllText("c:/temp/user.json", s + "\n");
        }

        private void addToCalcList()
        {
            hf.HistoryList.Items.Add(calc.resultString);
            comboBox1.Items.Add(calc.resultString);
        }

        private void getResult(Calculator c, Calculator.funcDeleg cf)
        {
            calc.getResult(cf);
            saveMe();
            if (calc.resultString!="") addToCalcList();
            calc.resultString = "";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}