using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;

namespace MainProject.MVVM.ViewModel;

public class PostFeedViewModel:ViewModelBase
{
    public ObservableCollection<Post> Posts { get; }
    private ICommand ShowInfoPanel { get; }
    public string GetPicture {  get; set; }
    


    public NewPostWindow NewPostWindow { get; set; }
    
    public ICommand OpenWindowCommand { get; set; }
    public ICommand NewPostCommand  {  get; set; }
 
    public ICommand LeaveCommunity {  get; set; }
    public string Caption { get; set; }
    public PostFeedViewModel(CommunityCardModel communityCardModel)
    {
        NewPostWindow = new NewPostWindow();
        NewPostWindow.DataContext = this;
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, this);
        Posts = new ObservableCollection<Post>();

    }

    public PostFeedViewModel()
    {
        NewPostWindow = new NewPostWindow();
        NewPostWindow.DataContext = this;
        Posts = new ObservableCollection<Post>();
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, this);
    }
    
}