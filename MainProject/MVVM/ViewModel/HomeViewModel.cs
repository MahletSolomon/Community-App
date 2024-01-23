using System.Collections.ObjectModel;
using MainProject.MVVM.Model;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    public ObservableCollection<PageNavModel> PageNavModel { set; get; }
    
    public HomeViewModel()
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