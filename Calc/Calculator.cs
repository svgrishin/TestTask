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
        bool index = false;
        public string arg = "", disp="0";
        public int func=0;
        public bool minus = false;
        public bool[] argsIsPresent = new bool[2]{false,false};
        public Func<double> calcFunc;
        
        public void getArgs(Func<double> f)
        {
            try
            { 
                args[Convert.ToInt16(index)] = Convert.ToDouble(arg);
                index = !index;
                //arg = "";
                if (index == false)
                {
                    args[0] = f();
                    arg=Convert.ToString(args[0]);
                    index =! index;
                    disp = arg;
                }
                disp = arg;
                arg = "";
            }
            catch { resetArgs(); };
        }

        public void resetArgs()
        {
            arg = "";
            disp = "0";
            Array.Clear(args, 0, 1);
            func = 0;
            index = false;
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
            if (arg.Length > 1+Convert.ToInt16(minus))
                arg = arg.Substring(0, arg.Length - 1);
            else arg = "0";
            
            disp = arg;
            return displayOut(arg);
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

        public void getResult()
        {
            switch (func)
            {
                case 1: args[0] = summ();break;
                case 2: args[0] = differens();break;
                case 3: args[0] = multiply(); break; 
                case 4: args[0] = divide(); break; 
            }
        }

        public void setFunction(Func<double>f)
        {
            ;
        }

    }
}
