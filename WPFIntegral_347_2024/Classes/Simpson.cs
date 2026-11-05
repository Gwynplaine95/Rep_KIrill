using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral_347_2024.Classes
{
    class Simpson : ICalculatorIntegral
    {
        public double Calculate(double lower, double upper, int count, Func<double, double> func)
        {
            double h = (upper - lower) / count;
            double S = 0;
            double S1 = 0;
            double S2 = 0;

            for (int i = 1; i < count / 2 + 1; i++)
                S1 += func(lower + (2 * i - 1) * h);
            for (int i = 1; i < count / 2; i++)
                S2 += func(lower + 2 * i * h);
            S += 4 * S1 + 2 * S2 + (func(lower) + func(upper));

            return S * h / 3;

        }

        public double ParallelCalculate(double lower, double upper, int count, Func<double, double> func)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Нулевое или отрицательное количество разбиений");
            }

            double h = (upper - lower) / count;
            int halfCount = count / 2;

            double[] S1_Massive = new double[halfCount];
            double[] S2_Massive = new double[halfCount > 1 ? halfCount - 1 : 0];

            Parallel.For(0, halfCount, (j) =>
            {
                int i = j + 1;
                S1_Massive[j] = func(lower + (2 * i - 1) * h);
            });

            if (S2_Massive.Length > 0)
            {
                Parallel.For(0, S2_Massive.Length, (j) =>
                {
                    int i = j + 1;
                    S2_Massive[j] = func(lower + 2 * i * h);
                });
            }

            double S1 = S1_Massive.Sum();
            double S2 = S2_Massive.Sum();

            double S = 4 * S1 + 2 * S2 + func(lower) + func(upper);
            return S * h / 3;
        }
    }
}
