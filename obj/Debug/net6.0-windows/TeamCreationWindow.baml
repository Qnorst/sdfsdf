   M S B A M L   `   `   `  ����H  DTaskSearchWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TaskSearchWPFTaskSearchWPF  5   	   &     TaskSearchWPF.TeamCreationWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TaskSearchWPF     5   	     � Title$  TeamCreationWindow��5   	   $	��450��6$   $	��400��61   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GameChooseDGrid��5
         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6,   $��0��6<      AutoGenerateColumns$ False��6I      CanUserAddRows$ False��6e      CanUserDeleteRows$ False��6|      
IsReadOnly$
 True��6�      CanUserSortColumns$ False��6�   $��65,145,84,145q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Игра��6%   
   Width$	
 125 6Q      CanUserSort$ False��6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
GameName+6^   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $	 Выбрана��6)      IsThreeState$ False��6:      CanUserReorder$
 True��6O   $	
 100 6f   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      ��  d� 	IsChecked 6'   �� *	IsChecked+��6G   �� *CheckedCommand+ �� ElementName$ VM��6|   5      5      5      �� 5   
   $5��/Введите название команды:��6   $
��Left=�64   $��	28,73,0,0q�6O   $	��Top=�6b   $	��163��6z   �� 5   
   -   5        $��TeamNameBox��5      $
��Left=�6%   $��
196,77,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   $ ��Выберете игры:��6   $
��Left=�6)   $��
28,104,0,0q�6D   $	��Top=�6X   $	��163��6p   �� 5   
   -   5        $��TeamCreateBtn��5      $#��Создать команду��6&   $
��Left=�6\   $��142,369,0,0q�6w   $	��Top=�6�   5      5      