using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCheckDayClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem selectedItem = (ComboBoxItem)DayInput.SelectedItem;
                int day = int.Parse(selectedItem.Content.ToString());

                // Обнуляем сообщения перед новым запросом
                ErrorLabel.Content = "";
                ResultLabel.Content = "";

                switch (day)
                {
                    case 1:
                        ResultLabel.Content = "День недели, соответствующий числу 1 - \nпонедельник";
                        break;
                    case 2:
                        ResultLabel.Content = "День недели, соответствующий числу 2 - \nвторник";
                        break;
                    case 3:
                        ResultLabel.Content = "День недели, соответствующий числу 3 - \nсреда";
                        break;
                    case 4:
                        ResultLabel.Content = "День недели, соответствующий числу 4 - \nчетверг";
                        break;
                    case 5:
                        ResultLabel.Content = "День недели, соответствующий числу 5 - \nпятница";
                        break;
                    case 6:
                        ResultLabel.Content = "День недели, соответствующий числу 6 - \nсуббота";
                        break;
                    case 7:
                        ResultLabel.Content = "День недели, соответствующий числу 7 - \nвоскресенье";
                        break;
                    default:
                        ErrorLabel.Content = "Ошибка: неправильный номер дня недели";
                        break;
                }
            }
            catch
            {
                ErrorLabel.Content = "Ошибка: выберите корректный \nномер дня недели";
            }
        }
    }
}