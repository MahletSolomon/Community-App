using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class OpenCreateCommunityCommand:CommandBase
{
    private HomeViewModel _homeViewModel;
    private LoginModel _loginModel;
    public OpenCreateCommunityCommand(HomeViewModel homeViewModel,LoginModel loginModel)
    {
        _homeViewModel = homeViewModel;
        _loginModel = loginModel;
    }
    public override void Execute(object parameter)
    {
        NewCommunityWindow newCommunityWindow = new NewCommunityWindow();
        newCommunityWindow.DataContext = new CreateCommunityViewModel(_homeViewModel,_loginModel,newCommunityWindow);
        newCommunityWindow.Show();
    }
}