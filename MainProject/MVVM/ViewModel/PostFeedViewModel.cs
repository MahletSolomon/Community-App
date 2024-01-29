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
    private ICommand ShowInfoPanel { get; }
    public string GetPicture {  get; set; }
    public string Caption { get; set; }
    
    public NewPostWindow NewPostWindow { get; set; }
    
    public ICommand OpenWindowCommand { get; set; }
    public ICommand NewPostCommand  {  get; set; }
    public ICommand LeaveCommunityCommand  {  get; set; }
    
    private RetrieveCommunityPostService _retrieveCommunityPostService;
    public UserInformationModel _userInformationModel;
    
   
    public PostFeedViewModel(CommunityCardModel communityCardModel, LoginModel loginModel,UserInformationModel userInformationModel)
    {
        NewPostWindow = new NewPostWindow();
        Posts = new ObservableCollection<PostModel>();
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
        LeaveCommunityCommand = new LeaveCommunityCommand(new LeaveCommunityService(loginModel.ID,communityCardModel.ID));
        this.communityCardModel = communityCardModel;
        _userInformationModel = userInformationModel;
        // NewPostWindow.DataContext = this;
        _retrieveCommunityPostService = new RetrieveCommunityPostService(Posts,communityCardModel.ID);
        RetrieveCommunityPost();

    }

    public PostFeedViewModel(LoginModel loginModel)
    {
        NewPostWindow = new NewPostWindow();
        this.communityCardModel = communityCardModel;
        NewPostWindow.DataContext = this;
        Posts = new ObservableCollection<PostModel>();
        OpenWindowCommand = new NewWindowCommand(NewPostWindow, this);
        NewPostCommand = new NewPostCommand(NewPostWindow, new NewPostService(this,loginModel));
    }

    void RetrieveCommunityPost()
    {
        _retrieveCommunityPostService.Execute();
    }

}