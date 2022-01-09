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
        public bool index = true;
        public string arg = "", disp="0";
        public bool minus = false;
        public Func<double> calcFunc;

        public delegate void useGetResult();
        public delegate void useGetArgs(Func<double> func);

        public void getArgs(Func<double> f)
        {
            index = !index;
            
            tryToGetArg(getArgs,f);

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
            Array.Clear(args, 0, 1);
            calcFunc = null;
            index = true;
            minus = false;
        }

        public string inputValues(char c)
        {
            if (c == '-') arg = arg.Insert(0, "-");
            else arg += c;
            
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
                    };break;
                case "0,":
                    {
                        arg = arg + c;
                        disp = arg;
                    };break;
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
            if (arg.Contains(',') == false)
                for (int i = 3; i <= arg.Length-Convert.ToInt16(minus)-1; i += 3)
                {
                    s = s.Insert(arg.Length - i, " ");
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

        public void getResult(Func<double> f)
        {
            args[0] = f();
            index = false;
        }

        public void resultBtn()
        {
            index = !index;

            tryToGetArg(resultBtn);

            getResult(calcFunc);
            disp = Convert.ToString(args[0]);
            index = true;
            arg = disp;
        }

        public void tryToGetArg(useGetResult f)
        {
            try
            {
                args[Convert.ToByte(index)] = Convert.ToDouble(arg);
            }
            catch
            {
                catchFunc(f);
            }
        }

        public void tryToGetArg(useGetArgs func, Func<double> f)
        {
            try
            {
                args[Convert.ToByte(index)] = Convert.ToDouble(arg);
            }
            catch
            {
                catchFunc(func, f);
            }
        }

        public void catchFunc(useGetResult f)
        {
            catchSwitch();
            f();
        }

        public void catchFunc(useGetArgs func, Func<double> f)
        {
            catchSwitch();
            func(f);
        }

        public void catchSwitch()
        {
            arg = "0";
            index = !index;
        }
    }
}
