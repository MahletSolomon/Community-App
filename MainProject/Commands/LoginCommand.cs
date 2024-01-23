using System.Threading.Tasks;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class LoginCommand:AsyncCommandBase
{
    private LoginViewModel _loginViewModel;
    private ParameterNavigationService<LoginModel,DashBordViewModel> _navigationService;
    

    public LoginCommand(LoginViewModel loginViewModel,ParameterNavigationService<LoginModel,DashBordViewModel> navigationService)
    {
    _loginViewModel = loginViewModel;
    _navigationService = navigationService;
    }
  
    protected override async Task ExecuteAsync(object parameter)
    {
        
        LoginModel model = new LoginModel()
        {
            Username = _loginViewModel.Username,
            Password = _loginViewModel.Password
        };
        await SimulateLoginAsync();
        _navigationService.Navigate(model);   
    }
    private async Task SimulateLoginAsync()
    {
        await Task.Delay(0000); // 5000 milliseconds (5 seconds)
    }
    
}