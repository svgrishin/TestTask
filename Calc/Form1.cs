using System;
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
        /// <summary>
        /// Объект калькулятора
        /// </summary>
        public Calculator calc = new Calculator();

        /// <summary>
        /// Массив с калькуляторами для хранения объектов с различными состояниями
        /// </summary>
        public Calculator[] calcs = new Calculator[0];

        /// <summary>
        /// Форма с историей вычислений
        /// </summary>
        public HistoryForm hf;

        /// <summary>
        /// Форма отображения памяти калькулятора
        /// </summary>
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

        /// <summary>
        /// Ввод символа
        /// </summary>
        /// <param name="c">Вводимый символ</param>
        private void inputVal(char c)
        {
            label1.Text = calc.inputValues(c);
            setTextSize();
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            if (calc.arg == "") typeZeroComa();
            else label1.Text = calc.inputValues('0');
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
                else label1.Text = calc.inputValues(',');
            }
        }

        /// <summary>
        /// Ввод "0,"
        /// </summary>
        public void typeZeroComa()
        {
            label1.Text = calc.inputValues('0');
            label1.Text = calc.inputValues(',');
        }

        /// <summary>
        /// Подгонка размера шрифта дисплея
        /// </summary>
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

        /// <summary>
        /// Нажатие одной из функций
        /// </summary>
        /// <param name="f">Делегат функции выполнения</param>
        /// <param name="isExtraFunc">Флаг функции одного аргумента</param>
        private void btn_Func_Click(Calculator.funcDeleg f, bool isExtraFunc)
        {
            if (isExtraFunc == true)
            {
                calc.extraFunc(f);
                label1.Text = calc.disp;
                saveStatus();
                setTextSize();
            }
            else funcClick(f);
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            btn_click("+", new Calculator.CalcFunction().Summ, false);
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
                        //calc.getResult(calc.fDeleg);
                        getResult(calc.fDeleg);
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

            saveStatus();

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
            getFromMR(calc.mr.Length - 1);
            label1.Text = calc.arg;
            
            calc.mrFlag = true;
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, 1);
            
            calc.mrFlag = true;
            
            btn_MC.Enabled = true;
            btn_MR.Enabled = true;
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
                calc.arg = calc.mr[indexOf].ToString();
            }

            setMrList(indexOf);

            calc.funcFlag = true;
            calc.resBtnFlag = true;

            btn_MList.Enabled = true;

            calc.mrFlag = true;
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            calc.mr = new double[1];
            btn_MList.Enabled = false;
            mf.listBox_MR.Items.Clear();
            switchMRButtons();
        }

        private void btn_MMinus_Click(object sender, EventArgs e)
        {
            setMR(calc.mr.Length - 1, -1);
            calc.mrFlag = true;
            
            btn_MC.Enabled = true;
            btn_MR.Enabled = true;
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
            
            calc.mrFlag = true;
            
            btn_MC.Enabled = true;
            btn_MR.Enabled = true;
        }

        private void btn_MList_Click(object sender, EventArgs e)
        {
            mf.Left = Left + (Width - hf.Width) / 2;
            mf.Top = Top + (Height - hf.Height) / 2;
            mf.Show();
            Enabled = false;
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
            btn_MR.Enabled = false;
            btn_MC.Enabled = false;
        }

        public void getFromMR(int indexOf)
        {
            calc.arg = calc.mr[indexOf-1].ToString();
            if (calc.mr[indexOf - 1] < 0) calc.minus = true;
            calc.disp = calc.displayOut(calc.arg);
            
            label1.Text = calc.disp;
        }

        private void listBox_MR_DoubleClick(object sender, EventArgs e)
        {
            getFromMR(mf.listBox_MR.SelectedIndex + 1);
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

        /// <summary>
        /// Инициатор сохранения статуса калькулятора
        /// </summary>
        public void saveMe()
        {
            addCalc();
            try
            {
                saveCalc();
            }
            catch { this.Text = "Не удалось сохранить в файл"; }
        }

        /// <summary>
        /// Загрузка калькулятора
        /// </summary>
        /// <param name="Индекс загружаемого калькулятора из массива калькуляторов"></param>
        public void loadMe(int i)
        {
            calc = new Calculator(calcs[i]);
            
            label1.Text = calc.displayOut(calc.disp);

            resetCalc();

            calc.arg = calc.args[0].ToString();
        }

        /// <summary>
        /// Инициатор сброса калькулятора
        /// </summary>
        public void resetCalc()
        {
            calc.ResetCalc();
            label1.Font = new Font("Arial", 30);
        }

        /// <summary>
        /// Пополнение массива состояний новым состоянием калькулятора
        /// </summary>
        private void addCalc()
        {
            int i = calcs.Length;
            Array.Resize(ref calcs, i + 1);
            calcs[i] = new Calculator(calc);   
        }

        /// <summary>
        /// Сохранение состояния калькулятора в файл
        /// </summary>
        private void saveCalc()
        {
            Calculator c = new Calculator(calc);

            c.fDeleg = null;
            
            string s = JsonConvert.SerializeObject(c);

            File.AppendAllText("c:/temp/calc.json", s + "\n");
        }

        /// <summary>
        /// Добавление в список вычисления целиком
        /// </summary>
        /// <param name="c">Калькулятор</param>
        private void addToCalcList(Calculator c)
        {
            hf.HistoryList.Items.Add(c.resultString);
            comboBox1.Items.Add(c.resultString);
        }

        /// <summary>
        /// Инициатор получения результата
        /// </summary>
        /// <param name="cf">Делегат функции</param>
        private void getResult(Calculator.funcDeleg cf)
        {
            calc.getResult(cf);
            saveStatus();
        }

        /// <summary>
        /// Фиксация этапа вычисления
        /// </summary>
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
            //setTextSize(); //динамичное изменение размера шрифта, но выглядит не очень
        }
    }
}