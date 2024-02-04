using System.Collections.ObjectModel;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class CreatePostViewModel:ViewModelBase
{
    public ICommand NewPostCommand  {  get; set; }
    public ICommand UploadPictureCommand { set; get; }
    public string Caption { get; set; }
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

    public CommunityCardModel communityCardModel;
    public UserInformationModel _userInformationModel;
    public LoginModel _LoginModel;
    public ObservableCollection<PostModel> Posts;
    private string _defaultUpload = "/Images/Upload.png";
    public string DefaultUpload
    {
        get => _defaultUpload;
        set
        {
            _defaultUpload = value;
            OnPropertyChanged();
        } 
    }
    public CreatePostViewModel(LoginModel loginModel,UserInformationModel userInformationModel,CommunityCardModel communityCardModel,ObservableCollection<PostModel> posts,NewPostWindow newPostWindow)
    {
        this.communityCardModel = communityCardModel;
        _userInformationModel = userInformationModel;
        _LoginModel = loginModel;
        Posts = posts;
        NewPostCommand = new NewPostCommand(newPostWindow, new NewPostService(this,_LoginModel));
        UploadPictureCommand = new UploadProfilePictureCommand(this);
    }
    
}