using System;
using System.Linq;
using System.Windows;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCheckClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = int.Parse(CountInput.Text);

                string input = NumbersInput.Text;
                int[] numbers = input.Split(',')
                                     .Select(int.Parse)
                                     .ToArray();

                if (numbers.Length != count)
                {
                    throw new Exception($"Ожидалось {count} чисел, а введено {numbers.Length}.");
                }

                long productOfNegatives = numbers.Where(n => n < 0).Aggregate(1L, (prod, n) => prod * n);

                long productOfOdds = numbers.Where(n => n % 2 != 0).Aggregate(1L, (prod, n) => prod * n);

                int T = productOfNegatives > productOfOdds ? 1 : 0;

                ResultLabel.Content = $"Произведение отрицательных чисел: {productOfNegatives}\n" +
                                      $"Произведение нечетных чисел: {productOfOdds}\n" +
                                      $"T = {T} (1 - если произведение отрицательных больше, 0 - иначе)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}