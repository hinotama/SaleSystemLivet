   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5   	   G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5   	   K*clr-namespace:SaleSystemLivet.LocalizationSaleSystemLivet.Localization  5	   	   A%clr-namespace:SaleSystemLivet.HelpersSaleSystemLivet.Helpers  5
   	   #    SaleSystemLivet.Views.Product   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5   	   -v#clr-namespace:SaleSystemLivet.Views   5   	   3vm(clr-namespace:SaleSystemLivet.ViewModels   5   	   7util*clr-namespace:SaleSystemLivet.Localization   5	   	   4helper%clr-namespace:SaleSystemLivet.Helpers   5
   	   $	��500��5   	   $	��800��6     � DataContext  5      1   +SaleSystemLivet.ViewModels.ProductViewModel  5   
    � 	Resources 5      *   $SaleSystemLivet.Helpers.BindingProxy   BindingProxy   Data �� RelativeSource �� AncestorType �� Path��%W   &	          5   
    63   ��  �� *FindAncestor+" �$ DataContext�5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (Livet.Behaviors.DataContextDisposeAction  5      9  3Livet.Behaviors.Messaging.InteractionMessageTrigger  5!   
   	   
MessageKey$	 Confirm��6&   
   	Messenger
 6;   �� *	Messenger+. 5"      J  DLivet.Behaviors.Messaging.ConfirmationDialogInteractionMessageAction  5#      .��5'      � 
�������.+�5(   
   �� $��Center=�6;   $��18(�6X   ��6   8	   2SaleSystemLivet.Localization.LocalizationExtension	  *Product_View+6h   �� 5)   
    �� Orientation$ Vertical=�6   .+�5*      �� $��
10,30,10,5q�5/      $��5q�6%   $
��Left=�61   ��5+      �� *Data.ShowAddProductCommand+ �� Source# [  ��5.      	  *Add_New_Product_Button+5/   1   &
   System.Windows.Controls.DataGrid
  50      -   5         
 Name$ productDataGrid��50       
  AutoGenerateColumns .   
  CanUserAddRows .  $��5q�6�   $��Stretch=�51      $��Stretch=�65    
  RowBackground �#fff$
��Bold"�6f   ���#525252��. $	��343��52      $	��343��6$   $	��769��64    
  AlternatingRowBackground �#f2f2f2���#000$��1q�6y   $��Visible=�53      $
��Auto=�6L   ��50   0   �� *ProductList+ 
  Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6{      
IsReadOnly .    Header 6)   	  *Product_ID_Column+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� $ 	ProductId�6�   4  .System.Windows.Controls.DataGridTemplateColumn  56      $	 100 6^    .  6-   	  *Product_Name_Column+   CellTemplate 57      �� 58      .R�59   "   �� �� 5:   &    �� Command 5;   )   �� *Data.ShowProductDetailCommand+# [   �� CommandParameter 5>   )   �� $ 	ProductId�.�6U   .�5?   *   �� ��64   �� $ ProductName�5@   '   5A   #   5B      5D        5E      $	 300 6�    .  6)   	  *Product_Description_Column+ 6a   �� $ Description�6�     5F      $	 102 6x    .  6)   	  *Product_Unit_Column+ 6Z   �� $
 Unit�6�     5G      $	 102 6z    .  6)   	  *Product_Price_Column+ 6[   �� $ Price�6�     5H       6-   	  *Product_Edit_Column+ 5I      �� 5J      .R�5K   "   �� $��50��5P   )   ��5K   )   �� *Data.ShowEditProductCommand+# [  ��5N   )   �� $ 	ProductId���5O   )   	  *Product_Edit_Column+5P   )   5Q      5S        5T       6-   	  *Product_Delete_Column+ 5U      �� 5V      .R�5W   "   �� $��50��5\   )   ��5W   )   �� $&  DataContext.DeleteProductCommand� �� " 
 ��5Z   )   �� $ 	ProductId���5[   )   	  *Product_Delete_Column+5\   )   5]      5_      5a      � 5b      .+�5c      �� $
��Prev��6>   $��Center=�6M   $��0,3,60,0q�6j   $	��Top=�6|   $��30��6�   $��20��6�   {�6   �� *PreviousButton+ 5d        5e      $ Click��6)   . 5f      +  %Livet.Behaviors.LivetCallMethodAction     
MethodName$ PreviousPage��66      MethodTarget 6P   ��  �� Mode$ OneWay=�5g      5i      �� 5j      $
��Next��6:   $��Center=�6I   $��60,3,0,0q�6f   $	��Top=�6x   $��30��6�   $��20��6�   {�6   �� *
NextButton+ 5k        5l      $ Click��6)   . 5m        $ NextPage��66    6L   �� $ OneWay=�5n      5p      �� 5q      $��Center=�68   $��0,0,0,0q�6U   ��6   �� *CurrentPage+6U   5r      5s      5t      5u      