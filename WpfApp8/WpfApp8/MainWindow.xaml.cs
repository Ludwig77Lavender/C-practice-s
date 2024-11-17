using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Ограничиваем ввод только цифрами и знаками арифметических операция
        private void ExpressionTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9\+\-\*/]");
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string expression = ExpressionTextBox.Text;

            try
            {
                double result = EvaluateExpression(expression);
                ResultTextBlock.Text = $"Результат: {result:F3}"; // Округляем до 3 знаков после запятой
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double EvaluateExpression(string expression)
        {
            // Проверяем на пустую строку
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Выражение не должно быть пустым.");
            }

            // Используем DataTable для вычисления выражений
            var dataTable = new DataTable();
            object result = dataTable.Compute(expression, null);
            return Convert.ToDouble(result);
        }
    }
}

