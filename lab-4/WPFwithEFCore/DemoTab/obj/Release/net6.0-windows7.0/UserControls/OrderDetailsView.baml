   M S B A M L   `   `   `  ����   DemoTab+    %DemoTab.UserControls.OrderDetailsView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .���   � ColumnDefinitions  �� �� $��0* � � RowDefinitions �� $
��Auto ��� $��* �.+��� $��	10,0,10,0q� �� Orientation$ 
Horizontal=�.+��� $��
Baskets:  ��$��Center=��� -    �� DisplayMemberPath$ DisplayText�� �� SelectedValuePath$ IdBasket��$��22��$	��392������ *	Baskets+ �� SelectedItem �� *SelectedBasket+ �� Mode$ TwoWay=�&   System.Windows.Controls.DataGrid  $��1��$��10,10,10,10q�   AutoGenerateColumns$ False������ *BasketItems+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Basket ID��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Basket.IdBasket+  $	 BasketItem ID��
 �� *IdBasketItem+  $	 
Product ID��
 �� *Product.IdProduct+  $	 Product Name��
 �� *Product.ProductName+  $	 
Unit Price��
 �� *Product.Price+ �� StringFormat$ C��  $	 Quantity��
 �� *
Quantity+