using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral_347_2024.Classes
{
    public interface ICalculatorIntegral
    {
        double Calculate(double lower, double upper, int count, Func<double, double> func);
        double ParallelCalculate(double lower, double upper, int count, Func<double, double> func);
    }
    
}
