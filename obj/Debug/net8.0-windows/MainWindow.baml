   M S B A M L   `   `   `  ����H  DTetris WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Tetris_WPFAppTetris_WPFApp  5   	       Tetris_WPFApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Tetris_WPFApp     5   	   -   5          � Title$  Tetris NASA��5   	   $	��600��6   $	��800��6*   $	��600��5	   	   $	��600��6   
�������$��Segoe UI Light)�5   	   $��28(�6%   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   ��5   
   �� 5       �� ImageSource$ Assets/Background.png��6   .+�5   
   (� $��1��6   $��1��5      $��0, 0, 0, 20q�5      .��5       �� -   5         ��Name$ 
GameCanvas��5       $��1��5!      $��1��5"      ���#101010$	��250��5$      $	��510��5%      $
}�True��5&      5'      5(      �� 5*   
   -   5         ��Name$ 	ScoreText��5*      $��0��5+      $��1��5,      $��Score��5-      $��0, 10q�5.       �� TextAlignment$ Center=�5/      �� 51   
   $��1��6   $��0��52      $��Center=�53      $��Right=�54      .+�55      �� $
��Hold��6   $ Center=�56      �� 58      -   5         ��Name$ 	HoldImage��58      $��20q�59      $	��125��5:      5;      �� 5=   
   $��1��6   $��2��5>      $��Center=�5?      $
��Left=�5@      .+�5A      �� $
��Next��6   $ Center=�5B      �� 5D      -   5        $ 	NextImage��5D      $��20q�5E      $	��125��5F      5G      � 5I   
   -   5         �Name$ GameOverMenu��5I      ���	#CC000000$��2��5K      $��3��5L      $y�Hidden=�5M      .+�5N      �� $��Center=�6   $��Center=�5O      .+�5P      �� $��	Game over��6   $��48(�5Q      $ Center=�5R      �� 5T      -   5        $ FinalScoreText��5T      $��Score: ��5U      $��36(�5V      $ Center=�5W      �� 5Y      -   5        $��
Play Again��5Y      
������$��0, 20, 0, 0q�5[      $��5q�5\      5]      5^      5`      5a      5b      