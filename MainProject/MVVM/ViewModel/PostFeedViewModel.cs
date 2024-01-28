using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class PostFeedViewModel:ViewModelBase
{
    public ObservableCollection<PostModel> Posts { get; }
    public CommunityCardModel communityCardModel { set; get; }
    private ICommand ShowInfoPanel { get; }
    public string GetPicture {  get; set; }
    public string Caption { get; set; }
    
    public NewPostWindow NewPostWindow { get; set; }
    
    public ICommand OpenWindowCommand { get; set; }
    public ICommand NewPostCommand  {  get; set; }
 
    public ICommand LeaveCommunity {  get; set; }
    
    
   
    public PostFeedViewModel(CommunityCardModel communityCardModel, LoginModel loginModel)
    {
        this.communityCardModel = communityCardModel;
        NewPostWindow = new NewPostWindow();
        NewPostWindow.DataContext = this;
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
        Posts = new ObservableCollection<PostModel>();

    }

    public PostFeedViewModel(LoginModel loginModel)
    {
        this.communityCardModel = new CommunityCardModel() { Name = "letssss goo" };
        NewPostWindow = new NewPostWindow();
        NewPostWindow.DataContext = this;
        Posts = new ObservableCollection<PostModel>();
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
    }
    
}