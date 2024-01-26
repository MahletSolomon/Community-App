using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using WpfApp1.Commands;

namespace MainProject.MVVM.ViewModel;

public class PostFeedViewModel:ViewModelBase
{
    public ObservableCollection<Post> Posts { get; }
    private ICommand ShowInfoPanel { get; }
    public PostFeedViewModel(CommunityCardModel communityCardModel)
    {
        // MessageBox.Show(communityCardModel.Name);
    }

    public PostFeedViewModel()
    {
        Posts = new ObservableCollection<Post>();
    }
    
}