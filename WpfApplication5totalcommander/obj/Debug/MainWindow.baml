   M S B A M L   `   `   `  ����X  TWpfApplication5totalcommander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WpfApplication5totalcommanderWpfApplication5totalcommander  5   	   .    (WpfApplication5totalcommander.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:WpfApplication5totalcommander     5   	     � Title$  
MainWindow��5   	   $��854.858��6   $��1247.494��6-   .��5	      � $��
0,0,-8,-20q�6   .+�5
   
   �� -   5         ��Name$ 
buttonCopy��5
      $
��Copy��6%   $
��Left=�64   $��284,573,0,0q�6O   $	��Top=�6d   $	��122��6|   $��35��6�   6�   �� 5   
   -   5        $ buttonCreateNewDirectory��5      $��CreateNewDirectory��63   $
��Left=�6P   $��980,573,0,0q�6k   $	��Top=�6�   $	��185��6�   $��35��6�   6�   �� 5   
   -   5        $ 
buttonEdit��5      $
��Edit��6%   $
��Left=�64   $��406,573,0,0q�6O   $	��Top=�6d   $	��117��6|   $��35��6�   6�   �� 5   
   -   5        $ buttonDelete��5      $��Delete��6'   $
��Left=�6R   $��523,573,0,0q�6m   $	��Top=�6�   $	��129��6�   $��35��6�   �� 5   
   $��Visible=�6   $��Visible=�6?   $
��Left=�6f   $	��573��6�   $	��Top=�6�   $	��579��6�   .��5      �� -   5        $��LeftStackPanel��5      $
��Auto��60   $
��Auto��6>   5      �� 5   
   $��Visible=�6   $
��Left=�6@   $��Visible=�6[   $	��571��6�   $��	584,2,0,0q�6�   $	��Top=�6�   $	��581��6�   .��5      �� -   5        $��RightStackPanel��5      $
��Auto��60   $
��Auto��6>   5      �� 5   
   -   5         ��Name$ textBoxName��5      $
��Left=�6'   $��32��6B   $��	0,574,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��124��6�   �� 5   
   -   5        $ buttonSearch��5      $��Search��6'   $
��Left=�6R   $��124,573,0,0q�6m   $	��Top=�6�   $	��115��6�   $��35��6�   �� 5   
   -	   5         ��Name$ comboBox��5      $
��Left=�6&   $��239,574,0,0q�6A   $	��Top=�6V   $��45��6n   $��34��6y    J� RenderTransformOrigin$ 0.505,-0.154&�6�   �� 5   
   -
   5        $  ButtonSortedByCreationTime��5      $ ��ButtonSortedByCreationTime��6]   $
��Left=�6�   $��792,574,0,0q�6�   $	��Top=�6�   $	��188��6�   $��34��6�   �� 5   
   -   5        $ bButtonSortedByName��5      $��ButtonSortedByName��6M   $
��Left=�6j   $��652,573,0,0q�6�   $	��Top=�6�   $	��140��6�   $��35��6�   � 5   
   $
��Left=�6   $��32��6*   $��	0,574,0,0q�66   $	��Top=�6I   $
��1103��6a    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#   5%      5(      5)      