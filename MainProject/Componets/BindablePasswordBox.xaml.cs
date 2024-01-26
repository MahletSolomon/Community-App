using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MainProject.Custom_Controls;

public partial class BindablePasswordBox : UserControl
{
    private bool _isPasswordChanging;

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), 
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                PasswordPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

    private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        
        if(d is BindablePasswordBox passwordBox)
        {
            passwordBox.UpdatePassword();
        }
    }

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }
    

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;

        if (passwordBox.Password.Length == 0)
            passwordBox.Background = Brushes.Transparent;
        else
            passwordBox.Background = Brushes.White;
        
        
        _isPasswordChanging = true;
        Password = passwordBox.Password;
        _isPasswordChanging = false;
    }

    private void UpdatePassword()
    {
        if(!_isPasswordChanging)
        {
            passwordBox.Password = Password;
        }
    }
    public BindablePasswordBox()
    {
        InitializeComponent();
    }
    public static readonly DependencyProperty UserControlMarginProperty =
        DependencyProperty.Register("UserControlMargin", typeof(Thickness), typeof(BindablePasswordBox));

    public Thickness UserControlMargin
    {
        get { return (Thickness)GetValue(UserControlMarginProperty); }
        set { SetValue(UserControlMarginProperty, value); }
    }
    public static readonly DependencyProperty UserControlTagProperty =
        DependencyProperty.Register("UserControlTag", typeof(string), typeof(BindablePasswordBox));

    public string UserControlTag
    {
        get { return (string)GetValue(UserControlTagProperty); }
        set { SetValue(UserControlTagProperty, value); }
    }
    
    


  
    

}

