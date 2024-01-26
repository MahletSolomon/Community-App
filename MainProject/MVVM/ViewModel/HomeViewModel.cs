using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    public ViewModelBase PostViewModel { get; }
    
    public ObservableCollection<PageNavModel> PageNavModel { set; get; }
    public ObservableCollection<CommunityCardModel> CommunityCardModels { set; get; }

    private CommunityCardModel _selectedItem;

    public CommunityCardModel SelectedItem
    {
        set
        {
            _selectedItem = value;
            OnChange();
        }
        get
        {
            return _selectedItem;
        }
    }

    
    public HomeViewModel(LoginModel loginModel)
    {

        CommunityCardModels = new ObservableCollection<CommunityCardModel>();
        
        RetrieveCommunityInformationService retrieveCommunityInformationService =
            new RetrieveCommunityInformationService(CommunityCardModels, loginModel.ID);
        retrieveCommunityInformationService.Execute();
        DefineViewNavigationIcons();
        
        PostViewModel = CommunityCardModels.Count>0 ? new PostFeedViewModel(CommunityCardModels[0]) : new PostFeedViewModel();

            
        
    }

    void OnChange()
    {
        
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