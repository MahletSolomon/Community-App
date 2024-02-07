using System.Windows;
using System.Windows.Controls;
using MainProject.MVVM.ViewModel;

namespace MainProject.MVVM.View;

public partial class CommentWindow : Window
{
    
    
    public CommentWindow()
    {
        InitializeComponent();
        
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Hide();

    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        senderTB.Text = "";
    }

    private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is ScrollViewer scrollViewer)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.ScrollableHeight);
        }
    }

    private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is ScrollViewer scrollViewer)
        {
            scrollViewer.ScrollToBottom();
        }
    }
}