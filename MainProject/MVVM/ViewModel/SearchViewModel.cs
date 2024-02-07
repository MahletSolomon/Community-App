using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Services;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class SearchViewModel:ViewModelBase
{
    public ICommand SelectSearchItemCommand { get; set; }
    private string _searchValue;
    private Timer _searchTimer;
    private JoinCommunityWindow _joinCommunityWindow;

    public string SearchValue
    {
        get => _searchValue;
        set
        {
            _searchValue = value;
            Application.Current.Dispatcher.Invoke(() =>
            {
                CommunityCardModels.Clear();
            });
            _searchTimer?.Dispose();
            _searchTimer = new Timer(SearchCommunity, null, 300, Timeout.Infinite);
            OnPropertyChanged();
        }
    }

    
    public ObservableCollection<CommunityCardModel> CommunityCardModels { set; get; }
    private SearchCommunityService _searchCommunityService { set; get; }
    private NavigationStore dashNavigationStore;
    private LoginModel _loginModel;
    public SearchViewModel(NavigationStore dashNavigationStore,LoginModel loginModel,UserInformationModel userInformationModel)
    {
        
        CommunityCardModels = new ObservableCollection<CommunityCardModel>();
        _searchCommunityService = new SearchCommunityService(CommunityCardModels);
        this.dashNavigationStore = dashNavigationStore;
        _loginModel = loginModel;
        SelectSearchItemCommand = new SelectedSearchItemCommand(_loginModel,userInformationModel);
    }

 
    private void SearchCommunity(object state)
    {
    
        if (!_searchTimer.Change(Timeout.Infinite, Timeout.Infinite))
        {
            return;
        }
        Application.Current.Dispatcher.Invoke(() =>
        {
            CommunityCardModels.Clear();
        });
        _searchCommunityService.Execute(SearchValue);
        OnPropertyChanged();
    }
}