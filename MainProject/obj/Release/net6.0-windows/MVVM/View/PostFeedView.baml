   M S B A M L   `   `   `  ���� F  BMainProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MainProject.MVVM.ViewMainProject.MVVM.View  =#clr-namespace:MainProject.ComponetsMainProject.Componets  (    "MainProject.MVVM.View.PostFeedView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:MainProject.MVVM.View     9	componets#clr-namespace:MainProject.Componets     .��� .+��   � ColumnDefinitions  �� $��* ��� $
��Auto �.+��� $��0��$��Hidden=�.���� 
������ $	��525������ *Posts+���� .R���  �� CornerRadius$ 15��$��	0,10,0,10q�
�������._��� $
��auto��.+�� $��	10 10 0 0q�  �� $
��Auto ��� .+��� $��0��$��34��$��34��$��Right=�$��Center=����� *UserProfilePicture+ J� Clip @�  @� Center$ 17,17&� @� RadiusX$ 17Q� @� RadiusY$ 17Q��� ���#727EA8$��14(�$��Medium"�$��1��$
��Left=�$��Center=����� *UserProfileName+�� $��1��$
��0 10q�$
��Wrap=�$
��Left=� �� Padding$ 
10,0,10,10q����#6B6B6B$��14(����� *PostCaption+�� $��2��$��Stretch=�$��Stretch=�$
��Fill=����� *PostImagePath+� $��Bottom=�$��3��$��
0 10 10 10q�  �� $
��Auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$	��8 0q�.+�d� $��
LikeButton��   Button-Like#��[  �� $��Center=�$	��5 0q�$��1��$��14(�
����������� *	TotalLike+�� $��CommentButton��  Button-Comment#��[ $y�Visible=��� $��Center=�$	��5 0q�$��1��$��14(�
����������� *TotalComment+�� $��1��$��Right=�$��14(�
����������� *
PostDate+� $��1��$
��Auto��  �� $
��Auto ��� $
��Auto �.+��� -    ��Name$	 btn��$��0��
������ $��0q�
����������#7877CE  Button-Fill#��[ $��10q�$
��Left=�$��11��$��62��$��> Value��$��14(�$��Center=�$��Right=�$��0q��� -   $��	InfoPanel��$��1��$ 15��	 �� Padding$	 17 54 17 0 q�
 K� ZIndex$
 1��$y�Visible=����#7877CE._��  � RowDefinitions �� �� $	��100 �.+��� $	��230��$	��200��.+�� $��0��$��Center=�  �� $��50 ��� .+��� $��0 0 5 0q�$��0��$��34��$��34��$��Right=�$��Center=����� *communityCardModel.PictureUrl+ @� $ 17,17&�$ 17Q�$ 17Q��� 
�������$��Medium"�$��15(�$��1��$
��Left=�$��Center=����� *communityCardModel.Name+�� $��1�����#F4F4FB
������ $��14(�$
��Wrap=�$
��0 10q�$ 5q����� * communityCardModel.Description+� $��2��$��Center=�$��30 10q�  �� �� .+��� $��0��
������ 
�������.���� $��Center=� �� TextAlignment$ Center=� �� 
LineHeight$ 26���� $��16(�$��SemiBold"���� * communityCardModel.MemberTotal+�� �� $�Members��$��15(��� $��1��$��20 0 0 0q�
������ 
�������.���� $��Center=�$ Center=�$ 26���� $��16(�$��SemiBold"���� *communityCardModel.PostTotal+�� �� $�Posts��$��15(��� $��3��.+��� $��Owner��$��15(�
�������$
��Left=�$��10q��   �� $��50 ��� .+��� $��0 0 5 0q�$��0��$��34��$��34��$��Right=�$��Center=����� *$"communityCardModel.OwnerPictureUrl+ @� $ 17,17&�$ 17Q�$ 17Q��� $��Medium"����#F7FFEE$��15(�$��1��$
��Left=�$��Center=����� *communityCardModel.OwnerName+�� $
��0 10q�$��1��
������ 
�������.���� $ 23���� $
�Date��$��15(��� �� $��14(����#F7FFEE��� * communityCardModel.CreatedDate+�� $��4��$��New PostModel��$��15(�#��[ $��Medium"�$	��Top=�
�������$
��0 10q�$��16 10q����� *OpenWindowCommand+�� $��1��$��Leave��$��15(�$��SemiBold"�#��[ $��Bottom=�
�������$��16 10q�$
��0 10q����� *LeaveCommunity+