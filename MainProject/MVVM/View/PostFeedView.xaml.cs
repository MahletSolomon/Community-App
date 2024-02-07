using System.Windows;
using System.Windows.Controls;

namespace MainProject.MVVM.View;

public partial class PostFeedView : UserControl
{
    public PostFeedView()
    {
        InitializeComponent();
    }
    
    private void ToggleButton_Checked(object sender, System.Windows.RoutedEventArgs e)
    {
        if (InfoPanel.Visibility == Visibility.Visible)
        {
            InfoPanel.Visibility = Visibility.Collapsed;
            btn.Content = "<";
            btn.Visibility = Visibility.Visible;
        }

        else
        {
            InfoPanel.Visibility = Visibility.Visible;
            btn.Content = ">";
            btn.Visibility = Visibility.Visible;
        }
        
    }

    private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is ScrollViewer scrollViewer)
        {
            scrollViewer.ScrollToTop();
        }
    }
}