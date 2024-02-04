using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Services;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class UserPostViewModel:ViewModelBase
{
    
    private PostModel postModel;

    public PostModel PostModel
    {
        get { return postModel;}
        set { postModel = value; OnPropertyChanged(); }
    }
    public CommunityCardModel communityCardModel { get; set; }
    
    
    public ICommand UpdatePostCommand { get; set; }
    public ICommand DeletePostCommand { get; set; }
    public UserPostWindow UserPostWindow { get; set; }
    
    public UserPostViewModel(CommunityCardModel communityCardModel,UserPostWindow userPostWindow, PostModel postModel)
    {
        this.communityCardModel = communityCardModel;
        UserPostWindow = userPostWindow;
        PostModel = postModel;
        UpdatePostCommand = new UpdatePostCommand(new UpdatePostService(this), UserPostWindow);
        DeletePostCommand = new DeletePostCommand(new DeletePostService(this), UserPostWindow);
        //UpdatePostCommand = new UpdatePostCommand(UpdatePostWindow,UpdatePostViewModel);
    }
}