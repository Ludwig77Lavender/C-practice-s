using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp12
{
    public partial class MainWindow : Window
    {
        // Делегат для вычисления суммы
        private delegate double SumFunction(double x, int n);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(nTextBox.Text);
                int xInt = int.Parse(xIntTextBox.Text);
                double xDouble = double.Parse(xDoubleTextBox.Text);

                SumFunction sinSum = (x, max) =>
                {
                    double sum = 0;
                    for (int i = 1; i <= max; i++)
                    {
                        sum += Math.Sin(i * x);
                    }
                    return sum;
                };

                SumFunction cosSum = (x, max) =>
                {
                    double sum = 0;
                    for (int i = 1; i <= max; i++)
                    {
                        sum += Math.Cos(i * x);
                    }
                    return sum;
                };

                double sinResultInt = sinSum(xInt, n);
                double cosResultInt = cosSum(xInt, n);

                double sinResultDouble = sinSum(xDouble, n);
                double cosResultDouble = cosSum(xDouble, n);

                resultSIntListView.Items.Clear();
                resultSIntListView.Items.Add(new { Sin = sinResultInt, Cos = cosResultInt });

                resultSDoubleListView.Items.Clear();
                resultSDoubleListView.Items.Add(new { Sin = sinResultDouble, Cos = cosResultDouble });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода данных: {ex.Message}");
            }
        }
    }
}