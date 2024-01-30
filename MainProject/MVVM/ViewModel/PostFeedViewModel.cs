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
    public NewPostWindow NewPostWindow { get; set; }
    private ICommand ShowInfoPanel { get; }
    public ICommand OpenWindowCommand { get; set; }
    public ICommand NewPostCommand  {  get; set; }
    public ICommand LikedCommand { set; get; }
    public ICommand UploadPictureCommand { set; get; }
    public ICommand LeaveCommunityCommand  {  get; set; }
    public ICommand RefreshCommand  {  get; set; }
    
    
    public UserInformationModel _userInformationModel;

    private string _picture;
    public string Picture
    {
        get => _picture;
        set
        {
            _picture = value;
            OnPropertyChanged();
        } 
    }

    public HomeViewModel HomeViewModel;
    public string Caption { get; set; }
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
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,_LoginModel));
        LeaveCommunityCommand = new LeaveCommunityCommand(new LeaveCommunityService(_LoginModel.ID,communityCardModel.ID,HomeViewModel));
        LikedCommand = new LikedCommand(new LikeService(this));
        UploadPictureCommand = new UploadProfilePictureCommand(this);
        RefreshCommand = new RefreshPostCommand(this);

    }

    void InitializeWindow()
    {
        NewPostWindow = new NewPostWindow();

    }

    public PostFeedViewModel()
    {
      
    }

 
}