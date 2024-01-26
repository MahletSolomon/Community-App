using System.Threading.Tasks;
using System.Windows;
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
        AuthenticationService authenticationService = new AuthenticationService(model);
        if (authenticationService.Execute())
        {
            model.ID = authenticationService.GetID();
            _navigationService.Navigate(model);
        }
        else
        {
            MessageBox.Show("Can not Login");
        }
    }
   
    
}