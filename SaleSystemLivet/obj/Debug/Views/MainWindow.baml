   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5      G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5	      K*clr-namespace:SaleSystemLivet.LocalizationSaleSystemLivet.Localization  5
      &     SaleSystemLivet.Views.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5      -v#clr-namespace:SaleSystemLivet.Views   5      3vm(clr-namespace:SaleSystemLivet.ViewModels   5	      7util*clr-namespace:SaleSystemLivet.Localization   5
        � Title$  
MainWindow��5      $	��814��5      $	��608��5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      4   .SaleSystemLivet.ViewModels.MainWindowViewModel  5   
    � 	Resources 5       �� DataType/   )SaleSystemLivet.ViewModels.IndexViewModel!   SaleSystemLivet.Views.Index1   +SaleSystemLivet.ViewModels.ProductViewModel#   SaleSystemLivet.Views.Product/   )SaleSystemLivet.ViewModels.OrderViewModel!   SaleSystemLivet.Views.Order/   )SaleSystemLivet.ViewModels.AboutViewModel!	   SaleSystemLivet.Views.About4
   .SaleSystemLivet.ViewModels.AddProductViewModel&    SaleSystemLivet.Views.AddProduct5   /SaleSystemLivet.ViewModels.EditProductViewModel'   !SaleSystemLivet.Views.EditProduct7   1SaleSystemLivet.ViewModels.ProductDetailViewModel)   #SaleSystemLivet.Views.ProductDetail6   0SaleSystemLivet.ViewModels.OrderHistoryViewModel(   "SaleSystemLivet.Views.OrderHistory   HeaderStyle �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value��%  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5       *, +)(�� �     5#      *,
 +)(�� �     5&      *, +)(�� ,    5)      *, +)(�� ^    5,      *, +)&	  �    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!      	  5"      �� 5#   
   " 
 6   .R�5$        5%      �� 5&   
   "  6   .R�5'        5(      �� 5)   
   "  6   .R�5*        5+      �� 5,   
   "  6   .R�5-        5.      �� 50   
   " ��6$   .�51      ��  � ��
 �����6+   	 53      P� 54      
 �@J�	IsFocused . . �56      ��  � ��
 �����63   57      59      5:      .  (System.Windows.Interactivity.Interaction   Triggers 5<      /  )System.Windows.Interactivity.EventTrigger  5C   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5D      .  (Livet.Behaviors.DataContextDisposeAction  5E      .��5K      �  � ColumnDefinitions 5L   
   �� 5M      �� 5N      �� 5O      �� 5P      �� 5Q       � RowDefinitions 5S   
   �� 5T      �� 5U      �� 5V      �� 5W      �� 5X      .+�5[   
   ]� $��0��6   $��0��6!   $��1��61   $��5��6B   
�������.+�5\      ��  �� Orientation$ 
Horizontal=�6   .+�5]      �� #��[  6i   $��22q�6�   $	��155��6�   $��50��6�   $��Center=�6�   $��16(�6�   ��6   �� *ShowIndexCommand+��6>   8   2SaleSystemLivet.Localization.LocalizationExtension  *Index_Button+6�   �� 5^      #��[  6m   $��22q�6�   $	��155��6�   $��50��6�   $��Center=�6�   $��16(�6�   ��6   �� *ShowProductCommand+��6@     *Product_Button+6�   �� 5_      #��[  6i   $��22q�6�   $	��155��6�   $��50��6�   $��Center=�6�   $��16(�6�   ��6   �� *ShowOrderCommand+��6>     *Order_Button+6�   �� 5`      #��[  6i   $��22q�6�   $	��155��6�   $��50��6�   $��Center=�6�   $��16(�6�   ��6   �� *ShowAboutCommand+��6>     *About_Button+6�   5a      5b      �� 5d   
   $��1��67   $��0��6D   $��5��6T   $��4��6h   ��6   �� *	ViewModel+6h   5e      5g      