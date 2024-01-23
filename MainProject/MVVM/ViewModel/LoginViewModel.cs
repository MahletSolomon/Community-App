using System;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class LoginViewModel:ViewModelBase
{
    public ICommand NavigateSignupCommand { get; }
    public ICommand LoginCommand { get; }
    private string _password;
    public string Username { get; set; }

    public string Password
    {
        set
        {
            _password = value;
        }
        get => _password;
    }
    public LoginViewModel(NavigationStore navigationStore)
    {
        NavigateSignupCommand =
            new NavigateCommand<SignUpViewModel>(
                new NavigationService<SignUpViewModel>(navigationStore, () => new SignUpViewModel(navigationStore)));
        LoginCommand = new LoginCommand(this,new ParameterNavigationService<LoginModel,
            DashBordViewModel>(navigationStore,parameter=>new DashBordViewModel(parameter,navigationStore)));
    }
}