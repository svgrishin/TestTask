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

        //public bool index = true; вернуть, если всё будет плохо
        public bool index = false;
        public string arg = "", disp="0";
        public bool minus = false;
        public Func<double> calcFunc;

        public string mr;

        //public delegate void useGetResult();
        //public delegate void useGetArgs(Func<double> func);

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

        public void getArgsTest()
        {
            index = !index;

            tryToGetArg(arg);

            if (index == true)
            {
                getResult(calcFunc);
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
            if (s.Contains(',') == false)
                for (int i = 3; i <= s.Length-Convert.ToInt16(minus)-1; i += 4)
                {
                    s = s.Insert(s.Length-i, " ");
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
            return Math.Pow(args[0],2);
        }

        public double sqrtOf()
        {
            return Math.Sqrt(args[0]);
        }

        public void getResult(Func<double> f)
        {
            args[0] = f();
            disp = displayOut(Convert.ToString(args[0]));
            
            //index = !index; вернуть, если всё плохо
        }

        public void extraFunc(Func<double>f)
        {
            index = !index;
            tryToGetArg(arg);
            getResult(f);

            disp = Convert.ToString(args[0]);
            arg = "";
            index = !index;
        }

        public void resultBtn()
        {
            index = !index;

            if (index == true) tryToGetArg(arg);

            getResult(calcFunc);
            disp = Convert.ToString(args[0]);
            index = true;
            //index = !index;
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

        //public void tryToGetArg(double s)
        //{
        //    try
        //    {
        //        args[Convert.ToByte(index)] = s;
        //    }
        //    catch
        //    {
        //    }
        //}
    }


}
