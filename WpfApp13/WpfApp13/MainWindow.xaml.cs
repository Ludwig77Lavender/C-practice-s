using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfApp13
{
    public partial class MainWindow : Window
    {
        private string firstFilePath;
        private string secondFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseFirstFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (Path.GetExtension(openFileDialog.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    firstFilePath = openFileDialog.FileName;
                    FirstFilePath.Text = firstFilePath;
                }
                else
                {
                    MessageBox.Show("Выберите текстовый файл (.txt).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ChooseSecondFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (Path.GetExtension(openFileDialog.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    secondFilePath = openFileDialog.FileName;
                    SecondFilePath.Text = secondFilePath;
                }
                else
                {
                    MessageBox.Show("Выберите текстовый файл (.txt).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CompareFiles_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstFilePath) || string.IsNullOrEmpty(secondFilePath))
            {
                MessageBox.Show("Пожалуйста, выберите оба файла.");
                return;
            }

            try
            {
                string[] firstFileLines = File.ReadAllLines(firstFilePath);
                string[] secondFileLines = File.ReadAllLines(secondFilePath);

                using (StreamWriter writer = new StreamWriter("comparison_result.txt"))
                {
                    bool filesAreEqual = true;

                    for (int i = 0; i < Math.Max(firstFileLines.Length, secondFileLines.Length); i++)
                    {
                        string[] firstFileNumbers = firstFileLines.ElementAtOrDefault(i)?.Split(' ') ?? new string[0];
                        string[] secondFileNumbers = secondFileLines.ElementAtOrDefault(i)?.Split(' ') ?? new string[0];

                        for (int j = 0; j < Math.Max(firstFileNumbers.Length, secondFileNumbers.Length); j++)
                        {
                            string firstNumber = firstFileNumbers.ElementAtOrDefault(j) ?? "null";
                            string secondNumber = secondFileNumbers.ElementAtOrDefault(j) ?? "null";

                            if (firstNumber != secondNumber)
                            {
                                filesAreEqual = false;
                                string result = $"Несовпадение в строке {i + 1}, позиция {j + 1}: {firstNumber} != {secondNumber}";
                                ResultTextBlock.Text += result + "\n";
                                writer.WriteLine(result);
                                break;
                            }
                        }
                    }

                    if (filesAreEqual)
                    {
                        string result = "Файлы идентичны.";
                        ResultTextBlock.Text = result;
                        writer.WriteLine(result);
                    }
                }

                MessageBox.Show("Результат сравнения записан в файл comparison_result.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файлов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}