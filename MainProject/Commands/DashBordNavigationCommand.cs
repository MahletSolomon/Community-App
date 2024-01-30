using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class DashBordNavigationCommand
{
    private string _navigateTo;
    private NavigationStore _dashNavigationStore;
    private LoginModel _loginModel;
    private UserInformationModel _userInformationModel;
    private DashBordViewModel _dashBordViewModel;
    public DashBordNavigationCommand(string navigateTo,NavigationStore DashNavigationStore,LoginModel loginModel,UserInformationModel userInformationModel,DashBordViewModel dashBordViewModel)
    {
        _navigateTo = navigateTo;
        _dashNavigationStore = DashNavigationStore;
        _loginModel = loginModel;
        _userInformationModel = userInformationModel;
        _dashBordViewModel = dashBordViewModel;
    }

    public void Execute()
    {
        switch (_navigateTo)
        {
            case "Home":
                _dashNavigationStore.CurrentViewModel = new HomeViewModel(_loginModel,_userInformationModel,_dashBordViewModel);
                break;
            case "Search":
                _dashNavigationStore.CurrentViewModel = new SearchViewModel(_dashNavigationStore,_loginModel,_userInformationModel);

                break;
            case "Account":
                _dashNavigationStore.CurrentViewModel = new AccountViewModel(_userInformationModel,_loginModel);

                break;
            case "Setting":
                _dashNavigationStore.CurrentViewModel = new SettingViewModel();
                break;
            default:
                _dashNavigationStore.CurrentViewModel = new HomeViewModel(_loginModel,_userInformationModel,_dashBordViewModel);
                break;
        }
    }
}