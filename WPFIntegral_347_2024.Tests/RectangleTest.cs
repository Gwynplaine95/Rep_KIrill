using WPFIntegral_347_2024.Classes;

namespace WPFIntegral_347_2024.Tests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void XXCorectValue()
        {
            // подготовка данных
            double lower = 0;
            double upper = 1;
            int count = 10000;
            Func<double, double> func = x => x * x;
            double expected = 1 / 3.0;

            //act
            RectangleCalculator calc = new RectangleCalculator();
            double actual = calc.Calculate(lower, upper, count, func);


            //assert
            Assert.AreEqual(expected, actual, 0.01);

        }
        [TestMethod]
        public void NegativeCounts()
        {
            // подготовка данных
            double lower = 0;
            double upper = 1;
            int count = -10000;
            Func<double, double> func = x => x * x;
            double expected = 1 / 3.0;

            //act
            RectangleCalculator calc = new RectangleCalculator();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                calc.Calculate(lower, upper, count, func);
            });
        }
    }
}