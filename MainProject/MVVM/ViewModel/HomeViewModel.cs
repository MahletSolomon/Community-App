using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    public NavigationStore HomeNavigationStore { get; set; }
    public bool IsLoading { get; set; }
    

    public ViewModelBase PostViewModel => HomeNavigationStore.CurrentViewModel;
    private bool _noCommunity;
    public string CommunityName { get; set; }
    public string CommunityDescription { get; set; }
    public string CommunityPicture { get; set; }
    
    public LoginModel loginModel;

    public NewCommunityWindow NewCommunityWindow { get; set; }
    public ICommand CreateCommunity { get; set; }
    public ICommand OpenCommunityWindowCommand { get; set; }
    public bool NoCommunity
    {
        get { return _noCommunity; }
        set
        {
            if (_noCommunity != value)
            {
                _noCommunity = value;
                OnPropertyChanged();
            }
        }
    }
    public ObservableCollection<PageNavModel> PageNavModel { set; get; }
    public ObservableCollection<CommunityCardModel> CommunityCardModels { set; get; }

    private CommunityCardModel _selectedItem;

    public CommunityCardModel SelectedItem
    {
        set
        {
            if (_selectedItem != value)
            {
                _selectedItem = value;
                OnChange(_selectedItem.ID);
            }
        }
        get
        {
            return _selectedItem;
        }
    }

    private UserInformationModel _userInformationModel;
    
    public HomeViewModel(LoginModel loginModel,UserInformationModel userInformationModel)
    {
        HomeNavigationStore = new NavigationStore();
        CommunityCardModels = new ObservableCollection<CommunityCardModel>();
        NewCommunityWindow = new NewCommunityWindow();
        _userInformationModel = userInformationModel;
        this.loginModel = loginModel;

        RetrieveCommunityInformationService retrieveCommunityInformationService = new RetrieveCommunityInformationService(CommunityCardModels, loginModel.ID,this);
        retrieveCommunityInformationService.Execute();
        DefineViewNavigationIcons();
        _noCommunity = CommunityCardModels.Count>0 ?false:true;
        HomeNavigationStore.CurrentViewModel = CommunityCardModels.Count>0 ? new PostFeedViewModel(CommunityCardModels[0], this.loginModel,_userInformationModel) : new PostFeedViewModel(this.loginModel);
        HomeNavigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
        
        //M
        NewCommunityWindow.DataContext = this;
        OpenCommunityWindowCommand = new NewWindowCommand(NewCommunityWindow, this);
        CreateCommunity = new CreateCommunityCommand(NewCommunityWindow, this);
    }

    void OnChange(int communityId)
    {
        CommunityCardModel communityCardModel = CommunityCardModels.FirstOrDefault(CommunityCardModel => CommunityCardModel.ID == communityId);
        HomeNavigationStore.CurrentViewModel = new PostFeedViewModel(communityCardModel, loginModel,_userInformationModel);
    }
    private void OnCurrentViewModelChange()
    {
        OnPropertyChanged(nameof(PostViewModel));
    }

    private void DefineViewNavigationIcons ()
    {
        PageNavModel = new ObservableCollection<PageNavModel>();
        
        PageNavModel.Add(new PageNavModel()
        {
            Name = "Community",
            ImageSource = "/Images/Community.png"
        });
        PageNavModel.Add(new PageNavModel()
        {
            Name = "Message",
            ImageSource = "/Images/Message.png"
        });

    }
}