using System.Windows;

namespace MainProject.MVVM.View;

public partial class JoinCommunityWindow : Window
{
    public JoinCommunityWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}