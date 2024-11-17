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

namespace WpfApp2
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

		private void OnFindDClick(object sender, RoutedEventArgs e)
		{
			try
			{
				// Получение координат вершин
				int ax = int.Parse(Ax.Text);
				int ay = int.Parse(Ay.Text);
				int bx = int.Parse(Bx.Text);
				int by = int.Parse(By.Text);
				int cx = int.Parse(Cx.Text);
				int cy = int.Parse(Cy.Text);

				// Поиск координат четвёртой вершины
				int dx, dy;
				if (ax == bx)
				{
					dx = cx;
					dy = by == cy ? ay : by;
				}
				else if (ax == cx)
				{
					dx = bx;
					dy = by == cy ? ay : cy;
				}
				else if (bx == cx)
				{
					dx = ax;
					dy = ay == cy ? by : ay;
				}
				else
				{
					// Прямоугольник не может быть построен
					ResultLabel.Content = "Невозможно построить прямоугольник\nс заданными вершинами.";
					return;
				}

				// Вывод результата
				ResultLabel.Content = $"Координаты вершины D: ({dx}, {dy})";
			}
			catch
			{
				ResultLabel.Content = "Ошибка ввода.\nУбедитесь, что ввели правильные числа.";
			}
		}
	}
}
