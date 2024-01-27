using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    
    public ViewModelBase PostViewModel { get; set; }
    private bool _noCommunity;
    public string CommunityName { get; set; }
    public string CommunityDescription { get; set; }
    public string CommunityPicture { get; set; }

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

    
    public HomeViewModel(LoginModel loginModel)
    {

        CommunityCardModels = new ObservableCollection<CommunityCardModel>();
        PostViewModel = new PostFeedViewModel();
        NewCommunityWindow = new NewCommunityWindow();

        RetrieveCommunityInformationService retrieveCommunityInformationService =
            new RetrieveCommunityInformationService(CommunityCardModels, loginModel.ID);
        retrieveCommunityInformationService.Execute();
        DefineViewNavigationIcons();
        _noCommunity = CommunityCardModels.Count>0 ?false:true;
        PostViewModel = CommunityCardModels.Count>0 ? new PostFeedViewModel(CommunityCardModels[0]) : new PostFeedViewModel();
        

        NewCommunityWindow.DataContext = this;
        OpenCommunityWindowCommand = new NewWindowCommand(NewCommunityWindow, this);
        CreateCommunity = new CreateCommunityCommand(NewCommunityWindow, this);
    }

    void OnChange(string communityId)
    {
        CommunityCardModel communityCardModel =
            CommunityCardModels.FirstOrDefault(CommunityCardModel => CommunityCardModel.ID == communityId);
        PostViewModel = new PostFeedViewModel(communityCardModel);
    }

    private void DefineViewNavigationIcons ()
    {
        PageNavModel = new ObservableCollection<PageNavModel>();
        
        PageNavModel.Add(new PageNavModel()
        {
            Name = "Community",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Community.png"
        });
        PageNavModel.Add(new PageNavModel()
        {
            Name = "Message",
            ImageSource = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Message.png"
        });

    }
}