   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5   	   G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5   	   K*clr-namespace:SaleSystemLivet.LocalizationSaleSystemLivet.Localization  5	   	   A%clr-namespace:SaleSystemLivet.HelpersSaleSystemLivet.Helpers  5
   	   !    SaleSystemLivet.Views.Order   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5   	   -v#clr-namespace:SaleSystemLivet.Views   5   	   3vm(clr-namespace:SaleSystemLivet.ViewModels   5   	   7util*clr-namespace:SaleSystemLivet.Localization   5	   	   4helper%clr-namespace:SaleSystemLivet.Helpers   5
   	   $	��500��5   	   $	��800��6     � DataContext  5      /   )SaleSystemLivet.ViewModels.OrderViewModel  5   
    � 	Resources 5      *   $SaleSystemLivet.Helpers.BindingProxy   BindingProxy   Data �� RelativeSource �� AncestorType �� Path��%W   &	          5   
    63   ��  �� *FindAncestor+" �$ DataContext�5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (Livet.Behaviors.DataContextDisposeAction  5      9  3Livet.Behaviors.Messaging.InteractionMessageTrigger  5!   
   	   
MessageKey$	 Confirm��6&   
   	Messenger
 6;   �� *	Messenger+. 5"      J  DLivet.Behaviors.Messaging.ConfirmationDialogInteractionMessageAction  5#      .��5'      � 
�������.+�5(   
   �� $��Center=�6   $��18(�6-   ��6;   8	   2SaleSystemLivet.Localization.LocalizationExtension	  *
Order_View+6f   �� 5)   
    �� Orientation$ Vertical=�6   .+�5*      �� $��
10,30,10,5q�6l   $��5q�6�   $
��Left=�6�   ��6   �� *AddOrderCommand+��69   	  *Add_New_Order_Button+6�   �� 5+      $��110,-32,10,5q�50      $��5q�6'   $
��Left=�63   ��5,      �� *Data.ShowOrderHistoryCommand+ �� Source# [  ��5/      	  *View_Order_History_Button+50   3   �� 51      $��10,-32,10,5q�6n   $��5q�6�   $��Right=�6�   ��6   �� *SubmitOrderCommand+��6<   	  *Submit_Order_Button+6�   &
   System.Windows.Controls.DataGrid
  52       
  AutoGenerateColumns .   
  CanUserAddRows .   
  CanUserDeleteRows . $��5q�53      $��Stretch=�6"   $��Stretch=�6@    
  RowBackground �#fff$
��Bold"�54      ���#525252��.  
  CanUserSortColumns .  $	��341��55      $	��341��6$   $	��769��64    
  AlternatingRowBackground �#f2f2f2���#000$��1q�6y   $��Visible=�56      $
��Auto=�6L   ��52      �� *	OrderList+ 
  Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  58      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 121 6^      Header 6-   	  *Product_Name_Column+   CellTemplate 59      �� 5:      .R�5;   "   ��  �� SelectedValuePath$ 	ProductId��5?   %    �� DisplayMemberPath$ ProductName��5@   %   ��5<   %   �� $ DataContext.ProductList� �� " 
  �� SelectedValue 5A   %   �� *	ProductId+ �� UpdateSourceTrigger$ PropertyChanged=�5D      5F      0  *System.Windows.Controls.DataGridTextColumn  5G      $	 160 6�      
IsReadOnly .  6)   	  *Product_Description_Column+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *Description+6�     5H      $	 120 6s    .  6)   	  *Product_Unit_Column+ 6Z   �� *Unit+6     5I      $	 120 6t    .  6)   	  *Retail_Price_Column+ 6Z   �� *Price+6�     5J      $	 120 6s    6)   	  *Quantity_Column+ 6V   �� *
Quantity+6s     5K      $	 120 6x    .  6)   	  *Total_Price_Column+ 6Y   �� *
TotalPrice+6�     5L       .    
Visibility$ Hidden=�6`    6)   �� *TotalPriceBefore+6`    5N        5O      $ CurrentCellChanged��6%   . 5P      +  %Livet.Behaviors.LivetCallMethodAction     
MethodName$ CalculateGridTotal��62      MethodTarget 6R   ��   �� Mode$  OneWay=�5Q      5S      � 5T      .+�5U      �� $��Quantity (All):��6   $��Right=�62   $��	5,5,280,5q�6N   �� 5V      $��Price (All):��6   $��Right=�6/   $��	5,5,115,5q�6K   �� 5W      $	��100��6\   $��20��6h   $��Right=�6t   $��	5,5,180,5q�6�   ! �� 
IsReadOnly! . 
���������6   �� *AllQuantity+$ PropertyChanged=�6�   �� 5X      $	��100��6Y   $��20��6e   $��Right=�6q   $��5,5,15,5q�6�   ! . 
���������6   �� *
AllPrice+$ PropertyChanged=�6�   5Y      5Z      5[      5\      