   M S B A M L   `   `   `  ���� F  BMainProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MainProject.MVVM.ViewMainProject.MVVM.View  G(clr-namespace:MainProject.MVVM.ViewModelMainProject.MVVM.ViewModel  )    #MainProject.MVVM.View.NewPostWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:MainProject.MVVM.View     >	viewmodel(clr-namespace:MainProject.MVVM.ViewModel       � SizeToContent$  WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True��.����  �� CornerRadius$ 20��$��30q�
������� �� Padding$ 5q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   
BlurRadius$ 23Q�	   Color$	 #D1D5FE��._�� 
 � RowDefinitions
 �� $
��Auto ��� .+��� $
��Left=�$��Center=�$��Create PostModel�����#A483EA$��30(�$��SemiBold"�$��25 10q��� $��1��$��25 15 q�$��Center=�.+��� -   $��
btnPicture��$��+��$��Center=�$	��160��$	��100��$��50(�$	��0 0q�$��Center=�   Button-Fill#��[  ���� *
GetPicture+�� -   $��
txtCaption��$��2�� �� TextWrapping$
 Wrap=�$��14(�$��Medium"�$	��120��$��Stretch=�$��3q�  TextBoxStyle#��[ $��15q�$��
15 18 15 8q����� *	Caption+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��	PostModel��$��40��$��20(�$��SemiBold"�$��18 20q�$��Stretch=�$��Center=�#��[  ���� *NewPostCommand+