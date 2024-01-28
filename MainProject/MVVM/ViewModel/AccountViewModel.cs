using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class AccountViewModel:ViewModelBase
{
    public ObservableCollection<PostModel> PostModels { get; set; }
    private RetrieveAccountPostService RetrieveAccountPostService;
    public UserInformationModel userInformationModel { get; set; }
    public LoginModel loginModel { get; set; }
    public AccountViewModel(UserInformationModel userInformationModel,LoginModel loginModel)
    {
        PostModels = new ObservableCollection<PostModel>();
        this.userInformationModel = userInformationModel;
        this.loginModel = loginModel;
        RetrieveAccountPostService = new RetrieveAccountPostService(loginModel.ID,PostModels);
        RetrivePostInformation();
    }

    void RetrivePostInformation()
    {
        RetrieveAccountPostService.Execute();
    }
}