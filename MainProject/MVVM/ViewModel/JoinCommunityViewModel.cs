using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Services;
using WpfApp1.Commands;

namespace MainProject.MVVM.ViewModel;

public class JoinCommunityViewModel:ViewModelBase
{
    public CommunityCardModel CommunityCardModel { set; get; }
    public LoginModel LoginModel;
    public ICommand JoinCommunityCommand { set; get; }
    public JoinCommunityWindow JoinCommunityWindow;
    public JoinCommunityViewModel(CommunityCardModel communityCardModel,LoginModel loginModel,JoinCommunityWindow joinCommunityWindow)
    {
        CommunityCardModel = communityCardModel;
        LoginModel = loginModel;
        JoinCommunityCommand = new JoinCommunityCommand(new JoinCommunityService(this));
        JoinCommunityWindow = joinCommunityWindow;
    }
}