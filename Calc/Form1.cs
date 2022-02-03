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
//using Newtonsoft.Json.Serialization;
using System.IO;


namespace Calc
{
    public partial class Form1 : Form
    {
        public static Calculator calc = new Calculator();
        public static Calculator[] calcs = new Calculator[0];
        public HistoryForm hf = new HistoryForm();
        public Form1()
        {
            InitializeComponent();
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
            label1.Text = calc.inputValues('5',this);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('6',this);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('7',this);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('8',this);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            label1.Text = calc.inputValues('9',this);
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") typeZeroComa();
            else label1.Text = calc.inputValues('0',this);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            calc.resetCalc();
            Array.Clear(calc.args, 0, 1);
            calc.resetFunc();
            label1.Text = "0";

            saveMe();
        }

        private void btn_bspace_Click(object sender, EventArgs e)
        {
            label1.Text = calc.deleteSymbol();
            saveMe();
        }

        private void btn_Negative_Click(object sender, EventArgs e)
        {
            calc.minus = !calc.minus;
            label1.Text = calc.inputValues('-',this);
        }

        private void btn_Coma_Click(object sender, EventArgs e)
        {
            if (calc.arg.Contains(',') == false)
            {
                if (calc.arg == "")
                {
                    typeZeroComa();
                }
                else label1.Text = calc.inputValues(',',this); 
            }
        }

        public void typeZeroComa()
        {
            label1.Text = calc.inputValues('0',this);
            label1.Text = calc.inputValues(',',this);
            saveMe();
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 1;
            calc.functions[1] = 1;
            calc.previousCalcFunc = calc.summ;
            //funcClick(calc.summ, sender);
            funcClick(calc.summ, sender, '+');
        }

        private void funcClick(Func<double> f, object sender, char c)
        {
            CalcFunction cf = new CalcFunction(c, f);

            //if (f != calc.calcFunc)
            //{
            //    calc.args[1] = calc.args[0];
            //    if (calc.calcFunc != null) calc.index = true;// это нужно, чтобы аргументы не сбрасывались при замене функции на горячую
            //}

            //if (calc.calcFunc == f && calc.arg != "") calc.index = true;//это нужно для того, чтобы при смене функции на горячую результат выдавался сразу при вызове результирующей функции



            //calc.resultBtnCheck(f);

            if (cf != calc.calcFuncOf)
            {
                calc.args[1] = calc.args[0];
                if (calc.calcFuncOf != null) calc.index = true;// это нужно, чтобы аргументы не сбрасывались при замене функции на горячую
            }

            if (calc.calcFuncOf == cf && calc.arg != "") calc.index = true;//это нужно для того, чтобы при смене функции на горячую результат выдавался сразу при вызове результирующей функции


            calc.resultBtnCheck(cf.functionOf);


            calc.tryToGetArg(calc.arg);

            //index = метка, по которой определяется, какой аргумент заполнять, 0-й или 1-й
            //в конце заполнения аргумента индекс переключается на противоположный
            //соответсвенно,
            //если индекс 1, то 1-й аргумент пустой, нужно запомнить функцию и заполнить 1-й аргумент в дальнейшем
            //если индекс 0, то оба аргумента заполнены и нужно вычислить результат в дальнейшем
            switch (calc.index)
            {
                case true: calc.calcFuncOf = cf;break;
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
                            //calc.getResult(calc.calcFunc);
                            calc.getResult(calc.calcFuncOf.functionOf);
                        }
                        catch
                        {
                            try
                            {
                                //calc.getResult(f);
                                calc.getResult(cf.functionOf);
                            }
                            catch
                            {
                                //calc.getResult(calc.previousCalcFunc);
                                calc.getResult(calc.previousCalcFunc);
                            }
                        }
                        label1.Text = calc.disp;
                        calc.calcFunc = f;
                    }
                    break;
            }
            calc.arg = "";
            calc.btnType = true;

            saveMe();
            

        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 3;
            calc.functions[1] = 3;
            calc.previousCalcFunc = calc.differens;
            funcClick(calc.multiply, sender);
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 4;
            calc.functions[1] = 4;
            calc.previousCalcFunc = calc.divide;
            funcClick(calc.divide, sender);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 2;
            calc.functions[1] = 2;
            calc.previousCalcFunc = calc.differens;
            funcClick(calc.differens, sender);
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
            
