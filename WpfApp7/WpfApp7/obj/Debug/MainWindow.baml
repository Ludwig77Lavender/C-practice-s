   M S B A M L   `   `   `  ����B  >WpfApp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp7WpfApp7  5   	       WpfApp7.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp7     5   	     � Title$A  ;Максимальное значение в матрице��5   	   $	��450��61   $	��800��6>   $��Times New Roman)�6J   $��14(�6g   .��5	      � $��10q�6   .+�5
   
   �� $&�� Количество строк:��6   $
��Left=�6-   $	��Top=�6H   $��	10,10,0,0q�6`   �� 5   
   -   5        $��RowCountInput��5      $
��Left=�6'    �� TextAlignment$ Center=�6B   $	��Top=�6Y   $��50��6q   $��
145,11,0,0q�6|   �� 5   
   $,��&Количество столбцов:��6   $
��Left=�60   $	��Top=�6K   $��	10,40,0,0q�6c   �� 5   
   -   5        $��ColumnCountInput��5      $
��Left=�6*   $ Center=�6E   $	��Top=�6\   $��50��6t   $��
145,40,0,0q�6   � 5   
   -   5        $��
MatrixGrid��5      $
��Left=�6!   $	��Top=�6<   $��
281,30,0,0q�6T   $	��400��6h   $	��200��6t    � ShowGridLines . 6�   �� 5   
   -   5        $-��'Сформировать матрицу��5      $
��Left=�60   $	��Top=�6K   $	��150��6c   $��	10,80,0,0q�6o   6�   �� 5   
   -   5        $)��#Обработать матрицу��5      $
��Left=�6.   $	��Top=�6I   $	��150��6a   $��
10,120,0,0q�6m   
������6�   �� 5   
   -   5        $��ResultOutput��5      $
��Left=�6&   $	��Top=�6A   $	��600��6Y   $��30��6e   $��
10,260,0,0q�6q    �� 
IsReadOnly . $��20(�6�   $
��Bold"�6�   5      5      