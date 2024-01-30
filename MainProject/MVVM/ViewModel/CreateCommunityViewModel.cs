using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Services;
using WpfApp1.Commands;

namespace MainProject.MVVM.ViewModel;

public class CreateCommunityViewModel:ViewModelBase
{
    public ICommand CreateCommunity { get; set; }
    public ICommand UploadPictureCommand { get; set; }
    public CommunityCardModel CommunityCardModel { set; get; }
    public LoginModel LoginModel;
    public HomeViewModel HomeViewModel;
    public NewCommunityWindow NewCommunityWindow;
    public CreateCommunityViewModel(HomeViewModel homeViewModel,LoginModel loginModel,NewCommunityWindow newCommunityWindow)
    {
        NewCommunityWindow = newCommunityWindow;
        LoginModel = loginModel;
        HomeViewModel = homeViewModel;
        CommunityCardModel = new CommunityCardModel();
        CreateCommunity = new CreateCommunityCommand(new CreateCommunityService(this));
        UploadPictureCommand = new UploadCommunityPictureCommand(this);
    }
}