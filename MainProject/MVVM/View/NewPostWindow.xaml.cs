using System.Windows;
using System.Windows.Input;

namespace MainProject.MVVM.View;

public partial class NewPostWindow : Window
{
    public NewPostWindow()
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