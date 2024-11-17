using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnFillPrimesClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(CountInput.Text);

                if (n <= 0)
                {
                    throw new Exception("Число N должно быть больше 0.");
                }

                int[] primes = GetFirstNPrimes(n);

                ErrorLabel.Content = "";
                ResultLabel.Content = "";

                ResultLabel.Content = $"Первые {n} простых чисел: {string.Join(", ", primes)}";
            }
            catch (Exception ex)
            {
                ErrorLabel.Content = $"Ошибка: {ex.Message}";
            }
        }

        private int[] GetFirstNPrimes(int n)
        {
            List<int> primes = new List<int>();
            int number = 2;

            while (primes.Count < n)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                number++;
            }

            return primes.ToArray();
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
