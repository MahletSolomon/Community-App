using System;
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
        _loginViewModel.IsLoading = true;
        LoginModel model = new LoginModel()
        {
            Username = _loginViewModel.Username,
            Password = _loginViewModel.Password
        };
        AuthenticationService authenticationService = new AuthenticationService(model);
        try
        {
            await authenticationService.Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (false)
        {
            model.ID = authenticationService.GetID();
            _navigationService.Navigate(model);
        }
        else
        {
            _loginViewModel.WrongCredential();
        }
        // _loginViewModel.IsLoading = false; 

    }
   
    
}