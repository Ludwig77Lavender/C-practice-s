   M S B A M L   `   `   `  ����C  ?WpfApp13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp13WpfApp13  5   	       WpfApp13.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp13     5   	     � Title$�  �Поэтапная проверка элементов файлов на равенство с использованием System.IO��5   	   $	��450��6]   $	��800��6j   $��Times New Roman)�6v   $��14(�6�   ���	#FFDADADA.��5	      � .+�5
   
   �� $��10,10,10,10q�6   .+�5      �� $-��'Выберите первый файл:��6   $��0, 60, 0, 5q�65   $	��160��6J   $
��Bold"�6V   �� 5      -   5        $
��0, 5q�5   3   $��25��6A   $	��200��6M   ���	#FFB7F5A6$
��Bold"�6p   .��6�   Выбрать файл6�   �� 5      -   5         ��Name$ FirstFilePath��5      $
��0, 5q�6-   $	��535��6;   
������� �� 
IsReadOnly . 6Z   �� 5      $-��'Выберите второй файл:��6   $
��0, 5q�65   $	��160��6C   $
��Bold"�6O   �� 5      -   5        $
��0, 5q�5   4   $��25��6B   $	��200��6N   ���	#FFB7F5A6$
��Bold"�6q   .��6�   Выбрать файл6�   �� 5      -   5        $ SecondFilePath��5      $
��0, 5q�6.   $	��535��6<   
������� . 6[   �� 5      -   5        $��5q�5   0   $��50��6;   $	��200��6G   ���	#FF42FF00$
��Bold"�6j   $��18(�6|   .��6�   Сравнить файлы6�   �� 5      -   5        $ ResultTextBlock��5      $
��0, 5q�6/    �� TextWrapping$
 Wrap=�6=   $	��535��6Q   
������� . 6p   5      5      5      