using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using TestingWPF.MVVM.View_Model;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class SignUpViewModel:ViewModelValidationBase
{
    public ICommand NavigateLoginCommand { get; }
    public ICommand NavigateUploadPictureCommand { get; }
    
    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            ClearErrors(nameof(Username));
            if (_username.Length<5 && _username!="")
            {
                AddError(nameof(Username),"Must be more than 4 letters");
            }
            if (_username=="abiyaddis")
            {
                AddError(nameof(Username),$"Username {_username} is taken");
            }

            OnPropertyChanged();
        }
    }

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    private string _middleName;
    public string MiddleName
    {
        get => _middleName;
        set
        {
            _middleName = value;
            OnPropertyChanged();
        }
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    private string _dateOfBirth;
    public string DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChanged();
        }
    }

    private string _gender;
    public string Gender
    {
        get => _gender;
        set
        {
            _gender = value;
            // Validation logic for Gender if needed
            OnPropertyChanged();
        }
    }

    private string _password;

    public string Password
    {
        set
        {
            _password = value;
            OnPropertyChanged();
        }
        get => _password;
    }
    private string _rePassword;

    public string RePassword
    {
        set
        {
            _rePassword = value;
            ClearErrors(nameof(RePassword));
            if (_rePassword != _password && _rePassword!="")
            {
                AddError(nameof(RePassword),"Password dose not match");
            }
            OnPropertyChanged();
        }
        get => _rePassword;
    }
    public SignUpViewModel(NavigationStore navigationStore)
    {
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
            new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
        NavigateUploadPictureCommand=new SignUpContinueCommand(this,new ParameterNavigationService<UserInformationModel, 
            
            UploadPictureViewModel>(navigationStore,(parameter)=>new UploadPictureViewModel(parameter,navigationStore)));
    }
    
}