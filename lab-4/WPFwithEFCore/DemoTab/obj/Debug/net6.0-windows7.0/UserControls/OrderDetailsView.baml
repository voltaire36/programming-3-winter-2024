   M S B A M L   `   `   `  ����  DemoTab+    %DemoTab.UserControls.OrderDetailsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �   � ColumnDefinitions  5	   
   �� 5
      �� 5      $��0* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��	10,0,10,0q�6    �� Orientation$ 
Horizontal=�6(   .+�5      �� $��
Baskets:  ��6   $��Center=�6*   �� 5      -   5         �� DisplayMemberPath$ DisplayText��5       �� SelectedValuePath$ IdBasket��5      $��22��5      $	��392��5   :   ��5      �� *	Baskets+ �� SelectedItem 5      �� *SelectedBasket+ �� Mode$ TwoWay=�5   :   5      &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��10,10,10,10q�6       AutoGenerateColumns$ False��6Y   ��65   �� *BasketItems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Basket ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *Basket.IdBasket+  5!      $	 BasketItem ID��6%   
 6<   �� *IdBasketItem+  5"      $	 
Product ID��6%   
 69   �� *Product.IdProduct+  5#      $	 Product Name��6%   
 6;   �� *Product.ProductName+  5$      $	 
Unit Price��6%   
 69   �� *Product.Price+ �� StringFormat$ C��  5%      $	 Quantity��6%   
 67   �� *
Quantity+5'      5(      5)      