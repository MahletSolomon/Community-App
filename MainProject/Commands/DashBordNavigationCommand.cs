using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class DashBordNavigationCommand
{
    private string _navigateTo;
    private NavigationStore _navigationStore;
    private LoginModel _loginModel;
    private UserInformationModel _userInformationModel;
    public DashBordNavigationCommand(string navigateTo,NavigationStore navigationStore,LoginModel loginModel,UserInformationModel userInformationModel)
    {
        _navigateTo = navigateTo;
        _navigationStore = navigationStore;
        _loginModel = loginModel;
        _userInformationModel = userInformationModel;
    }

    public void Execute()
    {
        switch (_navigateTo)
        {
            case "Home":
                _navigationStore.CurrentViewModel = new HomeViewModel(_loginModel,_userInformationModel);
                break;
            case "Search":
                _navigationStore.CurrentViewModel = new SearchViewModel();

                break;
            case "Account":
                _navigationStore.CurrentViewModel = new AccountViewModel(_userInformationModel,_loginModel);

                break;
            case "Setting":
                _navigationStore.CurrentViewModel = new SettingViewModel();
                break;
            default:
                _navigationStore.CurrentViewModel = new HomeViewModel(_loginModel,_userInformationModel);
                break;
        }
    }
}