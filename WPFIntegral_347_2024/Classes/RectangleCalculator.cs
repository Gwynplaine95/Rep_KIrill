using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral_347_2024.Classes
{
    public class RectangleCalculator : ICalculatorIntegral
    {
        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Нулевое или отрицательное количество разбиений");
            }
            double h = (upper - lower ) / count;
            double sum= 0.0;
            for (int i=0;i<count; i++)
            {
                sum += func(lower + i * h);
            }
            return h * sum;
        }
        public double ParallelCalculate(double lower, double upper, int count, Func<double, double> func)
        {
            double []Sum_Massive=new double[count];

            if (count <= 0)
            {
                throw new ArgumentException("Нулевое или отрицательное количество разбиений");
            }
            double h = (upper - lower) / count;
            double sum = 0.0;
            Parallel.For(0, count, (i) =>
            {
               Sum_Massive[i]= func(lower + i * h);
            });
            sum = Sum_Massive.Sum();
            return h * sum;
        }
    }
}
