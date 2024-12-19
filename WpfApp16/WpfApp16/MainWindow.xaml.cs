#define USE_DEFAULT_ATTRIBUTE // Уберите, чтобы отключить атрибут

using System;
using System.Reflection;
using System.Windows;

namespace WpfApp16
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DefaultUniversityAttribute : Attribute
    {
        public string Name { get; }
        public int EstablishedYear { get; }
        public double Rating { get; }

        public DefaultUniversityAttribute(string name, int establishedYear, double rating)
        {
            Name = name;
            EstablishedYear = establishedYear;
            Rating = rating;
        }
    }

    [DefaultUniversity("Технологический институт", 1901, 4.500)]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUniversityButton_Click(object sender, RoutedEventArgs e)
        {
            string universityName = string.IsNullOrWhiteSpace(UniversityNameTextBox.Text)
                                    ? GetDefaultUniversityName()
                                    : UniversityNameTextBox.Text;

            int establishedYear = string.IsNullOrWhiteSpace(EstablishedYearTextBox.Text)
                                  ? GetDefaultEstablishedYear()
                                  : ParseOrShowError(EstablishedYearTextBox.Text, "Год основания должен быть целым числом.");
            if (establishedYear == -1) return;

            double rating = string.IsNullOrWhiteSpace(RatingTextBox.Text)
                            ? GetDefaultRating()
                            : ParseOrShowErrorDouble(RatingTextBox.Text, "Рейтинг должен быть числом не менее 1.");
            if (rating == -1) return;

            string message = $"ВУЗ {universityName}, основанный в {establishedYear} году с рейтингом {rating}, обучает студентов уже {2024 - establishedYear} лет.";
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private string GetDefaultUniversityName()
        {
#if USE_DEFAULT_ATTRIBUTE
            var attr = GetType().GetCustomAttribute<DefaultUniversityAttribute>();
            return attr?.Name ?? "???";
#else
            ShowError("Поле имени университета не может быть пустым.");
            return null;
#endif
        }

        private int GetDefaultEstablishedYear()
        {
#if USE_DEFAULT_ATTRIBUTE
            var attr = GetType().GetCustomAttribute<DefaultUniversityAttribute>();
            return attr?.EstablishedYear ?? 0;
#else
            ShowError("Поле года основания не может быть пустым.");
            return -1;
#endif
        }

        private double GetDefaultRating()
        {
#if USE_DEFAULT_ATTRIBUTE
            var attr = GetType().GetCustomAttribute<DefaultUniversityAttribute>();
            return attr?.Rating ?? 0.0;
#else
            ShowError("Поле рейтинга не может быть пустым.");
            return -1;
#endif
        }

        private int ParseOrShowError(string input, string errorMessage)
        {
            if (int.TryParse(input, out int result)) return result;
            ShowError(errorMessage);
            return -1;
        }

        private double ParseOrShowErrorDouble(string input, string errorMessage)
        {
            if (double.TryParse(input, out double result) && result >= 1) return result;
            ShowError(errorMessage);
            return -1;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}