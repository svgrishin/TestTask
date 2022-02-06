using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class CalcFunction
    {
        public string funcSymbol;
        public Func<double> functionOf;
        public int indexOf;

        public CalcFunction()
        {
            functionOf = null;
        }

        public CalcFunction(string c, Func<double> f)
        {
            funcSymbol = c;
            functionOf = f;
            //indexOf = i;
        }


    }

}
