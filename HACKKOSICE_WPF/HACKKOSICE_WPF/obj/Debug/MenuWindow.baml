   M S B A M L   `   `   `  ����I  EHACKKOSICE_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HACKKOSICE_WPFHACKKOSICE_WPF  5   	       HACKKOSICE_WPF.MenuWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RGu.Wpf.Adorners, Version=1.5.1.0, Culture=neutral, PublicKeyToken=6dfb64f9972bd31d$adornershttp://gu.se/Adorners  5   	   (localclr-namespace:HACKKOSICE_WPF  5   	     � Title$  
MenuWindow��5	   	   $	��768��6   $
��1024��6)   .��5
      � .+�5   
   � $
��1024��6   $��66��6   $	��Top=�6(   $��0,0,-8,0q�6@   .+�5      �� -   5         ��Name$ IDNurse��5      $��
NURSE ID :��6%   $
��Left=�6:   $��
10,10,0,10q�6U   $��Center=�6i   $��Center=�6�   $��46��6�   $	��131��6�   $��Microsoft YaHei UI)�6�   �� 5      $��/images/smas.png��6   $��UniformToFill=�6.   $��436,-26,294,0q�6F   $��Stretch=�6]   5      � 5   
   $��
0,71,835,0q�6   ���	#FF108585.+�5      �� -   5        $��MAKE AN APPOINTMENT��5      $��	0,0,0,603q�63   $��Microsoft YaHei UI)�6�   ��6F   Z� ��6\   Z� 6�   �� 5      -   5        $��APPOINTMENT��5      $��
0,63,0,540q�6+   $��Microsoft YaHei UI)�6�   ��6?   Z� ��6U   Z� 6�   �� 5      -   5        $��LOGOUT��5      $��0,126,0,477q�6;   $��Microsoft YaHei UI)�6}   ��6P   Z� ��6f   Z� 6}   5      � 5   
   -   5         �Name$ MakeAnAppointmentGrid��5      $��
186,71,0,0q�6.   $y�	Collapsed=�6B   .+�5      �� -   5         ��Name$ id��5      $��Center=�6#   $��Center=�6E     Gu.Wpf.Adorners.Watermark   Text$ 
Patient ID��6i      VisibleWhen$  EmptyAndNotKeyboardFocused=�6�   $��262,10,292,608q�6�   .��6�      	TextStyle 5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@J�Opacity	 �� Value$		 0.5Q�64   �� 5       � ��$	 Oblique$�66   �� 5       � ��$	 Center=�6>   �� 5       � ��$	 Center=�6@   5      .��5   0   5      �� 5!      -   5        $ reason��5!      $��Center=�6&   $��Center=�6H   $ Reason��6l   $  EmptyAndNotKeyboardFocused=�6�   $��262,63,292,555q�6�   .��6�    5"      �� 5#      " ��6   .�5$      ��  �@J�Opacity$		 0.5Q�64   �� 5%       � ��$	 Oblique$�66   �� 5&       � ��$	 Center=�6>   �� 5'       � ��$	 Center=�6@   5(      .��5)   0   5*      (  "System.Windows.Controls.DatePicker  5+      -   5        
  Name$
 
datePicker��5+         SelectedDateFormat$
 Long=�6-   $��262,116,292,508q�6G      SelectedDate 6`   ��  �� Path$ SellStartDate� �� StringFormat$ {0:d MMMM yyyy}�� � 	Resources 5,      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� RelativeSource �� AncestorType��%�   '        �� 5-      "  6   .�5.      ��  � ��	 5/      �� 50   "   .R�51   &   �� $ dataTb��6.   ��52      �� $ SelectedDate�$ {0:d MMMM yyyy}�� �� "  54   #   56      57      58      59      �� 5:      -	   5        $��Appoint��5:      $��262,219,292,391q�6'   ��6@   Z� 6V   �� 5;      -
   5        $ start��5;      $��Center=�6%   $��Center=�6G   $ Start��6k   $  EmptyAndNotKeyboardFocused=�6�   $
��Left=�6�   $��23��6�   $��262,176,0,0q�6�    �� TextWrapping$
 Wrap=�6  $	��Top=�6  $	��120��60  .��6<   5<      �� 5=      " ��6   .�5>      ��  �@J�Opacity$		 0.5Q�64   �� 5?       � ��$	 Oblique$�66   �� 5@       � ��$	 Center=�6>   �� 5A       � ��$	 Center=�6@   5B      .��5C   0   5D      �� 5E      -   5        $	 end��5E      $
��Left=�6#   $��Center=�6>   $��Center=�6`   $��23��6�   $��409,176,0,0q�6�   $
 Wrap=�6�   $ Estimated end��6�   $  EmptyAndNotKeyboardFocused=�6�   $	��Top=�6  $	��120��65  .��6A   5F      �� 5G      " ��6   .�5H      ��  �@J�Opacity$		 0.5Q�64   �� 5I       � ��$	 Oblique$�66   �� 5J       � ��$	 Center=�6>   �� 5K       � ��$	 Center=�6@   5L      .��5M   0   5N      �� 5O      -   5        $ status��5O      $��Center=�6$   $��Center=�6F   $
��Left=�6j   $��262,289,0,0q�6�   $	��Top=�6�   $	��276��6�   5P      � 5Q   
   -   5        $ AppointmentGrid��5Q      $��
186,71,0,0q�6(   $y�	Collapsed=�6<    � RowDefinitions 5R      �� 5S      $	��200 �6    6/   �� 5T      6"   .+�5V      &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5V      $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $	��190��6o   $	��810��6|   6�   &   System.Windows.Controls.DataGrid  5W      -   5          Name$ dataGrid��5W      $
��Left=�6)   $	��446��6D   $��	10,10,0,0q�6Q   $	��Top=�6d   $	��810��6|   $��1��6�   5Y      5Z      5\      5]      