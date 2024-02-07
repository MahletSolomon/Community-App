using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Utilities;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    public NavigationStore HomeNavigationStore { get; set; }
    public bool IsLoading { get; set; }
    
    public StackObservableCollection<PostModel> Posts { get; set; }

    public ViewModelBase PostViewModel => HomeNavigationStore.CurrentViewModel;
    private bool _noCommunity;
  
    
    public LoginModel loginModel;

    public NewCommunityWindow NewCommunityWindow { get; set; }
    public ICommand OpenCreateCommunityCommand { get; set; }
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
    private RetrieveCommunityPostService _retrieveCommunityPostService;


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

    public UserInformationModel _userInformationModel;
    public DashBordViewModel DashBordViewModel;
    
    public HomeViewModel(LoginModel loginModel,UserInformationModel userInformationModel,DashBordViewModel dashBordViewModel)
    {
        HomeNavigationStore = new NavigationStore();
        DashBordViewModel = dashBordViewModel;
        CommunityCardModels = new ObservableCollection<CommunityCardModel>();
        _userInformationModel = userInformationModel;
        this.loginModel = loginModel;

        RetrieveCommunityInformationService retrieveCommunityInformationService = new RetrieveCommunityInformationService(CommunityCardModels, loginModel.ID,this);
        retrieveCommunityInformationService.Execute();
        DefineViewNavigationIcons();
        InitializePostFeed();
        HomeNavigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
        
        OpenCreateCommunityCommand =  new OpenCreateCommunityCommand(this, loginModel);
        _noCommunity = CommunityCardModels.Count<=0 ?true:false;
    }

    private void InitializePostFeed()
    {
        Posts = new StackObservableCollection<PostModel>();
        PostStorage = new Dictionary<int, StackObservableCollection<PostModel>>();
        _retrieveCommunityPostService = new RetrieveCommunityPostService(loginModel.ID);
        if (CommunityCardModels.Count > 0)
        {
            RetrieveCommunityPost(CommunityCardModels[0].ID,Posts);
            PostStorage[CommunityCardModels[0].ID] = Posts;
        }
       
        HomeNavigationStore.CurrentViewModel = CommunityCardModels.Count>0 ? new PostFeedViewModel(Posts, this.loginModel,_userInformationModel,this, CommunityCardModels[0],PostStorage):new PostFeedViewModel() ;

    }

    public Dictionary<int, StackObservableCollection<PostModel>> PostStorage;
    void OnChange(int communityId)
    {

        StackObservableCollection<PostModel> Post=new StackObservableCollection<PostModel>();
        CommunityCardModel communityCardModel = CommunityCardModels.FirstOrDefault(CommunityCardModel => CommunityCardModel.ID == communityId);
        if (PostStorage.ContainsKey(communityCardModel.ID))
        {
            HomeNavigationStore.CurrentViewModel = new PostFeedViewModel(PostStorage[communityCardModel.ID], loginModel,_userInformationModel,this,communityCardModel,PostStorage);
        }
        else
        {
            RetrieveCommunityPost(communityCardModel.ID,Post);
            PostStorage[communityCardModel.ID] = Post;
            HomeNavigationStore.CurrentViewModel = new PostFeedViewModel(Post, loginModel,_userInformationModel,this,communityCardModel,PostStorage);


        }
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
    void RetrieveCommunityPost(int CommunityID,StackObservableCollection<PostModel> post)
    {
        _retrieveCommunityPostService.Execute(CommunityID,post);
    }

}