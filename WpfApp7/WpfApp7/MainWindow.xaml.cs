using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateMatrix_Click(object sender, RoutedEventArgs e)
        {
            MatrixGrid.Children.Clear();
            MatrixGrid.RowDefinitions.Clear();
            MatrixGrid.ColumnDefinitions.Clear();

            if (int.TryParse(RowCountInput.Text, out int rows) && int.TryParse(ColumnCountInput.Text, out int columns))
            {
                matrix = new int[rows, columns];
                Random rand = new Random();

                for (int i = 0; i < rows; i++)
                {
                    MatrixGrid.RowDefinitions.Add(new RowDefinition());
                }
                for (int j = 0; j < columns; j++)
                {
                    MatrixGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = rand.Next(-10, 11);

                        TextBlock cell = new TextBlock
                        {
                            Text = matrix[i, j].ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(5)
                        };

                        Grid.SetRow(cell, i);
                        Grid.SetColumn(cell, j);
                        MatrixGrid.Children.Add(cell);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для строк и столбцов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProcessMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                int columns = matrix.GetLength(1);
                int rows = matrix.GetLength(0);
                int maxSumColumnIndex = -1;
                int maxSum = int.MinValue;

                for (int j = 0; j < columns; j++)
                {
                    int sum = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        sum += matrix[i, j];
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumColumnIndex = j;
                    }
                }

                ResultOutput.Text = $"Столбец с наибольшей суммой: {maxSumColumnIndex + 1}, Сумма: {maxSum}";
            }
            else
            {
                MessageBox.Show("Сначала сгенерируйте матрицу.");
            }
        }
    }
}