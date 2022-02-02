using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class CalcFunction: Calculator
    {
        public char funcSymbol;
        public Func<double> functionOf;
    }
}
