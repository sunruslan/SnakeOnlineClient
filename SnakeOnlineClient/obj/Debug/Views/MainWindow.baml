   M S B A M L   `   `   `  ����L  HSnakeOnlineClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SnakeOnlineClient.ViewsSnakeOnlineClient.Views  5   	   (    "SnakeOnlineClient.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TPrism.Unity.Wpf, Version=7.1.0.431, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59R NPrism.Wpf, Version=7.1.0.431, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   1clr%clr-namespace:SnakeOnlineClient.Views   5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � WindowStyle$
 None=�5   !    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�6.    � Title 5   	   �� *Title+ J� InputBindings 5	      �� 5   
   
 �� Key$ c��66    �� Command 6   �� *ClearCommand+66   �� 5   
   $ j��65    6   �� *LeftCommand+65   �� 5   
   $ l��66    6   �� *RightCommand+66   �� 5   
   $ i��63    6   �� *	UpCommand+63   �� 5   
   $ k��65    6   �� *DownCommand+65   .��5      ]� .+�5   
   �� 
�������$	��Top=�6=   $��50(�6R   	 �� TextAlignment$	 Center=�6`   $
��Bold"�6w   ��6&   �� *Title+6w   �� 5   
   
�������$
��Left=�6(   $	��200��6>   .+�5      "   SnakeOnlineClient.Views.Menu  -   5        
  Name$

 Menu��5      $��Stretch=�6%   $��Stretch=�6C   %   SnakeOnlineClient.Views.InfoBar  5      -   5          Name$ InfoBar��5      $��Stretch=�6+   $��Stretch=�6I   5      �� 5   
   $��Right=�6   $��5q�6,   $��Center=�67   $��Center=�6T   .+�5      '   !SnakeOnlineClient.Views.GameBoard  -   5          Name$ Board��5      $��Stretch=�6+   $��Stretch=�6I   $��5q�6e   5      5      5      