   M S B A M L   `   `   `  ����J  FSaleSystemLivet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SaleSystemLivet.ViewsSaleSystemLivet.Views  5   	   G(clr-namespace:SaleSystemLivet.ViewModelsSaleSystemLivet.ViewModels  5   	   !    SaleSystemLivet.Views.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   L HLivet, Version=1.3.0.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cbW SLivet.Extensions, Version=1.0.3.0, Culture=neutral, PublicKeyToken=b0b1d3f711ef38cb0l&http://schemas.livet-mvvm.net/2011/wpf   5   	   -v#clr-namespace:SaleSystemLivet.Views   5   	   3vm(clr-namespace:SaleSystemLivet.ViewModels   5   	     � Title$  Login��5	   	   $	��350��6   $	��500��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � DataContext 5      /   )SaleSystemLivet.ViewModels.LoginViewModel  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      .  (Livet.Behaviors.DataContextDisposeAction  5      9  3Livet.Behaviors.Messaging.InteractionMessageTrigger  5   
      
MessageKey$ ShowMainWindow��6&      	Messenger 6B   �� *	Messenger+. 5      B  <Livet.Behaviors.Messaging.TransitionInteractionMessageAction  	   
WindowType&    SaleSystemLivet.Views.MainWindow"	  63   
   Mode$
 Modal=�6V   5        5   
   $ CloseLoginWindow��6&    6D   �� *	Messenger+. 5       F	  @Livet.Behaviors.Messaging.Windows.WindowInteractionMessageAction	  5!      .��5%      � .+�5&   
   �� -   5        $��LoginHeading��5&   N   $��23��6   $
��Left=�6    $��	10,10,0,0q�6;   $��Login:��6b   $	��Top=�6p   $��17(�6�   $��ExtraCondensed&�6�   �� 5'   
   -   5        $��textBlockHeading��5'   N   $��50��6   $
��Left=�6    $��	24,48,0,0q�6;   $	��Top=�6f   $��12(�6~   $��Italic$�6�    �� Padding$ 5q�6�   ][Note: Please login here to view the features of this site. If you are new on this site then�� 5(   j   please click on this �� 5+      �� 5,      $��14(�6   $��Normal$�6+   .�6>   
Register6H   5-       link.50      �� 51   
   $��	Username:��6   $��23��6%   $
��Left=�61   $��
58,120,0,0q�6L   $	��Top=�6`   $��67��6x   �� 52   
   $��	Password:��6   $��23��6%   $
��Left=�61   $��
58,168,0,0q�6L   $	��Top=�6`   $��77��6x   �� 53   
   $��23��6,   $
��Left=�68   $��125,120,0,0q�6S   $	��Top=�6h   $	��247��6�   ��6   �� *
Username+6�   G� 54   
   $��23��6   $
��Left=�6"   $��125,168,0,0q�6=   $	��Top=�6R   $	��247��6j      	Behaviors 55      F
  @Livet.Behaviors.ControlBinding.PasswordBoxBindingSupportBehavior
  56       
  Password 66   �� *
Password+58      �� 59   
   $��Login��62   $��23��6B   $
��Left=�6N   $��125,213,0,0q�6i   $	��Top=�6~   $	��104��6�   ��6   �� *LoginCommand+6�   �� 5:   
   $��23��62   $
��Left=�6>   $	��Top=�6Y   $	��247��6q   $��118,253,0,0q�6}    J� OpacityMask
 �<�����	#FFE5572C��6   �� *ErrorMessage+6�   5;      5<      