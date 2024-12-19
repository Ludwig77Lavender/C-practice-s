using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculate1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputN1.Text) || string.IsNullOrWhiteSpace(InputX1.Text))
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.TryParse(InputN1.Text, out int n) && int.TryParse(InputX1.Text, out int x))
            {
                double sum = CalculateSum(n, x);
                Result1.Text = $"Сумма для целого значения x: {sum}";
            }
            else
            {
                MessageBox.Show("Ошибка: неверный тип данных.", "Ошибка типа данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnCalculate2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputN2.Text) || string.IsNullOrWhiteSpace(InputX2.Text))
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.TryParse(InputN2.Text, out int n) && double.TryParse(InputX2.Text, out double x))
            {
                double sum = CalculateSum(n, x);
                Result2.Text = $"Сумма для вещественного значения x: {sum}";
            }
            else
            {
                MessageBox.Show("Ошибка: неверный тип данных.", "Ошибка типа данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculateSum(int n, double x)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += Math.Sin(i * x);
            }
            return sum;
        }
    }
}