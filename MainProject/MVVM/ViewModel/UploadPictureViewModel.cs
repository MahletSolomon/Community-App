using System;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class UploadPictureViewModel:ViewModelBase
{
    public ICommand NavigateSignupCommand { get; }
    public ICommand AddPictureCommand { get; }
    public ICommand AddUserCommand { get; }
    private string _profilePicture ="/Images/ProfilePicture.png";
    public string Name { get; set; }
    
    public string ProfileUrl
    {
        set
        {
            _profilePicture = value;
            OnPropertyChanged();
        }
        get
        {
            return _profilePicture;
        }
    }
        
    

    public UploadPictureViewModel(UserInformationModel userInfoModel,NavigationStore navigationStore)
    {
        Name = userInfoModel.FirstName + " " + userInfoModel.LastName;
        NavigateSignupCommand =
            new NavigateCommand<SignUpViewModel>(
                new NavigationService<SignUpViewModel>(navigationStore, () => new SignUpViewModel(navigationStore)));
        AddUserCommand = new AddUserCommand(userInfoModel,new NavigationService<LoginViewModel>(navigationStore,()=>new LoginViewModel(navigationStore)));
        
        AddPictureCommand = new AddPictureCommand(this,userInfoModel);
        

    }
    
    
}

