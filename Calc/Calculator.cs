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
        int index = 0;
        public string arg, disp;
        public int func=0;
        public bool minus = false;
        
        public void getArgs()
        {
            args[index] = Convert.ToDouble(arg);
            if (index == 0) index = 1;
            else index = 0;
        }

        public void resetArgs()
        {
            arg = "0";
            disp = arg;
            Array.Clear(args, 0, 1);
            func = 0;
            index = 0;
            minus = false;
        }

        public string inputValues(char c)
        {
            if (c == '-') arg = arg.Insert(0, "-");
            else arg += c;
            
            disp = arg;   
            
            return displayOut();
        }

        public string deleteSymbol()
        {
            if (arg.Length > 1+Convert.ToInt16(minus))
                arg = arg.Substring(0, arg.Length - 1);
            else arg = "0";
            
            disp = arg;
            return displayOut();
        }

        private string displayOut()
        {
            if (disp.Contains(',') == false)
                for (int i = 3+Convert.ToInt16(minus); i <= disp.Length; i += 4)
                {
                    disp = disp.Insert(disp.Length - i, " ");
                }
            return disp;
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

    }
}
