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
    public ObservableCollection<PostModel> Posts { get; set; }
    public CommunityCardModel communityCardModel { set; get; }
    
    public string GetPicture {  get; set; }
    public string Caption { get; set; }
    
    public NewPostWindow NewPostWindow { get; set; }
    public CommentWindow CommentWindow { get; set; }
    
    private RetrieveCommunityPostService _retrieveCommunityPostService;
    
    public UserInformationModel _userInformationModel;
    public CommentViewModel CommentViewModel { get; set; }
    
    private ICommand ShowInfoPanel { get; }
    
    public ICommand OpenPostWindow { get; set; }
    public ICommand OpenCommentWindow { get; set; }
    
    public ICommand NewPostCommand  {  get; set; }
    public ICommand LikedCommand { set; get; }
    
    public ICommand CommandCommand { set; get; }
    
    public ICommand LeaveCommunity {  get; set; }
    
    
   
    public PostFeedViewModel(CommunityCardModel communityCardModel, LoginModel loginModel,UserInformationModel userInformationModel)
    {
        
        Posts = new ObservableCollection<PostModel>();
        this.communityCardModel = communityCardModel;
        NewPostWindow = new NewPostWindow();
        _userInformationModel = userInformationModel;
        // NewPostWindow.DataContext = this;
        
        CommentWindow = new CommentWindow();
        CommentViewModel = new CommentViewModel(this);
        //CommentWindow.DataContext = CommentViewModel;
        OpenCommentWindow = new OpenCommentCommand(CommentWindow, CommentViewModel);
        
        OpenPostWindow = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
        _retrieveCommunityPostService = new RetrieveCommunityPostService(Posts,communityCardModel.ID);
        LikedCommand = new LikedCommand(new LikeService(this));
        
        
        RetrieveCommunityPost();

    }

    public PostFeedViewModel(LoginModel loginModel)
    {
        CommentWindow = new CommentWindow();
        CommentViewModel = new CommentViewModel( this);
        CommentWindow.DataContext = CommentViewModel;
        OpenCommentWindow = new OpenCommentCommand(CommentWindow, CommentViewModel);
        NewPostWindow = new NewPostWindow();
        this.communityCardModel = communityCardModel;
        NewPostWindow.DataContext = this;
        Posts = new ObservableCollection<PostModel>();
        OpenPostWindow = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
    }

    void RetrieveCommunityPost()
    {
        _retrieveCommunityPostService.Execute();
    }

}