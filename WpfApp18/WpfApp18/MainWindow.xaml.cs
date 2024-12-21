using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    // Класс COLLEGE
    public class COLLEGE
    {
        public string Name { get; set; }  // Название колледжа
        public List<string> Bells { get; set; }  // Время звонков на перемены

        // Конструктор для инициализации колледжа
        public COLLEGE(string name, List<string> bells)
        {
            Name = name;
            Bells = bells;
        }

        // Индексатор для получения времени звонков по индексу
        public string this[int index]
        {
            get { return Bells[index]; }
            set { Bells[index] = value; }
        }
    }

    // Класс COLLEGES для хранения коллекции колледжей
    public class COLLEGES
    {
        public List<COLLEGE> CollegeList { get; set; }

        // Конструктор для инициализации списка колледжей
        public COLLEGES()
        {
            CollegeList = new List<COLLEGE>();
        }

        // Метод для добавления колледжа
        public void AddCollege(COLLEGE college)
        {
            CollegeList.Add(college);
        }

        // Индексатор для получения колледжа по индексу
        public COLLEGE this[int index]
        {
            get { return CollegeList[index]; }
            set { CollegeList[index] = value; }
        }
    }

    // Главное окно приложения
    public partial class MainWindow : Window
    {
        private COLLEGES colleges;  // Коллекция колледжей
        private int currentIndex = 0;  // Индекс текущего колледжа в списке

        public MainWindow()
        {
            InitializeComponent();
            colleges = new COLLEGES();
            InitializeColleges();  // Инициализация данных
            DisplayCurrentCollege();  // Отображение текущего колледжа
        }

        // Инициализация данных колледжей
        private void InitializeColleges()
        {
            colleges.AddCollege(new COLLEGE("РКСИ", new List<string> { "9:30", "11:10", "13:00", "14:40", "16:30" }));
            colleges.AddCollege(new COLLEGE("ЮФУ", new List<string> { "10:30", "12:10", "14:00", "16:40", "18:30" }));
            colleges.AddCollege(new COLLEGE("ДГТУ", new List<string> { "8:30", "10:10", "12:20", "14:20", "16:20" }));
        }

        // Отображение текущего колледжа
        private void DisplayCurrentCollege()
        {
            if (colleges.CollegeList.Count > 0)
            {
                var currentCollege = colleges[currentIndex];
                CurrentCollegeName.Text = $"Колледж: {currentCollege.Name}";

                ListViewCharacteristics.Items.Clear();
                for (int i = 0; i < currentCollege.Bells.Count; i++)
                {
                    ListViewCharacteristics.Items.Add(new { Name = $"{i + 1}-я перемена", Time = currentCollege.Bells[i] });
                }
            }
        }

        // Обработчик события для кнопки "Следующий колледж"
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < colleges.CollegeList.Count - 1)
            {
                currentIndex++;
                DisplayCurrentCollege();
            }
        }

        // Обработчик события для кнопки "Предыдущий колледж"
        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentCollege();
            }
        }

        // Обработчик события для поиска по названию колледжа
        private void TextBoxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchName = TextBoxSearchName.Text.ToLower();
            var filteredColleges = colleges.CollegeList.FindAll(c => c.Name.ToLower().Contains(searchName));

            if (filteredColleges.Count > 0)
            {
                colleges = new COLLEGES();
                foreach (var college in filteredColleges)
                {
                    colleges.AddCollege(college);
                }

                currentIndex = 0;
                DisplayCurrentCollege();
            }
            else
            {
                ListViewCharacteristics.Items.Clear();
            }
        }

        // Обработчик события для поиска по времени звонка
        private void TextBoxSearchTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTime = TextBoxSearchTime.Text;
            var currentCollege = colleges[currentIndex];

            var filteredTimes = currentCollege.Bells.FindAll(b => b.Contains(searchTime));

            ListViewCharacteristics.Items.Clear();
            foreach (var time in filteredTimes)
            {
                ListViewCharacteristics.Items.Add(new { Name = $"{currentCollege.Bells.IndexOf(time) + 1}-я перемена", Time = time });
            }
        }

        // Обработчик события для кнопки "Изменить значение"
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewCharacteristics.SelectedItem != null)
            {
                var selectedBell = (dynamic)ListViewCharacteristics.SelectedItem;
                string currentValue = selectedBell.Time;

                // Открываем окно для ввода нового значения
                var inputBox = new InputBox(currentValue);
                if (inputBox.ShowDialog() == true)
                {
                    string newValue = inputBox.InputValue;
                    if (!string.IsNullOrEmpty(newValue))
                    {
                        var currentCollege = colleges[currentIndex];
                        int selectedIndex = ListViewCharacteristics.SelectedIndex;
                        currentCollege[selectedIndex] = newValue;
                        DisplayCurrentCollege();
                    }
                }
            }
        }

        // Класс для окна ввода значения
        private class InputBox : Window
        {
            public string InputValue { get; private set; }
            private TextBox TextBoxValue;
            private Button ButtonOK;

            public InputBox(string defaultValue = "")
            {
                Title = "Ввод нового значения";
                Height = 150;
                Width = 300;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;

                var grid = new Grid();
                TextBoxValue = new TextBox { Text = defaultValue, Margin = new Thickness(10, 40, 10, 0) };
                ButtonOK = new Button { Content = "OK", Width = 75, Margin = new Thickness(195, 70, 0, 0), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };

                ButtonOK.Click += ButtonOK_Click;

                var label = new Label { Content = "Введите новое значение:", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(10, 10, 0, 0) };

                grid.Children.Add(label);
                grid.Children.Add(TextBoxValue);
                grid.Children.Add(ButtonOK);

                Content = grid;
            }

            private void ButtonOK_Click(object sender, RoutedEventArgs e)
            {
                InputValue = TextBoxValue.Text;
                DialogResult = true;
            }
        }
    }
}