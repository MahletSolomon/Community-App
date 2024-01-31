using System.Collections.Generic;
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
    public Dictionary<int, ObservableCollection<PostModel>> _postStorage { set; get; }
    private ObservableCollection<PostModel> _posts;
    public ObservableCollection<PostModel> Posts
    {
        get => _posts;
        set
        {
            _posts = value;
            OnPropertyChanged();
        } }
    public CommunityCardModel communityCardModel { set; get; }


    public LoginModel _LoginModel;
    private ICommand ShowInfoPanel { get; }
    public ICommand OpenPostWindowCommand { get; set; }
    public ICommand LikedCommand { set; get; }
    public ICommand LeaveCommunityCommand  {  get; set; }
    public ICommand RefreshCommand  {  get; set; }
    public ICommand OpenCommentWindow { get; set; }
    
    
    public UserInformationModel _userInformationModel;


 

    public HomeViewModel HomeViewModel;
    public PostFeedViewModel(ObservableCollection<PostModel> posts, LoginModel loginModel,UserInformationModel userInformationModel,HomeViewModel homeViewModel,CommunityCardModel communityCardModel,Dictionary<int, ObservableCollection<PostModel>> PostStorage=null)
    {
        _postStorage = PostStorage;
        Posts = posts;
        HomeViewModel = homeViewModel;
        this.communityCardModel = communityCardModel;
        _userInformationModel = userInformationModel;
        _LoginModel = loginModel;
        InitializeWindow();
        InitializeCommand();
    }

    private void InitializeCommand()
    {
        LeaveCommunityCommand = new LeaveCommunityCommand(new LeaveCommunityService(_LoginModel.ID,communityCardModel.ID,HomeViewModel));
        LikedCommand = new LikedCommand(new LikeService(this));
        RefreshCommand = new RefreshPostCommand(this);

    }

    void InitializeWindow()
    {
        OpenCommentWindow = new OpenCommentCommand(_LoginModel,_userInformationModel);
        OpenPostWindowCommand = new OpenPostCommand(this);


    }

    public PostFeedViewModel()
    {
      
    }

 
}