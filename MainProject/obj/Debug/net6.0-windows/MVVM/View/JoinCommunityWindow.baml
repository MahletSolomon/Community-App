   M S B A M L   `   `   `  ����F  BMainProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MainProject.MVVM.ViewMainProject.MVVM.View  5   	   G(clr-namespace:MainProject.MVVM.ViewModelMainProject.MVVM.ViewModel  6;   /    )MainProject.MVVM.View.JoinCommunityWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MainProject.MVVM.View     5   	   >	viewmodel(clr-namespace:MainProject.MVVM.ViewModel     6;     � Title$  NewCommunityWindow��5   	   $	��350��6$   $	��600��61    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency$
 True��5   	   .��5      ��  �� CornerRadius$ 10��6   $��30q�6    
������� �� Padding$ 5q�6@   
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6      
BlurRadius$ 23Q�6/   	   Color$	 #333333��6?   
   Opacity$	
 0.4Q�6O   ._�5   
   � $��Stretch=�6   $��Stretch=�6-   $	�� 05q�6K    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      6"   �� 5      6"   .+�5      ]� $	��0 5q�6   .+�5      �� $��Bottom=�6D   $��0 4 0 0q�6]   $��16(�6n   ���#252878 J� Opacity$	 0.8Q�6�   $��SemiBold"�6�   $��Center=�6�   $��Bottom=�6�   ��6   �� *CommunityCardModel.Name+6�   � 5      $��Bottom=�6    J� OpacityMask 5      !� 5       !� Visual 6%   ��  �� ElementName$ Border2��.+�5      �� -   5         ��Name$ Border2��5       $	��100��5      $	��100��5      $��Center=�5!      $ 50��5"      ���#D7DADB5#      �� 5%      $	��100��5&      $	��100��5'      $��UniformToFill=�5)      ��5(      �� *CommunityCardModel.PictureUrl+5+      5,      5.      � 5/      $��1��6   $��Center=�6     � ColumnDefinitions 50      �� 51      �� 52      .+�54      �� $��1��6   $
��30 0q�6,   $
��Left=�6:   $	��Top=�6U    �� TextAlignment$ Center=�6m    �� 
LineHeight$ 20��6�   ���#748493�� 55      $��18(�6I   $��SemiBold"�6W   �6   �� *CommunityCardModel.PostTotal+6W   �� 56      �� 57      $�Posts��6   $��16(�6'   58      �� 59      $��0��6   $
��30 0q�6,   $��Right=�6:   $	��Top=�6V   $ Center=�6n   $ 20��6�   ���#748493�� 5:      $��18(�6K   $��SemiBold"�6Y   �6   �� * CommunityCardModel.MemberTotal+6Y   �� 5;      �� 5<      $�Member��6   $��16(�6(   5=      5>      � 5?      $��2��6    5@      �� 5A      �� 5B      .+�5D      �� -   5        $��Bottom=�5D      $
��Back��65   $��8q�6D   $��5q�6P      Button-Fill#��[  6[   6�   �� 5E      $��1��6   $��Bottom=�6*   $
��Join��6E   $��8q�6T   $��5q�6`     Button-Edge#��[ 6k   ��6�   �� *JoinCommunityCommand+5F      5G      5I      5K      