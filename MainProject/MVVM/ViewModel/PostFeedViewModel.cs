using System.Collections.ObjectModel;
using System.Windows.Input;
using MainProject.MVVM.Model;
using WpfApp1.Commands;

namespace MainProject.MVVM.ViewModel;

public class PostFeedViewModel:ViewModelBase
{
    public ObservableCollection<Post> Posts { get; }
    private ICommand ShowInfoPanel { get; }
    public PostFeedViewModel()
    {
       // ShowInfoPanel = new CommandBase()=>
        Posts = new ObservableCollection<Post>
        {
            new Post("Meet the fluffiest ball of joy in town! 🐾🌟 This [insert breed] is stealing hearts and melting mine. Double-tap if you can't handle the cuteness! 💖 #PuppyLove #AdorableFurball", "3/4/5", "C:/Users/abiym/Desktop/dog1.jpg", "Mark Gray","C:/Users/abiym/Desktop/dog2.webp" ),
            new Post("Hello fkrvjbsksbaKHBefKH VKBSALEGRUZDFVIB    kjglieacgdslbsIgl lugf iqcyDAG VSliYGWCD LIUGHLIUGIYGIVLUV     KFRWbhKJHBfrkbh", "3/4/5", "C:/Users/abiym/Desktop/dog1.jpg", "doggy","C:/Users/abiym/Desktop/dog2.webp" ),
            new Post("Hello fkrvjbsksbaKHBefKH VKBSALEGRUZDFVIB    kjglieacgdslbsIgl lugf iqcyDAG VSliYGWCD LIUGHLIUGIYGIVLUV     KFRWbhKJHBfrkbh", "3/4/5", "C:/Users/abiym/Desktop/dog1.jpg", "doggy","C:/Users/abiym/Desktop/dog2.webp" ),
        };
    }
    
}