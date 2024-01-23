using System.Collections.ObjectModel;
using MainProject.MVVM.Model;

namespace MainProject.MVVM.ViewModel;

public class HomeViewModel:ViewModelBase
{
    public ViewModelBase PostViewModel { get; }

    public ObservableCollection<PageNavModel> PageNavModel { set; get; }
    public ObservableCollection<PageNavModel> CommunityCards { set; get; }

    
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
        CommunityCards = new ObservableCollection<PageNavModel>()
        {
            new PageNavModel(){Name = "Dog lovers",ImageSource = "https://hips.hearstapps.com/hmg-prod/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=0.752xw:1.00xh;0.175xw,0&resize=1200:*"},
            new PageNavModel(){Name = "Nathan",ImageSource = "https://hips.hearstapps.com/hmg-prod/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=0.752xw:1.00xh;0.175xw,0&resize=1200:*"},
            new PageNavModel(){Name = "Dog lovers",ImageSource = "https://hips.hearstapps.com/hmg-prod/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=0.752xw:1.00xh;0.175xw,0&resize=1200:*"},
            
        };
        
        PostViewModel = new PostFeedViewModel();
    }
}