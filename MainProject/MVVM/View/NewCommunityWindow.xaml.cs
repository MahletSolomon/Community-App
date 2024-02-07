using System.Windows;
using System.Windows.Input;

namespace MainProject.MVVM.View;

public partial class NewCommunityWindow : Window
{
    public NewCommunityWindow()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}