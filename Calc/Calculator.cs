using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace Calc
{
    
    //остледить состояние переменных при вводе первого аргумента и отразить в конструкторе класса с параметром
    public class Calculator
    {
        public string symbol;

        public delegate double funcDeleg(double[] a);

        public funcDeleg fDeleg;

        public double[] args = new double[2];

        public CalcFunction calcFuncOf;
        public CalcFunction previousCalcFunc;

        public DateTime dateTimeOf;

        public string resultString;
        public bool isResultPresent;

        public bool index;
        public string arg, disp;
        public bool minus;

        public bool isResultBtn;
        public bool btnType;

        public double[] mr;

        public string[] jsonString;

        public int[] functions;
        //0 - null
        //1 - Сумма
        //2 - Разность
        //3 - Произведение
        //4 - Частное
        //5 - Корень
        //6 - Степень
        //7 - дробь

        public class CalcFunction
        {
            public Func<double> functionOf;

            public CalcFunction(Func<double> f)
            {
                functionOf = f;
            }

            public CalcFunction()
            {
                functionOf = null;
            }

            public double summ(double[] a)
            {
                return a[0]+a[1];
            }

            public double multiply(double[] a)
            {
                return a[0]*a[1];
            }

            public double divide(double[] a)
            {
                return a[0]/a[1];
            }

            public double differens(double[] a)
            {
                return a[0]-a[1];
            }

            public double sqrOf(double[] a)
            {
                return Math.Pow(a[0],2);
            }

            public double sqrtOf(double[] a)
            {
                return Math.Sqrt(a[0]);
            }
        }

        public Calculator(Calculator c)
        {
            symbol = c.symbol;

            dateTimeOf =c.dateTimeOf;

            args = new double[2];
            args[0] = c.args[0];
            args[1] = c.args[1];;

            resultString=c.resultString;
            isResultPresent=c.isResultPresent;

            index = true;

            arg = args[0].ToString();
            disp=c.disp;
            minus=c.minus;

            isResultBtn = c.isResultBtn;
            btnType = c.btnType;

            mr=c.mr;

            jsonString=c.jsonString;

            functions=c.functions;
        }
        
        public void resetFunc()
        {
            calcFuncOf = new CalcFunction(calcFuncOf.functionOf);
            functions[0] = 0;
        }

        public void getDeleg(int[] f)
        {
            switch (f[0])
            {
                case 1: fDeleg = calcFuncOf.summ; break;
                case 2: fDeleg = calcFuncOf.differens; break;
                case 3: fDeleg = calcFuncOf.multiply; break;
                case 4: fDeleg = calcFuncOf.divide; break;
                case 5: fDeleg = calcFuncOf.sqrtOf; break;
                case 6: fDeleg = calcFuncOf.sqrOf; break;
              //case 7: calcFunc = ???; break;
            }
        }

        public Calculator()
        {
            isResultPresent = false;

            index=false;
            arg = "";
            disp = "0";
            minus = false;
            isResultBtn = false;
            btnType = false;
            mr = new double[1];

            jsonString = new string[1];

            functions = new int[2];

            calcFuncOf = new CalcFunction();
            args = new double[2];

        }

        public void getArgs(CalcFunction cf)
        {
            index = !index;

            tryToGetArg(arg);

            arg = "";
            disp = Convert.ToString(args[0]);
        }

        public void resetCalc()
        {
            arg = "";
            disp = "0";
            index = false;
            minus = false;
            isResultPresent = false;
            isResultBtn = false;
            btnType = false;
        }

        public string inputValues(char c, Form1 f)
        {
            int i=15;
            
            if (c == '-') i = 17;

            if (arg.Length <= i)
            {
                string s;

                resultBtnCheck();

                if (isResultPresent == true) resetCalc();
                if (btnType == true) arg = "";

                if (c == '-')
                {
                    if (arg != "")
                    {
                        switch (minus)
                        {
                            case true: arg = c + arg; break;
                            case false: arg = arg.TrimStart(c); break;
                        }
                        disp = arg;
                        s = displayOut(arg);
                    }
                    else s = disp;
                }
                else
                {
                    arg += c;
                    s = displayOut(arg);
                }
                btnType = false;
                f.setTextSize();

                return s;
            }
            else return displayOut(arg);
        }

        

        public string deleteSymbol()
        {
            if (arg.Length > 1 + Convert.ToInt16(minus))
            {
                arg = arg.Substring(0, arg.Length - 1);
                return displayOut(arg);
            }
            else
            {
                arg = "";
                disp = "0";
                return displayOut(disp);
            }
        }

        public string displayOut(string s)
        {
            bool b = false;
            if (s[0] == '-')
            {
                s = s.TrimStart('-');
                b = true;
            }
            if (s.Contains(',') == false)
            {
                for (int i = 3; i <= s.Length; i += 4)
                {
                    s = s.Insert(s.Length - i, " ");
                }
            }
            s = s.TrimStart(' ');
            if (b == true) s=s.Insert(0,"-");
            return s;
        }

        public double sqrOf()
        {
            return Math.Pow(args[0], 2);
        }

        public double sqrtOf()
        {
            return Math.Sqrt(args[0]);
        }

        public void getResult(funcDeleg cf)
        {
            try
            {
                addToCalcString(args[0]);
                addToCalcString(symbol);
                addToCalcString(args[1]);
                addToCalcString("=");
            }
            catch { }

            try
            {
                args[0] = cf(args);
                previousCalcFunc = this.calcFuncOf;
            }
            catch
            {
                args[0] = fDeleg(args);
            }
            
            addToCalcString(args[0]);
            isResultPresent = true;
            disp = displayOut(Convert.ToString(args[0]));
        }

        public string extraFunc(funcDeleg cf)
        {
            //функция для одного аргумента
            //особенность в том, что может быть успешно выполнена 
            //по упрощённому алгоритму

            tryToGetArg(arg);
            args[1] = 2;
            
            addToCalcString(arg);
            addToCalcString(symbol);
            
            getResult(cf);

            arg = "";
            index = !index;

            return disp;
        }

        public void tryToGetArg(string s)
        {
            try
            {
                args[Convert.ToByte(index)] = Convert.ToDouble(s);
            }
            catch
            {
                index = !index;
            }
            index = !index;
        }

        public void resultPresentCheck()
        {
            //проверка наличия результата
            if (isResultPresent == true) resetCalc();
        }

        public void resultBtnCheck(funcDeleg f)
        {
            //Проверка нажатия "=" ранее
            //необходимо для предотвращения автоматического вычисления результата
            //при нажатии кнопок функций после "=".
            //При выполнении условия необходимо определить тип кнопки:
            //  1. Цифра (false)
            //  2. Функция (true)

            if (isResultBtn == true)
            {
                switch (btnType)
                {
                    case false:
                        {
                            resultBtnCheckReset();
                            break;
                        }
                    case true:
                        {
                            resultBtnCheckReset();
                            arg = Convert.ToString(args[0]);

                            

                            break;
                        }
                }
                index = true;
                isResultBtn = false;
            }
        }

        public void resultBtnCheckReset()
        {
            resetFunc();
            index = false;
        }

        public void resultBtnCheck()
        {
            //следует не допускать автоматическое выполнение функции
            //над аргументом, который введён после "="
            //необходимо подготовпть калькулятор к вводу второго аргумента
            //после ввода первого, не допуская автоматического выполнения функции
            //после ввода первого аргумента
            if (isResultBtn == true)
            {
                switch (btnType)
                {
                    case false:
                        {
                            index = true;
                            break;
                        }
                    case true:
                        {
                            resetFunc();
                            index = false;
                            break;
                        }
                }
                isResultBtn = false;
            }
        }

        private void addToCalcString(string s)
        {
            resultString=string.Concat(resultString,s);
        }

        private void addToCalcString(double s)
        {
            resultString=string.Concat(resultString,s.ToString());
        }

        public void saveFile(Calculator c)
        {

        }
    }
}
