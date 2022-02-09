using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;



namespace Calc
{
    
    //Изучить вложенные классы. Там ответ. Если не выйдет, то забить и вернуть как было, пусть и колхозно
    public class Calculator
    {
        public delegate double funcDeleg(double[] a);

        public funcDeleg fDeleg;
        //public funcDeleg previousCalcFunc;

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
            

            public string funcSymbol;
            public Func<double> functionOf;
            public int indexOf;

            Calculator c;

            public CalcFunction(Calculator calcArg)
            {
                c=calcArg;
            }

            public CalcFunction(string s, Func<double> f)
            {
                funcSymbol = s;
                functionOf = f;
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
        }

        public Calculator(Calculator c, Func<double> f)
        {
            fDeleg = c.fDeleg;

            calcFuncOf = new CalcFunction(c.calcFuncOf.funcSymbol,f);
            //calcFuncOf = new CalcFunction(c.calcFuncOf.funcSymbol,c.fDeleg,this);
            previousCalcFunc = new CalcFunction(c.calcFuncOf.funcSymbol, f);

            dateTimeOf =c.dateTimeOf;

            args = new double[2];
            args[0] = c.args[0];
            args[1] = c.args[1];
            
            //args[0] = c.args[0];
            //args[1] = c.args[1];

            resultString="";
            isResultPresent=c.isResultPresent;

            index=c.index;
            //arg = args[1].ToString(); вернуть, если сломается
            arg = "";
            disp=c.disp;
            minus=c.minus;

            //isResultBtn=c.isResultPresent; //вернуть, если сломается
            isResultBtn = false;
            btnType=false;

            mr=c.mr;

            jsonString=c.jsonString;

            functions=c.functions;

            //getFunc(c.functions);
        }
        
        public void resetFunc()
        {
            //calcFunc = null;
            calcFuncOf = new CalcFunction(this);
            functions[0] = 0;
        }


        //public void getFunc(int[] f)
        //{
        //    switch (f[0])
        //    {
        //        case 1: calcFuncOf = new CalcFunction("+", calcFuncOf.summ(args)); break;
        //        case 2: calcFuncOf = new CalcFunction("-", calcFuncOf.differens); break;
        //        case 3: calcFuncOf = new CalcFunction("×", calcFuncOf.multiply, this); break;
        //        case 4: calcFuncOf = new CalcFunction("÷", calcFuncOf.divide, this); break;
        //        //case 5: calcFuncOf = new CalcFunction("√", sqrtOf, this); break;
        //        //case 6: calcFuncOf = new CalcFunction("^", sqrOf, this); break;
        //            //case 7: calcFunc = ???; break;
        //    }

        //    switch (f[1])
        //    {
        //        case 1: previousCalcFunc = new CalcFunction("+", calcFuncOf.summ, this); break;
        //        case 2: previousCalcFunc = new CalcFunction("-", calcFuncOf.differens, this); break;
        //        case 3: previousCalcFunc = new CalcFunction("×", calcFuncOf.multiply, this); break;
        //        case 4: previousCalcFunc = new CalcFunction("÷", calcFuncOf.divide, this); break;
        //        //case 5: previousCalcFunc = new CalcFunction("√", sqrtOf, this); break;
        //        //case 6: previousCalcFunc = new CalcFunction("^", sqrOf, this); break;
        //            //case 7: previousCalcFunc = ???; break;
        //    }
        //}


        public Calculator()
        {
            isResultPresent = false;

            index=false;
            arg = "";
            disp = "0";
            minus = false;
            //calcFunc = null;
            isResultBtn = false;
            btnType = false;
            mr = new double[1];

            jsonString = new string[1];

            functions = new int[2];

            calcFuncOf = new CalcFunction(this);
            args = new double[2];

        }

        public void getArgs(CalcFunction cf)
        {
            index = !index;

            tryToGetArg(arg);

            if (index == true)
            {
                getResult(fDeleg);
            }
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

            //calcFunc = null;
            calcFuncOf = new CalcFunction(this);
        }

        public string inputValues(char c, Form1 f)
        {
            //addToCalcString(c);

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
                    return displayOut(arg);
                }
                else return displayOut(disp);
            }
            else arg += c;
            btnType = false;

            return displayOut(arg);
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
            if (s.Contains(',') == false)
                for (int i = 3; i <= s.Length - Convert.ToInt16(minus); i += 4)
                {
                    s = s.Insert(s.Length - i, " ");
                }
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
                addToCalcString(calcFuncOf.funcSymbol);
                addToCalcString(args[1]);
                addToCalcString("=");


            }
            catch { }

            try
            {
                //c.args[0] = c.calcFuncOf.functionOf();
                args[0] = cf(args);
                previousCalcFunc = this.calcFuncOf;
            }
            catch
            {
                //c.args[0] = previousCalcFunc.functionOf();
                args[0] = fDeleg(args);
    
                //getFunc(functions);
                resultString = "";
            }
            
            addToCalcString(args[0]);
            isResultPresent = true;
            disp = displayOut(Convert.ToString(args[0]));
        }

        public void extraFunc(CalcFunction cf)
        {
            //функция для одного аргумента
            //особенность в том, что может быть успешно выполнена 
            //по упрощённому алгоритму
            addToCalcString(cf.funcSymbol);

            tryToGetArg(arg);
            addToCalcString(arg);

            getResult(fDeleg);

            disp = Convert.ToString(args[0]);
            arg = "";
            index = !index;
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

        //public void resultBtnCheck(Func<double> f)
        public void resultBtnCheck(Calculator.funcDeleg f)
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
            //index = true;
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

        private string addToCalcList()
        {
            string s1, s2, s3, s4;
            s1 = args[0].ToString();
            s3 = args[1].ToString();
            try
            {
                s2 = calcFuncOf.funcSymbol;
            }
            catch { s2 = ""; }

            return string.Concat(s1, s2, s3, "=");
        }

        private void addToCalcString(string s)
        {
            resultString=string.Concat(resultString,s);
        }
        private void addToCalcString(char s)
        {
            resultString = resultString + s;
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
