   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$V  PПеревод значения угла 'a' из радиан в градусы��5   	   $	��490��6?   $	��815��6L   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   5      .��5      � ���	#FF008001.+�5   
   �� -   5        $��ВЫЧИСЛИТЬ��5      $��Center=�6%   $��	0,302,0,0q�6B   $	��Top=�6U   $
��65px��6m   $��170px��6{   ���	#FF01D157$��Times New Roman)�6�   $��18(�6�   $��Black"�6�    � Cursor$
 Hand��6�    J� Opacity$ 1Q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   4  .System.Windows.Automation.AutomationProperties   HelpText$ Нажми на меня��6  ���	#FF008001���	#FF008001z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0Q�6&   T� 5      5      5      �� 5   
   -   5         ��Name$ TextBox1��5      $
��Left=�6$   $��50��6?   $	��120��6K   
���2͚�$��20(�6p   ���	#FF008001$��409,130,0,294q�6�   $
��Bold"�6�   $��Times New Roman)�6�   ���	#FF0080016�   �� 5   
   -   5        $ TextBox2��5      $
��Left=�6$   $��50��6?   $	��120��6K   
���2͚�$��20(�6p   ���	#FF008001	 �� 
IsReadOnly	 . $��409,197,0,227q�6�   $
��Bold"�6�   $��Times New Roman)�6�   ���	#FF0080016�   �� 5   
   -   5        $
��Left=�5      $��
94,132,0,0q�6-   
 �� TextWrapping$

 Wrap=�6A   $7��1Угол "a" в радианах (0 <= a < 2pi) =��6U   $	��Top=�6�   $	��295��6�   $��Times New Roman)�6�   $��18(�6�   $
��Bold"�6  
���2͚���6  Z� ��6C  Z� �� 5   
   $
��Left=�6   $��205,199,0,0q�6-   $

 Wrap=�6B   $(��"Угол "a" в градусах =��6V   $	��Top=�6}   $	��184��6�   $��18(�6�   $
��Bold"�6�   
���2͚�$��Times New Roman)�6�   ��6�   Z� ��6  Z� 5      5      