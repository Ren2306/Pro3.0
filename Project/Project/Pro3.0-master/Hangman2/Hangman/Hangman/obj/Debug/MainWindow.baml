   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:HangmanHangman  5   	       Hangman.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Hangman     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Welcome��5	   	   $	��500��6   $	��525��6&   
���   �.��5
      � .+�5   
   �� -   5         ��Name$ image1��5      $��bg.jpg��6    $
��Fill=�60   $��0,0,0.4,0.4q�6?   �� 5   
   -   5        $ image��5      $
��Left=�6   $	��178��6:   $��
142,71,0,0q�6G   $	��Top=�6[   $	��237��6s   $��hangman_full.png��6   �� 5   
   -   5         ��Name$ username��5      $��40��6$   $��20(�60   
�������$
��Bold"�6Q   
�������
������ $
��Left=�6�   $��143,301,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��Enter username��6�   $	��Top=�6�   $	��232��6  $��Century Gothic)�6  6+  �� 5   
   -   5         ��Name$ btnPlay��5      $
��Play��6"   $��18(�61   $��Center=�6?   $��	0,360,0,0q�6\   $	��Top=�6o   $��75��6�   
�������$��Century Gothic)�6�   
���2�2�6�   �� 5   
   -   5        $ btnRegister��5      
�������$��Century Gothic)�69   $��Register��6m   $
��Left=�6�   $��409,424,0,0q�6�   $	��Top=�6�   $��75��6�   $��16(�6�   ��6W   Z� 5      �� 5   
   -   5        $ muteA��5      $
��Mute��6    $��16(�6/   $
��Left=�6=   $��
54,423,0,0q�6X   $	��Top=�6l   $��75��6�   
���������6�   Z� 6�   �� 5   
   -   5         ��Name$ label��5      $��Hangman The Game��6   $
��Bold"�6:   
�������$��22(�6_   $��Center=�6n   $��56��6�   $��0,10,0,0q�6�   $	��Top=�6�   $��Century Gothic)�6�   �� 5   
   -   5        $
��Help��5      
�������$
��Left=�63   $��
410,16,0,0q�6N   $	��Top=�6b   $��75��6z    J� RenderTransformOrigin$ 1.027,0.648&�6�   $��31��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 Black��6#    � Offset$ 0Q�61   � 5      $
 	#FFF6F6F6��6#   $ 1Q�65   5      5      5      5      