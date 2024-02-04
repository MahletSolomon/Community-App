using System.Windows;

namespace MainProject.MVVM.View;

public partial class UserPostWindow : Window
{
    public UserPostWindow()
    {
        InitializeComponent();
    }

    private void UIElement_OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        
    }

    private void ToggleBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (ToggleBtn.IsChecked==true)
        {
            UpdateGrid.Visibility = Visibility.Visible;
        }
        else if(ToggleBtn.IsChecked==false)
        {
            UpdateGrid.Visibility = Visibility.Collapsed;
        }
    }
}