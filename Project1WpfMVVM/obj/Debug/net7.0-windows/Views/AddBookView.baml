   M S B A M L   `   `   `  ����J  FProject1WpfMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Project1WpfMVVM.State.Navigators Project1WpfMVVM.State.Navigators  5      '    !Project1WpfMVVM.Views.AddBookView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >nav.clr-namespace:Project1WpfMVVM.State.Navigators     5      .��5
      �� 
���   �$��1q�6"   ._�5   
   ��   �� Orientation$  Vertical=�6   .+�5      �� $  Vertical=�6   .+�5      �� -   5         ��Name$ BookName��5         commonFormTextInput#��[  6�   ��6l   �� *Book.bookName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $ Price��5      #��[  6u   ��6)   �� *
Book.price+$ TwoWay=�$ PropertyChanged=�6u   �� 5      $��_Authors : ��6     commonFormLabel#��[ 6.    �� Target 6X   ��  �� ElementName$
 box1���� 5      -   5         ��Name$
 box1��5        commonFormMultiSelect#��[ 6+   ��6[   �� *AllAuthors2+��5      �� 5      .R�5      �� $  Vertical=�6)   .+�5   "   ��  ��Name$ authorNameCheckBox��6+   -   5        ��5   H   �� *
authorName+��6�   �� *
authorName+6�   5      5      5      �� 5      -   5        $ selectedAuthorNamesBox��5       �� TextWrapping$
 Wrap=�6:   ${�False��6N   #��[  6a   ��6�   �� *Book.AuthorNamesStr+$ TwoWay=�$ PropertyChanged=��� 5      $��
_Genres : ��6   #��[ 6-    6W   �� $
 box2���� 5      -   5        $
 box2��5      #��[ 6+   ��6[   �� *
AllGenres2+��5      �� 5      .R�5      �� $ genreNameCheckBox��6'   -   5        ��5   C   �� *	genreName+��6z   �� *	genreName+6�   5      5!      �� 5"      -   5        $ selectedGenreNamesBox��5"      $
 Wrap=�69   ${�False��6M   #��[  6`   ��6�   �� *Book.GenreNamesStr+$ TwoWay=�$ PropertyChanged=��� 5#      $��_Publishers : ��6   #��[ 6U    61   �� $
 box3��6U   �� 5$      -	   5        $
 box3��5$      #��[ 6)   ��6Y   �� *AllPublishers2+��5%      �� 5&      .R�5'      �� $ publisherNameCheckBox��6'   -
   5        ��5'   G   �� *publisherName+��6�   �� *publisherName+6�   5(      5*      �� 5+      -   5        $ selectedPublisherNamesBox��5+      ${�False��6=   #��[  6P   ��6}   �� *Book.PublisherNamesStr+$ TwoWay=�$ PropertyChanged=�5,      �� 5-      $  
Horizontal=�6     buttonsHolder#��[ 62   .+�5.      �� -   5        	 ��Name$	 	SubmitBtn��5.      $��Submit��6-     commonFormWorkButton#��[ 6>   ��6m   �� *AddBookCommand+��6�   �� *Book+�� 5/      -   5        $	 	CancelBtn��5/      $��Cancel��6,     commonFormCancelButton#��[ 6=   0   *Project1WpfMVVM.State.Navigators.ViewTypes
   Books#��Z
 6�    � DataContext 6m   �� *	Navigator+��6�   �� *UpdateCurrentViewModelCommand+6�   50      51      52      53      