   M S B A M L   `   `   `  ����B  >DemoTab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DemoTab.UserControlsDemoTab.UserControls  5   	   7 clr-namespace:DemoTab.ViewModelsDemoTab.ViewModels  5   	       DemoTab.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:DemoTab.UserControls     5   	   6	viewModel clr-namespace:DemoTab.ViewModels     5   	     � Title$  Order Manager��5	   	   $	��450��6   $	��800��6,    � 	Resources 5       �� DataType.   (DemoTab.ViewModels.OrderDetailsViewModel+   %DemoTab.UserControls.OrderDetailsView0   *DemoTab.ViewModels.AddItemToOrderViewModel-   'DemoTab.UserControls.AddItemToOrderView��%�   (��       5      *, +)(�� 2     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� 
�����_�._�5       ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5!      �� $��Order Manager��6   $��24(�5"      $��Center=�5#      $��Ink Free)�5$      5%      5&      �� 5(   
   $��1��6   $ 
Horizontal=�6"   .+�5)      �� $��List Order Details��6   $	��150��5*      
����d�
��� �����5-      �� *View1Command+�� 5.      $��Add Item to Order��6   $	��150��5/      
����ح�
��� �����52      �� *View2Command+�� 53      $
��Exit��6   $	��150��54      
����d�
��� �����57      �� *ExitCommand+58      �� 5:   
   $��2��6   ��6&   �� *CurrentViewModel+5;      5<      