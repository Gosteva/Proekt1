   M S B A M L   `   `   `  ����E  APrilozenie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Prilozenie
Prilozenie  5   	       Prilozenie.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Prilozenie     5   	     � Title$  TelephoneBook��5   	   $	��450��6   $	��800��6,   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $	��150 �6   �� 5      $��1* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PhoneDataGrid��5         
IsReadOnly . $��1��5         AutoGenerateColumns .  ��6   �� *MyTelephone+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Номер телефона��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Phone+5        5      $ 
Город��6%    64   �� *
City.City1+6U     5      $ 
Улица��6%    64   �� *Street.Street1+6Y     5      $ Email��6%    64   �� *Email+6P     5      $ Дом��6%    62   �� *House+6N     5      $ Квартира��6%    67   �� *
Kvartira+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Действия��5         CellTemplate 5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�5   !   .+�5    "   �� $��
EditButton��5"   %   -   5        $ ��Редактировать��5!   %   5#   %   �� 5$   "   $��DeleteButton��5&   %   -   5        $��Удалить��5%   %   5'   %   5(      5)      5+      5.      �� 5/   
   -   5        $��
Выход��5/      
��� ���$
��Left=�6N   $��
10,375,0,0q�6i   $	��Top=�6}   $	��130��6�   $��40��6�   �� 50   
   -   5        $��Добавить��50      
��� ���$
��Left=�6P   $��
10,335,0,0q�6k   $	��Top=�6   $	��130��6�   $��35��6�   � 51   
   
 � Orientation$
 
Horizontal=�52       � 
ItemHeight$ 30��53      .+�55      �� $��
Улица��6   $��Center=�6$   �� 56      -   5         ��Name$ StreetFilter��58   	   $	��150��57   	   $��Center=�59   	    �� SelectedIndex$ 0��5:   	   ��5<   	   �� *
StreetList+��5=      �� 5>      .R�5?      �� ��6    �� *	Street1+5@      5B      5C      �� 5D   
   $��Искать��6   $	��Top=�6!   $��-5,146,5.4,0q�69   �� 5E   
   -   5         ��Name$ SearchFilterTextBox��5H      $��0,177,0.4,220q�5F      $��Center=�5G      $��23��5H   =   �� 5I   
   $(��"Количество комнат:��6   $	��Top=�6-   $��
0,75,0.4,0q�6E   	� 5J   
   -   5         	� 	GroupName$ Kvartira��5K      
 � Tag$ 1��5L      $!��по возрастанию��5M       d� 	IsChecked$
 TrueY�5N      $	��Top=�5P      $��0,106,0.4,0q�6   	� 5Q   
   -	   5        $ Kvartira��5R      $ 2��5S      $��по убыванию��5T      $	��Top=�5V      $��0,126,0.4,0q�6   �� 5W   
   $��./Photo/Telep.png��6   $��0,120,26.4,0q�6+   5[      5\      