using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Service
{
    public class CalculatorService:ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
