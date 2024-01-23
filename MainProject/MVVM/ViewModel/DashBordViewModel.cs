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
        DashBordNavigationCommand bordNavigationCommand =
            new DashBordNavigationCommand(navigateTo, DashNavigationStore);
        bordNavigationCommand.Execute();
    }
    public DashBordViewModel(LoginModel loginModel,NavigationStore navigationStore)
    {
        PageNavModels = new ObservableCollection<PageNavModel>();
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Home",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Home.png"
        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Search",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Search.png"


        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Account",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Account.png"

        });
        PageNavModels.Add(new PageNavModel()
        {
            Name = "Setting",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Setting.png"

        });
        DashNavigationStore = new NavigationStore();
        DashNavigationStore.CurrentViewModel = new HomeViewModel();
        DashNavigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
    }
    private void OnCurrentViewModelChange()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}

