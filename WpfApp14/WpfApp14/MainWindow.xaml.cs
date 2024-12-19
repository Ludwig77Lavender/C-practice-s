using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp14
{
	public partial class MainWindow : Window
	{
		private string filePath;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ChooseFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				if (Path.GetExtension(openFileDialog.FileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
				{
					filePath = openFileDialog.FileName;
					FilePathTextBlock.Text = filePath;
				}
				else
				{
					MessageBox.Show("Выберите текстовый файл (.txt).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void FindAndHighlight_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				MessageBox.Show("Пожалуйста, выберите файл.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			string searchWord = SearchWordTextBox.Text;
			if (string.IsNullOrWhiteSpace(searchWord) || !Regex.IsMatch(searchWord, @"^[А-ЯЁ]+$"))
			{
				MessageBox.Show("Введите слово прописными буквами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			try
			{
				string fileContent = File.ReadAllText(filePath);
				ResultRichTextBox.Document.Blocks.Clear();

				HighlightWords(fileContent, searchWord);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void HighlightWords(string text, string word)
		{
			var paragraph = new Paragraph();
			var matches = Regex.Matches(text, word);

			int lastIndex = 0;
			foreach (Match match in matches)
			{
				paragraph.Inlines.Add(new Run(text.Substring(lastIndex, match.Index - lastIndex)));
				paragraph.Inlines.Add(new Run(match.Value)
				{
					Background = Brushes.Yellow
				});
				lastIndex = match.Index + match.Length;
			}

			paragraph.Inlines.Add(new Run(text.Substring(lastIndex)));

			ResultRichTextBox.Document.Blocks.Add(paragraph);
		}
	}
}