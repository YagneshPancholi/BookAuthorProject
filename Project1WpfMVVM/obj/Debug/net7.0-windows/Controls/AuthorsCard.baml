   M S B A M L   `   `   `  ����J  FProject1WpfMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Project1WpfMVVM.State.Navigators Project1WpfMVVM.State.Navigators  5      *    $Project1WpfMVVM.Controls.AuthorsCard   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >nav.clr-namespace:Project1WpfMVVM.State.Navigators     5      .��5
      ��    primaryBrush1#��[  6   $��1q�6:     �� CornerRadius$  10��6N    �� Padding$ 10 10q�6`   $	��300��6p   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   .+�5      �� $��0��6   $��0��6%   $��AuthorName : ��65   �� 5      $��0��6   $��1��6%   ��65   �� *
authorName+�� 5      $��1��6   $��0��6%   $��BirthDate : ��65   �� 5      $��1��6   $��1��6%   ��65   �� *	birthDate+�� 5      $��2��6   $��0��6%   $��Email : ��65   �� 5      $��2��6   $��1��6%   ��65   �� *email+�� 5      $��3��6   $��0��6%   $��Education : ��65   �� 5      $��3��6   $��1��6%   ��65   �� *	education+�� 5      -   5         ��Name$ editBtn��5      $��4��6'   $��0��64   $
��Edit��6E   $
��left=�6T   ��6p   �� *EditAuthorCommand+��6�   �� *
authorName+�� 5       -   5        $ delBtn��5       $��4��6&   $��1��63   $��Delete��6C   $
��left=�6T   ��6o   �� *DeleteAuthorCommand+��6�   �� *
authorName+5!      5"      5#      