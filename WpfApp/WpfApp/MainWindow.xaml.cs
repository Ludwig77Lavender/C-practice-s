using System;
using System.Collections.Generic;
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


namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			// Это кнопка
			double a = 0;
			try
			{
				a = Convert.ToDouble(TextBox1.Text);

				if (0 <= a && a < Math.PI * 2)
				{
					double res = a * (180 / Math.PI);
					TextBox2.Text = res.ToString("F3");
				}
				else
				{
					MessageBox.Show("a не входит в диапазон функции (0 <= a < 2pi)", "Ошибка ввода");
				}
			}
			catch
			{
				MessageBox.Show("Что-то пошло не так...", "Ошибка ввода");
			}
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
