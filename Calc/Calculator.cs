using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;



namespace Calc
{
    public class Calculator
    {
        public double[] args;
        public bool isResultPresent;

        public bool index;
        public string arg, disp;
        public bool minus;
        public Func<double> calcFunc, previousCalcFunc;

        public bool isResultBtn;
        public bool btnType;

        public double[] mr;

        public string[] jsonString;

        public int functions;
        //0 - null
        //1 - Сумма
        //2 - Разность
        //3 - Произведение
        //4 - Частное
        //5 - Корень
        //6 - Степень
        //7 - дробь

        public void resetFunc()
        {
            calcFunc = null;
            functions = 0;
        }



        public void getFunc(int f)
        {
            switch (f)
            {
                case 1: calcFunc = summ; break;
                case 2: calcFunc = differens; break;
                case 3: calcFunc = multiply; break;
                case 4: calcFunc = divide; break;
                case 5: calcFunc = sqrtOf; break;
                case 6: calcFunc = sqrOf; break;
                    //case 7: calcFunc = ???; break;
            }
        }

        public Calculator()
        {
            args = new double[2];
            isResultPresent = false;

            index = false;
            arg = "";
            disp = "0";
            minus = false;
            calcFunc = null;
            isResultBtn = false;
            btnType = false;
            mr = new double[1];

            jsonString = new string[1];

            functions = 0;
        }

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

            calcFunc = null;
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

            saveMe();

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
            try
            {
                args[0] = f();
                previousCalcFunc = f;
            }
            catch
            {
                args[0] = previousCalcFunc();
            }

            isResultPresent = true;
            disp = displayOut(Convert.ToString(args[0]));

            //if previousCalcFunc = f;
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

        public void saveMe()
        {
            //calcFunc = null;
            //string s = JsonConvert.SerializeObject(this);
            //File.AppendAllText("c:/temp/user.json", s + "\n");
            //getFunc(functions);
        }


        public void saveFile(Calculator c)
        {

        }
    }
}
