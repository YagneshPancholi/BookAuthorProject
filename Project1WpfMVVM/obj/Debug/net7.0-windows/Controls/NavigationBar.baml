   M S B A M L   `   `   `  ����J  FProject1WpfMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Project1WpfMVVM.State.Navigators Project1WpfMVVM.State.Navigators  5      G(clr-namespace:Project1WpfMVVM.ViewModelsProject1WpfMVVM.ViewModels  5      G(clr-namespace:Project1WpfMVVM.ConvertersProject1WpfMVVM.Converters  5      ,    &Project1WpfMVVM.Controls.NavigationBar   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >nav.clr-namespace:Project1WpfMVVM.State.Navigators     5      8vms(clr-namespace:Project1WpfMVVM.ViewModels     5      ?
converters(clr-namespace:Project1WpfMVVM.Converters     5        � 	Resources  5      6   0Project1WpfMVVM.Converters.EqualValueToParameter "  EqualValueToParameterConverter��%   &	          5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6     primaryBrush1#��[ 6     5       �� 
TargetType  
NavButtion �� BasedOn��%0   '	�       7  �� 5      " 	�6   8   61   5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   .+�5       	� $��0��6   $��BookLibrary��6*   0   *Project1WpfMVVM.State.Navigators.ViewTypes   Home#��Z 6   d� 	IsChecked 6@   �� *CurrentViewModel+ �� Mode$ OneWay=� �� 	Converter# [  	 �� ConverterParameter.   (Project1WpfMVVM.ViewModels.HomeViewModel"	  ��6�   �� *UpdateCurrentViewModelCommand+6  	� 5!      $��1��6   $��Authors��6*   
   Authors#��Z
 6n   ��6<   �� *UpdateCurrentViewModelCommand+6n   	� 5"      $��2��6   $��Books��6*      Books#��Z 6l   ��6:   �� *UpdateCurrentViewModelCommand+6l   	� 5#      $��3��6   $��Genres��6*      Genres#��Z 6m   ��6;   �� *UpdateCurrentViewModelCommand+6m   	� 5$      $��4��6   $��
Publishers��6*      
Publishers#��Z 6q   ��6?   �� *UpdateCurrentViewModelCommand+6q   5%      5&      5'      