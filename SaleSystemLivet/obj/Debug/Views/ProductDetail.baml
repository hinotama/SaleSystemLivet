   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5   	   G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5   	   K*clr-namespace:SaleSystemLivet.LocalizationSaleSystemLivet.Localization  5	   	   A%clr-namespace:SaleSystemLivet.HelpersSaleSystemLivet.Helpers  5
   	   )    #SaleSystemLivet.Views.ProductDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5   	   -v#clr-namespace:SaleSystemLivet.Views   5   	   3vm(clr-namespace:SaleSystemLivet.ViewModels   5   	   7util*clr-namespace:SaleSystemLivet.Localization   5	   	   4helper%clr-namespace:SaleSystemLivet.Helpers   5
   	   $	��500��5   	   $	��800��6     � DataContext  5      7   1SaleSystemLivet.ViewModels.ProductDetailViewModel  5   
    � 	Resources 5      *   $SaleSystemLivet.Helpers.BindingProxy   BindingProxy   Data �� RelativeSource �� AncestorType �� Path��%W   &	          5   
    63   ��  �� *FindAncestor+" �$ DataContext�5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (Livet.Behaviors.DataContextDisposeAction  5      9  3Livet.Behaviors.Messaging.InteractionMessageTrigger  5!   
   	   
MessageKey$	 Confirm��6&   
   	Messenger
 6;   �� *	Messenger+. 5"      J  DLivet.Behaviors.Messaging.ConfirmationDialogInteractionMessageAction  5#      .��5'      � 
�������.+�5*   
   �� $��18(�6   $��Center=�6N   $��0,10,0,0q�6k   $	��Top=�6}   ��6   8	   2SaleSystemLivet.Localization.LocalizationExtension	  *Show_Product_View+6}   �� 5-   
   $��Right=�6<   $��
0,60,470,0q�6X   $	��Top=�6l   ��6   	  *Product_Label+6l   �� 5.   
   $��Right=�6@   $��0,103,470,0q�6\   $	��Top=�6q   ��6   	  *Description_Label+6q   �� 5/   
   $��Right=�69   $��0,246,470,0q�6U   $	��Top=�6j   ��6   	  *
Unit_Label+6j   �� 50   
   $��Right=�6:   $��0,289,470,0q�6V   $	��Top=�6k   ��6   	  *Price_Label+6k   �� 53   
    �� 
IsReadOnly . 
�������$��Center=�55      $��23��6*   $��0,60,0,0q�66   $	��Top=�6H   $	��120��6`   ��56      �� *Product.ProductName+ �� Mode$ TwoWay=� �� NotifyOnValidationError . " �� ValidatesOnNotifyDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��5<   
    =� ErrorTemplate 5=      �� 5>      .R�5?      �� .+�5A      ��  ��Name$ textBox��64   �� 5B      ��6'   �� ��5C      �� 5D   "   .R�5E   &   �� 
���  ����60   �� *ErrorContent+6N   5F   #   5H      5I      5J      .��5K   (   5L      �� 5N   
    . 
�������$��Center=�5P      $	��123��6*   $��120,103,0,0q�67    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��240��6x   ��5Q      �� *Product.Description+$ TwoWay=� .  . $ PropertyChanged=�.��5W   
    5X      �� 5Y      .R�5Z      �� .+�5\      �� $ textBox��64   �� 5]      ��6'   �� ��5^      �� 5_   "   .R�5`   &   �� 
���  ����60   �� *ErrorContent+6N   5a   #   5c      5d      5e      .��5f   (   5g      �� 5i   
    . 
�������$��Center=�5k      $��23��6*   $��	0,246,0,0q�66   $	��Top=�6I   $	��120��6a   ��5l      �� *Product.Unit+$ TwoWay=� .  . $ PropertyChanged=�.��5r   
    5s      �� 5t      .R�5u      �� .+�5w      �� $ textBox��64   �� 5x      ��6'   �� ��5y      �� 5z   "   .R�5{   &   �� 
���  ����60   �� *ErrorContent+6N   5|   #   5~      5      5�      .��5�   (   5�      �� 5�   
    . 
�������$��Center=�5�      $��23��6*   $��	0,289,0,0q�66   $	��Top=�6I   $	��120��6a   ��5�      �� *Product.Price+$ TwoWay=� .  . $ PropertyChanged=�.��5�   
    5�      �� 5�      .R�5�      �� .+�5�      �� $ textBox��64   �� 5�      ��6'   �� ��5�      �� 5�   "   .R�5�   &   �� 
���  ����60   �� *ErrorContent+6N   5�   #   5�      5�      5�      .��5�   (   5�      �� 5�   
   $��Center=�5�      $��75,332,120,0q�6*   $	��Top=�6@   $��75��6X   ��5�      �� *Data.ShowEditProductCommand+ �� Source# [  ��5�      �� *Product.ProductId+��5�      	  *Edit_Button+�� 5�   
   $��Center=�5�      $��120,332,0,0q�6*   $	��Top=�6?   $��75��6W   ��5�      �� *DeleteProductCommand+��5�      �� *Product.ProductId+��5�      	  *Delete_Button+�� 5�   
   $
��Left=�6b   $��340,356,0,0q�6}   $
��Wrap=�6�   $	��Top=�6�   ��6   �� *ResponseTextBlock+��67   �� *ForegroundTextBlock+6�   5�      5�      