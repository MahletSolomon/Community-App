using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class UserPostViewModel:ViewModelBase
{
    public PostModel _postModel { get; set; }
    public CommunityCardModel CommunityCardModel { get; set; }
    
    
    public ICommand UpdatePostCommand { get; set; }
    public ICommand DeletePostCommand;
    public UserPostWindow UserPostWindow { get; set; }
    
    public UserPostViewModel(CommunityCardModel communityCardModel,UserPostWindow userPostWindow, PostModel postModel)
    {
        CommunityCardModel = communityCardModel;
        UserPostWindow = userPostWindow;
        _postModel = postModel;
        UpdatePostCommand = new UpdatePostCommand(new UpdatePostService(_postModel),UserPostWindow);

        //UpdatePostCommand = new UpdatePostCommand(UpdatePostWindow,UpdatePostViewModel);
    }
}