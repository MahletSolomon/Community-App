using MainProject.MVVM.ViewModel;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class DashBordNavigationCommand
{
    private string _navigateTo;
    private NavigationStore _navigationStore;

    public DashBordNavigationCommand(string navigateTo,NavigationStore navigationStore)
    {
        _navigateTo = navigateTo;
        _navigationStore = navigationStore;
    }

    public void Execute()
    {
        switch (_navigateTo)
        {
            case "Home":
                _navigationStore.CurrentViewModel = new HomeViewModel();
                break;
            case "Search":
                _navigationStore.CurrentViewModel = new SearchViewModel();

                break;
            case "Account":
                _navigationStore.CurrentViewModel = new AccountViewModel();

                break;
            case "Setting":
                _navigationStore.CurrentViewModel = new SettingViewModel();
                break;
            default:
                _navigationStore.CurrentViewModel = new HomeViewModel();
                break;
        }
    }
}