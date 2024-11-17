using System;
using System.Windows;

namespace SwapApp
{
    public abstract class SwapOperation
    {
        public abstract void Execute(ref double x, ref double y);
    }

    public class StandardSwapOperation : SwapOperation
    {
        public override void Execute(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }
    }

    public delegate void SwapDelegate(ref double x, ref double y);

    public partial class MainWindow : Window
    {
        private readonly SwapOperation swapOperation;
        private readonly SwapDelegate swapDelegate;

        public MainWindow()
        {
            InitializeComponent();
            swapOperation = new StandardSwapOperation();
            swapDelegate = swapOperation.Execute;
        }

        private void CalculateValues(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputA.Text) ||
                string.IsNullOrWhiteSpace(InputB.Text) ||
                string.IsNullOrWhiteSpace(InputC.Text) ||
                string.IsNullOrWhiteSpace(InputD.Text))
            {
                MessageBox.Show("Поля не могут быть пустыми. Пожалуйста, введите значения.",
                                "Ошибка ввода",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            if (double.TryParse(InputA.Text, out double a) &&
                double.TryParse(InputB.Text, out double b) &&
                double.TryParse(InputC.Text, out double c) &&
                double.TryParse(InputD.Text, out double d))
            {
                Swap1A.Text = a.ToString();
                Swap1B.Text = b.ToString();
                Swap2C.Text = c.ToString();
                Swap2D.Text = d.ToString();

                double b3 = a;
                double c3 = d;
                Swap3B.Text = b3.ToString();
                Swap3C.Text = c3.ToString();

                swapDelegate(ref a, ref b);
                swapDelegate(ref c, ref d);
                swapDelegate(ref b3, ref c3);

                ResultA.Text = a.ToString();
                ResultB.Text = b.ToString();
                ResultC.Text = c.ToString();
                ResultD.Text = d.ToString();
                ResultB2.Text = b3.ToString();
                ResultC2.Text = c3.ToString();
            }
            else
            {
                MessageBox.Show("Некорректные данные. Пожалуйста, введите числа.",
                                "Ошибка ввода",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}