using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class SelectedSearchItemCommand:CommandBase
{
    private NavigationStore dashNavigationStore;
    private RetrieveCommunityPostService _retrieveCommunityPostService;
    private LoginModel _loginModel;
    private ObservableCollection<PostModel> Posts;
    private UserInformationModel _userInformationModel;
    private JoinCommunityWindow _joinCommunityWindow;

    public SelectedSearchItemCommand(LoginModel loginModel,UserInformationModel userInformationModel)
    {
        _retrieveCommunityPostService = new RetrieveCommunityPostService(loginModel.ID);
        _loginModel = loginModel;
        this.dashNavigationStore = dashNavigationStore;
        _userInformationModel = userInformationModel;
    }
    public override void Execute(object parameter)
    {
        if (parameter is CommunityCardModel cardModel)
        {
            _joinCommunityWindow = new JoinCommunityWindow();
            _joinCommunityWindow.DataContext = new JoinCommunityViewModel(cardModel, _loginModel, _joinCommunityWindow);

            _joinCommunityWindow.Show();
        }
    }
    
    void InitializeWindow()
    {
        _joinCommunityWindow = new JoinCommunityWindow
        {
            DataContext = this
        };
        
    }
}