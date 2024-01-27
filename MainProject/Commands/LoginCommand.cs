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

    private AuthenticationService authenticationService;
    public LoginCommand(LoginViewModel loginViewModel,ParameterNavigationService<LoginModel,DashBordViewModel> navigationService)
    {
    _loginViewModel = loginViewModel;
    _navigationService = navigationService;
     authenticationService = new AuthenticationService();

    }
  
    protected override async Task ExecuteAsync(object parameter)
    {
        _loginViewModel.IsLoading = true;
        await Task.Delay(100); // Adjust the delay time as needed

        LoginModel model = new LoginModel()
        {
            Username = _loginViewModel.Username,
            Password = _loginViewModel.Password
        };


        try
        {
            await Task.Run(async () =>
            {
                await authenticationService.Execute(model);
                model.ID = authenticationService.GetID();
            });
            if (authenticationService.GetResult())
            {
               _navigationService.Navigate(model);
            }
            else
            {
                _loginViewModel.WrongCredential();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            // Set IsLoading back to false after loading completes or if an exception occurs
            _loginViewModel.IsLoading = false;
        }
    }

   
    
}