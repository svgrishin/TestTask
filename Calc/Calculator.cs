﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace Calc
{
    unsafe public class Calculator
    {
        public bool funcFlag = false;
        public bool resBtnFlag = false;
        public bool mrFlag = false;

         public bool *funcFlags;
         public bool *resBtnFlags;
         public bool *mrFlags;

        public string symbol;

        public delegate double funcDeleg(double[] a);

        public funcDeleg fDeleg;

        public double[] args = new double[2];

        public DateTime dateTimeOf;

        public string resultString;

        public bool index;
        public string arg, disp;
        public bool minus;
        
        public bool btnType;

        public double[] mr;

        public string[] jsonString;


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

            public double fraction(double[] a)
            {
                return 1/a[0];
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

            index = true;
            funcFlag = false;

            arg = args[0].ToString();
            disp=c.disp;
            minus=c.minus;

            btnType = c.btnType;

            mr=c.mr;

            jsonString=c.jsonString;
        }

        public Calculator()
        {
            fixed(bool *funcFlags = &funcFlag);
            funcFlag = false;

            index=false;
            arg = "";
            disp = "0";
            minus = false;
  
            btnType = false;
            mr = new double[1];

            jsonString = new string[1];
            
            fDeleg = null;

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
            btnType = false;
            fDeleg = null;
        }

        public string inputValues(char c, Form1 f)
        {
            if (funcFlag == true)
            {
                arg = "";
                funcFlag = false;
            }
            
            if (resBtnFlag == true) index = false;
            
            funcFlag = false;

            int i=15;
            
            if (c == '-') i = 17;

            if (arg.Length <= i)
            {
                string s;

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

        private void addingCalcToList(string s)
        {
            if (s == "√" || s == "1/")
            {
                addToCalcString(symbol);
                addToCalcString(args[0]);
                addToCalcString("=");
            }
            else
            {
                addToCalcString(args[0]);
                addToCalcString(symbol);
                addToCalcString(args[1]);
                addToCalcString("=");
            }
        }

        public void getResult(funcDeleg cf)
        {
            try
            {
                addingCalcToList(symbol);
            }
            catch { }

            try
            {
                args[0] = cf(args);
            }
            catch
            {
                args[0] = fDeleg(args);
            }

            fDeleg = cf;
            addToCalcString(args[0]);
            disp = displayOut(Convert.ToString(args[0]));
        }

        public string extraFunc(funcDeleg cf)
        {
            //функция для одного аргумента
            //особенность в том, что может быть успешно выполнена 
            //по упрощённому алгоритму

            tryToGetArg(arg);
            args[1] = 2;

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
                arg = "";
            }
            catch
            {
                if (resBtnFlag == false)
                {
                    index = true;
                    args[1] = args[0];
                    resBtnFlag = true;
                } 
            }
            index = true;
            disp = s;
        }

        public void tryToGetArg(double s)
        {
            try
            {
                args[Convert.ToByte(index)] = s;
                arg = "";
            }
            catch
            {
                if (resBtnFlag == false)
                {
                    index = true;
                    args[1] = args[0];
                    resBtnFlag = true;
                }
            }
            index = true;
            disp = s.ToString();
        }

        public void resultBtnCheckReset()
        {
            index = false;
        }

        private void addToCalcString(string s)
        {
            resultString=string.Concat(resultString,s);
        }

        private void addToCalcString(double s)
        {
            resultString=string.Concat(resultString,s.ToString());
        }
    }
}
