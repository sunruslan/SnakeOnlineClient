   M S B A M L   `   `   `  ����  SnakeOnlineClient"    SnakeOnlineClient.Views.Menu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TPrism.Unity.Wpf, Version=7.1.0.431, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59R NPrism.Wpf, Version=7.1.0.431, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5         StartButton �� 
TargetType �� Property �� Value  
ExitButton  MyWaterMarkStyle �� 
TargetType ��Name ��Name
 � Tag	 �� Triggers
 ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        &	 �     &	 �    �� 5   
   " ��6$   .�5      ��  � ��
 � � �6+   �� 5	       � ��
 �����6+   �� 5
       � ��$ 30(�6)   �� 5       � ��$ 2,2,2,2q�6'   �� 5       � ��$ 1q�60   5      �� 5   
   " ��6#   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �����6+   �� 5       � ��$ 30(�6)   �� 5       � ��$ 2,2,2,2q�6'   �� 5       � ��$ 1q�60   5      �� 5   
   " ��6)   .�5      ��  � ��$ Center=�62   �� 5       �@��TextWrapping$ NoWrap=�6-   �� 5       � ��$ 2,2,2,2q�6'   �� 5       � ��$ 45��6'   �� 5       �@��TextAlignment$ Center=�6.   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5       � .+�5!      �� 
����������	#FF7D8683$��1q�6P   �� 5"      $ PART_ContentHost��6+   $��0,0,0,0q�6E   $��Center=�6V   �� 5#      $ WaterMarkLabel��65   $��0,0,0,0q�6$   #��z 6M   $��Center=�6m   $y�	Collapsed=�5$       
�������$��Arial)�6I   $��Center=�6\   5%      	 5&      ]� 5'      
 5(   "   �� 5)   &    � ��$  ��6@   ./�5+   "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   5,      P� 5-       � {� .  . �5.   "   ��  � ��
 �iii�6?   5/      51      53      54      55      .��56      ��  �� Orientation$ Vertical=�6   .+�57   
   �� #��[ 6.   $ Token��6X   ��6   ��  �� Path$ Token�6X   �� 58   
   #��[  6   $��Start!��67   ��6H   �� $ StartCommand��� 59   
   -   5        #��[ 59      $
��Exit��66   6E   5:      5;      