using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class SignUpContinueCommand: CommandBase
{
    private SignUpViewModel _signUpViewModel;
    private ParameterNavigationService<UserInformationModel, UploadPictureViewModel> _navigationService;


    public SignUpContinueCommand(SignUpViewModel signUpViewModel,
        ParameterNavigationService<UserInformationModel, UploadPictureViewModel> navigationService)
    {
        _signUpViewModel = signUpViewModel;
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        UserInformationModel userInfo = new UserInformationModel()
        {
            Username = _signUpViewModel.Username,
            FirstName = _signUpViewModel.FirstName,
            MiddleName = _signUpViewModel.MiddleName,
            LastName = _signUpViewModel.LastName,
            Email = _signUpViewModel.Email,
            DateOfBirth = _signUpViewModel.DateOfBirth,
            Gender = _signUpViewModel.Gender,
            Password = _signUpViewModel.Password,

        };

        _navigationService.Navigate(userInfo);
    }
}