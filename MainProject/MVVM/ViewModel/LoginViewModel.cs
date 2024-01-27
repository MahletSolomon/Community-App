using System;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using TestingWPF.MVVM.View_Model;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class LoginViewModel:ViewModelValidationBase
{
    public ICommand NavigateSignupCommand { get; }
    public ICommand LoginCommand { get; }
    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        } 
    }
    
    private string _username;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            ClearErrors(nameof(Username));
            OnPropertyChanged();
        }
    }
    

    private string _password;

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
        Password = "";
        Username = "";
        NavigateSignupCommand =
            new NavigateCommand<SignUpViewModel>(
                new NavigationService<SignUpViewModel>(navigationStore, () => new SignUpViewModel(navigationStore)));
        LoginCommand = new LoginCommand(this,new ParameterNavigationService<LoginModel,
            DashBordViewModel>(navigationStore,parameter=>new DashBordViewModel(parameter,navigationStore)));
    }

    public void WrongCredential()
    {
        ClearErrors(nameof(Username));
        AddError(nameof(Username),"Wrong Credential");
    }
}