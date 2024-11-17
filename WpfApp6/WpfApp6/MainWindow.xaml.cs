using System;
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

        private void OnCheckClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int N = int.Parse(NInput.Text);
                int K = int.Parse(KInput.Text);
                int[] array = ArrayInput.Text.Split(',').Select(int.Parse).ToArray();

                if (N != array.Length)
                {
                    throw new Exception($"Размер массива должен быть равен {N}, но введено {array.Length} элементов.");
                }

                if (K <= 0 || K > N)
                {
                    throw new Exception($"K должно быть в диапазоне от 1 до {N}.");
                }

                var result = array.Where((value, index) => (index + 1) % K == 0).ToArray();
                ResultLabel.Content = $"Элементы массива с кратными K ({K}) индексами: {string.Join(", ", result)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
