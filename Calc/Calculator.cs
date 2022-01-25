using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calculator
    {
        public double[] args = new double[2];
        public bool isResultPresent = false;

        public bool index = false;
        public string arg = "", disp = "0";
        public bool minus = false;
        public Func<double> calcFunc;

        public bool isResultBtn = false;
        public bool btnType=false;

        public double[] mr = new double[1];
        public void getArgs(Func<double> f)
        {
            index = !index;

            tryToGetArg(arg);

            if (index == true)
            {
                getResult(f);
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
        }

        public string inputValues(char c)
        {
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

        public double summ()
        {
            return args[0] + args[1];
        }

        public double multiply()
        {
            return args[0] * args[1];
        }

        public double divide()
        {
            return args[0] / args[1];
        }

        public double differens()
        {
            return args[0] - args[1];
        }

        public double sqrOf()
        {
            return Math.Pow(args[0], 2);
        }

        public double sqrtOf()
        {
            return Math.Sqrt(args[0]);
        }

        public void getResult(Func<double> f)
        {
            args[0] = f();
            isResultPresent = true;
            disp = displayOut(Convert.ToString(args[0]));
        }

        public void extraFunc(Func<double> f)
        {
            //функция для одного аргумента
            //особенность в том, что может быть успешно выполнена 
            //по упрощённому алгоритму
            
            tryToGetArg(arg);
            getResult(f);

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

        public void resultBtnCheck(Func<double> f)
        {
            //Проверка нажатия "=" ранее
            //необходимо для предотвращения автоматического вычисления результата
            //при нажатии кнопок функций после "=".
            //При выполнении условия необходимо определить тип кнопки:
            //  1. Цифра (false)
            //  2. Функция (true)
            
            if (isResultBtn==true)
            {
                switch(btnType)
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
                isResultBtn = false;
            }
        }

        public void resultBtnCheckReset()
        {
            calcFunc = null;
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
                            calcFunc = null;
                            index = false;
                            break;
                        }
                }
                isResultBtn = false;
            }
        }
    }
}
