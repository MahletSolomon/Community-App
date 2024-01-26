using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class AddUserCommand:CommandBase
{
    private UserInformationModel _userInformationModel;
    private NavigationService<LoginViewModel> _navigationService;
    public AddUserCommand(UserInformationModel userInformationModel,NavigationService<LoginViewModel> navigationService)
    {
        _userInformationModel = userInformationModel;
        _navigationService = navigationService;
    }
  
    public override void Execute(object parameter)
    {
        UserRegistrationService userRegistrationService = new UserRegistrationService(_userInformationModel);
        if (userRegistrationService.GetResult())
        {
            _navigationService.Navigate();
        }
        else
        {
            MessageBox.Show("Try again");
        }
    }
   
}