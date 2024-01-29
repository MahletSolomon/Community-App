using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class DashBordViewModel:ViewModelBase
{
    public NavigationStore DashNavigationStore { get; set; }
    public ViewModelBase CurrentViewModel => DashNavigationStore.CurrentViewModel;
    private LoginModel _LoginModel;

    public ObservableCollection<PageNavModel> PageNavModels { set; get; }
    private PageNavModel _PageNavModel;

    public PageNavModel SelectedItem
    {
        set
        {
            _PageNavModel = value;
            Navigate();
        }
        get
        {
            return _PageNavModel;
        }
    }
    private void Navigate()
    {
        string navigateTo = SelectedItem.Name;
        DashBordNavigationCommand bordNavigationCommand = new DashBordNavigationCommand(navigateTo, DashNavigationStore,_LoginModel,_userInformationModel);
        bordNavigationCommand.Execute();
    }

    private UserInformationModel _userInformationModel;
    public string ProfilePicture { set; get; }
    public string ProfileName { set; get; }

    public DashBordViewModel(LoginModel loginModel,NavigationStore navigationStore)
    {
            _LoginModel = loginModel;
            RetrieveInformation();
            DefineViewNavigationIcons();
            DashNavigationStore = new NavigationStore();
            DashNavigationStore.CurrentViewModel = new HomeViewModel(loginModel,_userInformationModel);
            DashNavigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
    }
    private void OnCurrentViewModelChange()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void RetrieveInformation()
    {
        RetrieveUserInformationService retrieveUserInformationService = new RetrieveUserInformationService(_LoginModel.ID);
        _userInformationModel = retrieveUserInformationService.GetInformation();
        ProfilePicture = _userInformationModel.ProfilePictureUrl;
        ProfileName = _userInformationModel.FirstName + " " + _userInformationModel.LastName;
    }

    private void DefineViewNavigationIcons()
    {
        PageNavModels = new ObservableCollection<PageNavModel>();
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Home",
            ImageSource = "/Images/Home.png"
        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Search",
            ImageSource = "/Images/Search.png"


        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Account",
            ImageSource = "/Images/Account.png"

        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Setting",
            ImageSource = "/Images/Setting.png"

        });
    }
}

