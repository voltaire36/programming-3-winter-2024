   M S B A M L   `   `   `  ����  DemoTab-    'DemoTab.UserControls.AddItemToOrderView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         ButtonStyle �� 
TargetType �� Property �� Value��%V  &	        �� 5	   
   " ��6$   .�5
      ��  � ��
 ��d�6+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 1q�60   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� $��Basket:��6   $��Center=�6'   $��5q�6B   �� 5        �� DisplayMemberPath$ DisplayText��5!       �� SelectedValuePath$ IdBasket��5"      $	��244��5$      $��Center=�6#   ��5       �� *	Baskets+ �� SelectedItem 5#      �� *SelectedBasket+5$   #   5%      �� 5'   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5(      �� $��Product:��6   $��Center=�6(   $��5q�6C   �� 5)      $ ProductName��5+      $	��232��5,      $��Center=�6   ��5)      �� *
Products+ 5*      �� *SelectedProduct+5,      5.      �� 50   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�51      �� $��	Quantity:��6   $��Center=�6)   $��5q�6D   �� 52      $	��222��6b   $��Center=�6n   ��6   �� *
Quantity+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6n   53      �� 55   
   $��4��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�56      �� $
��Save��6   $	��100��6D   #��[  6P   ��6$   �� *SaveCommand+6P   �� 57      $��Cancel��6   $	��100��6&   #��[  62   58      59      5:      