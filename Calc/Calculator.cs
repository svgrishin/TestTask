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
        string arg, disp;
        public int func;
        
        public void getArgs()
        {
            args[index] = Convert.ToDouble(arg);
            if (index == 0) index = 1;
            else index = 0;
        }

        public string inputValues(char c)
        {
            arg += c;
            disp = arg;
            
            for (int i=3; i<=disp.Length;i+=4)
            {
                disp.Insert(i, " ");
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
