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

        public double[] mr2 = new double[1];
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

        public void resetArgs()
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

            

            if (isResultPresent == true) resetArgs();

            if (btnType == true) arg = "";

            if (c == '-') arg = arg.Insert(0, "-");
            else arg += c;

            btnType = false;

            return displayOut(arg);
        }

        public string inputValues(string c)
        {
            switch (c)
            {
                case "-":
                    {
                        if (arg != "" & arg != "0")
                        {
                            switch (minus)
                            {
                                case true: arg = arg.Insert(0, c); break;
                                case false: arg = arg.TrimStart('-'); break;
                            }
                            disp = arg;
                            return displayOut(arg);
                        }
                        else
                        {
                            arg = Convert.ToString(args[0]);
                            inputValues(c);
                            args[0] = args[0] * (-1);
                        }
                    }; break;
                case "0,":
                    {
                        arg = arg + c;
                        disp = arg;
                    }; break;
            }
            return disp;
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

        public void resPresCheck()
        {
            if (isResultPresent == true) resetArgs();
        }

        public void resultBtnCheck(Func<double> f)
        {
            if (isResultBtn==true)
            {
                switch(btnType)
                {
                    case false:
                        {
                            calcFunc = null;
                            index = false;
                            break;
                        }
                    case true:
                        {
                            calcFunc = null;
                            index = false;
                            arg = Convert.ToString(args[0]);
                            break;
                        }
                }
                isResultBtn = false;
            }
        }

        public void resultBtnCheck()
        {
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