            //if (calc.btnType == true && calc.isResultPresent!= true)
            if (calc.btnType == true)
            {
                calc.args[1] = calc.args[0];                
                calc.getResult(calc.calcFunc);
                label1.Text = calc.disp;
            }
            //Если "=" нажато после цифры или уже был получен результат
            //то обрабатывать стандартным методом
            else
            {
                funcClick(calc.calcFunc, sender);
                calc.isResultBtn = true;
            }
            calc.index = false;
            calc.isResultPresent = true;

            calc.btnType = false;

            //calc.previousCalcFunc = calc.calcFunc;

            //saveMe();
        }

        private void btn_SQRT_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 5;
            calc.functions[1] = 5;
            calc.extraFunc(calc.sqrtOf);
            label1.Text = calc.displayOut(calc.disp);
            saveMe();
        }

        private void btn_SQR_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 6;
            calc.functions[1] = 6;
            calc.extraFunc(calc.sqrOf);
            label1.Text = calc.displayOut(calc.disp);
            saveMe();
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            getFromMR(calc.mr.Length - 1);
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, 1);
        }

        public void setMR(int indexOf, int negative)
        {
            try
            {
                calc.mr[indexOf] += Convert.ToDouble(calc.arg)*negative;
            }
            catch
            {
                calc.mr[indexOf] = calc.args[0];
                calc.arg = Convert.ToString(calc.mr[indexOf]);
            }

            setMrList(indexOf);

            calc.btnType = true;
            btn_MList.Enabled = true;

            saveMe();
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            calc.mr = new double[1];
            btn_MList.Enabled = false;
            listBox_MR.Visible = false;
            listBox_MR.Items.Clear();
            switchMRButtons();
        }

        private void btn_MMinus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1,-1);
        }

        private void btn_MS_Click(object sender, EventArgs e)
        {
            int l = calc.mr.Length-1;
            
            if (calc.mr.Length > 0)
            {
                Array.Resize(ref calc.mr, l + 2);
                l++;
            }
            setMR(l,1);
        }

        private void btn_MList_Click(object sender, EventArgs e)
        {
            listBox_MR.Visible = !listBox_MR.Visible;
            switchMRButtons();
        }

        public void setMrList(int indexOf)
        {
            try
            {
                this.listBox_MR.Items[calc.mr.Length-1] = calc.mr[indexOf];
            }
            catch
            {
                this.listBox_MR.Items.Add(calc.mr[indexOf]);
            }
        }

        public void switchMRButtons()
        {
            btn_MR.Enabled = !btn_MR.Enabled;
            btn_MS.Enabled = !btn_MS.Enabled;
            saveMe();
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

            calc.args[i] = calc.mr[indexOf];

            if (calc.isResultPresent == false && calc.index == false) calc.resetFunc();
            
            calc.index = !calc.index;
            calc.btnType = false;

            label1.Text = calc.displayOut(Convert.ToString(calc.args[i]));
            calc.arg = "";

            saveMe();
        }

        private void listBox_MR_DoubleClick(object sender, EventArgs e)
        {
            getFromMR(listBox_MR.SelectedIndex+1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //calc.setFucn(calc.previousCalcFunc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calc.functions[0] = 7;
            calc.functions[1] = 7;
            saveMe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveMe();
        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            hf.Show();
        }

        public void saveMe()
        {
            addCalc();
            saveCalc();
            //hf.HistoryList.Items.Add(s);
            addToCalcList();
        }

        private void addCalc()
        {
            int i = calcs.Length;
            Array.Resize(ref calcs, i + 1);
            calcs[i] = calc;
        }

        private void saveCalc()
        {
            calc.calcFunc = null;
            calc.previousCalcFunc = null;
            string s = JsonConvert.SerializeObject(calc);

            File.AppendAllText("c:/temp/user.json", s + "\n");
            calc.getFunc(calc.functions);
        }

        private void addToCalcList()
        {
            string strCalc = string.Concat(calc.args[0],calc.calcFunc,calc.args[1],"=");
            
        }
    }
}

