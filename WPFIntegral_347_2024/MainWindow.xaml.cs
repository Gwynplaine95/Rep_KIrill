using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFIntegral_347_2024.Classes;

namespace WPFIntegral_347_2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateIntegral();

        }
        private void CalculateIntegral()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double upperBound = Convert.ToDouble(tbUpperBound.Text);
            double lowerBound = Convert.ToDouble(tbLowerBound.Text);
            int count = Convert.ToInt32(tbCount.Text);
            double answer = 0;
            ICalculatorIntegral calculatorIntegral = GetCalculator();
            if (rbParallel.IsChecked==true)
            {
                answer = calculatorIntegral.ParallelCalculate(lowerBound, upperBound, count, x => 31 * x - Math.Log(5 * x) + 5);
            }
            else
            {
                answer = calculatorIntegral.Calculate(lowerBound, upperBound, count, x => 31 * x - Math.Log(5 * x) + 5);
            }
            sw.Stop();
            

            tbAnswer.Text = $"Ответ: {answer.ToString()}{Environment.NewLine}время:{sw.ElapsedMilliseconds}";
        }


        private ICalculatorIntegral GetCalculator()
        {
            switch (cmbBoxIntegralType.SelectedIndex)
            {
                case 0:
                    return new Simpson();
                case 1:
                    return new RectangleCalculator();
                default:
                    return new RectangleCalculator();
            }
        }

        private void tbUpperBound_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}