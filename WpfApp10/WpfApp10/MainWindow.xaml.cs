using System;
using System.Windows;
using System.Windows.Controls;

namespace StringSearchApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSearch1(object sender, RoutedEventArgs e)
        {
            ProcessSearch(SearchString1.Text, InputString1.Text, Occurrence1.Text, Result1);
        }

        private void OnSearch2(object sender, RoutedEventArgs e)
        {
            ProcessSearch(SearchString2.Text, InputString2.Text, Occurrence2.Text, Result2);
        }

        private void OnSearch3(object sender, RoutedEventArgs e)
        {
            ProcessSearch(SearchString3.Text, InputString3.Text, Occurrence3.Text, Result3);
        }

        private void ProcessSearch(string S0, string S, string occurrenceText, TextBlock resultBlock)
        {
            if (string.IsNullOrEmpty(S))
            {
                MessageBox.Show("Ошибка: исходная строка не может быть пустой.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(S0))
            {
                MessageBox.Show("Ошибка: строка поиска не может быть пустой.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на корректность ввода номера вхождения (целое число)
            if (!int.TryParse(occurrenceText, out int K) || K <= 0)
            {
                MessageBox.Show("Ошибка: номер вхождения должен быть положительным целым числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Выполняем поиск K-го вхождения строки S0 в строке S
            int pos = PosK(S0, S, K);
            if (pos > 0)
            {
                resultBlock.Text = $"В исходной строке {K}-е вхождение строки \"{S0}\" начинается с {pos}-й позиции";
            }
            else
            {
                resultBlock.Text = $"В исходной строке {K}-е вхождение строки \"{S0}\" отсутствует";
            }
        }

        private int PosK(string S0, string S, int K)
        {
            int pos = -1;
            int count = 0;

            for (int i = 0; i < S.Length; ++i)
            {
                pos = S.IndexOf(S0, pos + 1);
                if (pos == -1) break;
                count++;
                if (count == K) return pos + 1;
            }

            return 0;
        }
    }
}
