   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5   	   G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5   	   K*clr-namespace:SaleSystemLivet.LocalizationSaleSystemLivet.Localization  5	   	   (    "SaleSystemLivet.Views.OrderHistory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5   	   -v#clr-namespace:SaleSystemLivet.Views   5   	   3vm(clr-namespace:SaleSystemLivet.ViewModels   5   	   7util*clr-namespace:SaleSystemLivet.Localization   5	   	   $	��500��5
   	   $	��800��6     � DataContext  5      6   0SaleSystemLivet.ViewModels.OrderHistoryViewModel  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (Livet.Behaviors.DataContextDisposeAction  5      .��5      � 
�������.+�5    
   �� $��Center=�6   $��18(�6-   ��6;   8   2SaleSystemLivet.Localization.LocalizationExtension  *Order_History_View+6n   �� 5!   
    �� Orientation$ Vertical=�6   .+�5"      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows . $��5,35,5,5q�5#      $��Stretch=�6)   $��Stretch=�6G      RowBackground �#fff$
��Bold"�5$      ���#525252��. $	��376��5%      $	��376��6$   $	��769��64   	   AlternatingRowBackground	 �#f2f2f2���#000$��1q�6y   $��Visible=�5&      $
��Auto=�6L   ��5"      �� *	OrderList+
   Columns
 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 61
 6r    	  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *	OrderId+ 	  Header 6E     *Order_ID_Column+6}     5)      $	 120
 6I    .  6)   �� *ProductName+ 6U     *Product_Name_Column+6�     5*      $	 180
 6�    .  6)   �� *Description+ 6I     *Product_Description_Column+6�     5+      $	 100
 6s    .  6)   �� *Unit+ 6B     *Product_Unit_Column+6     5,      $	 100
 6t    .  6)   �� *Price+ 6C     *Retail_Price_Column+6�     5-      $	 100
 6s    .  6)   �� *
Quantity+ 6F     *Quantity_Column+6     5.      $	 100
 6x    .  6)   �� *
TotalPrice+ 6H     *Total_Price_Column+6�   50      � 51      .+�52      �� $��Quantity (All):��6   $��Right=�62   $��	5,5,280,5q�6N   �� 53      $��Price (All):��6   $��Right=�6/   $��	5,5,115,5q�6K   �� 54      $	��100��67   $��20��6C   $��Right=�6O   $��	5,5,180,5q�6k    �� 
IsReadOnly . 
���������6   �� *AllQuantity+6�   �� 55      $	��100��64   $��20��6@   $��Right=�6L   $��5,5,15,5q�6h    . 
���������6   �� *
AllPrice+6�   56      57      58      59      