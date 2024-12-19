using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp15
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUniversityButton_Click(object sender, RoutedEventArgs e)
        {
            string universityName = string.IsNullOrWhiteSpace(UniversityNameTextBox.Text) ? "???" : UniversityNameTextBox.Text;
            int establishedYear;
            double rating;

            if (!int.TryParse(EstablishedYearTextBox.Text, out establishedYear))
            {
                ShowError("Год основания должен быть целым числом.");
                return;
            }

            if (!double.TryParse(RatingTextBox.Text, out rating) || rating < 1 || Math.Round(rating, 3) != rating)
            {
                ShowError("Рейтинг должен быть числом не менее 1.");
                return;
            }

            string message = $"ВУЗ {universityName}, основанный в {establishedYear} году с рейтингом {rating}, обучает студентов уже {2024 - establishedYear} лет.";
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}