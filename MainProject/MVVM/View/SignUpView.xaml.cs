using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MainProject.MVVM.View;

public partial class SignUpView : UserControl
{
    public SignUpView()
    {
        InitializeComponent();
    }
 

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;

        if (passwordBox.Password.Length == 0)
            passwordBox.Background = Brushes.Transparent;
        else
            passwordBox.Background = Brushes.White;

        if (this.DataContext != null)
        { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        
    }
}