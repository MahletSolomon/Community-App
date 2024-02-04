using System.Windows;
using System.Windows.Controls;

namespace MainProject.MVVM.View;

public partial class AccountView : UserControl
{
    public AccountView()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Window parentWindow = Window.GetWindow(this);
        if (parentWindow != null && parentWindow.IsLoaded)
        {
            parentWindow.Close();
        }
    }
}