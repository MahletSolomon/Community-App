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
    private LoginModel _loginModel;

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
        DashBordNavigationCommand bordNavigationCommand = new DashBordNavigationCommand(navigateTo, DashNavigationStore,_loginModel,_userInformationModel,this,_navigationStore);
        bordNavigationCommand.Execute();
    }

    private UserInformationModel _userInformationModel;
    public string ProfilePicture { set; get; }
    public string ProfileName { set; get; }
    private NavigationStore _navigationStore { set; get; }
    public DashBordViewModel(LoginModel loginModel,NavigationStore navigationStore)
    {
            _loginModel = loginModel;
            _navigationStore = navigationStore;
            RetrieveInformation();
            DefineViewNavigationIcons();
            DashNavigationStore = new NavigationStore();
            DashNavigationStore.CurrentViewModel = new HomeViewModel(loginModel,_userInformationModel,this);
            DashNavigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
    }

    public void Refresh()
    {
        DashNavigationStore.CurrentViewModel = new HomeViewModel(_loginModel,_userInformationModel,this);
    }
    private void OnCurrentViewModelChange()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void RetrieveInformation()
    {
        RetrieveUserInformationService retrieveUserInformationService = new RetrieveUserInformationService(_loginModel.ID);
        _userInformationModel = retrieveUserInformationService.GetInformation();
        ProfilePicture = _userInformationModel.ProfilePictureUrl;
        ProfileName = _userInformationModel.Username;
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
    }
}

