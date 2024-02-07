using System.Windows;

namespace MainProject.MVVM.View;

public partial class UserPostWindow : Window
{
    public UserPostWindow()
    {
        InitializeComponent();
    }


    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}