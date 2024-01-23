using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MainProject.MVVM.View;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }
    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;

        if (passwordBox.Password.Length == 0)
            passwordBox.Background = Brushes.Transparent;
        else
            passwordBox.Background = Brushes.White;
    }
}