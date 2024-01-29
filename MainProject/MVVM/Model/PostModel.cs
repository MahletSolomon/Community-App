using System.Windows.Input;

namespace MainProject.MVVM.Model;

public class PostModel
{
    public string PostID { get; set; }
    public string PostCaption { get; set; }
    public string PostDate { get; set; }
    public string PostBy { get; set; }
    public int PostCommunity { get; set; }
    public string PostImagePath { get; set; }
    public string UserProfileName { get; set; }
    public string UserProfilePicture { get; set; }
    
    public int TotalLike { get; set; }
    public int TotalComment { get; set; }
    public ICommand LikedCommand { set; get; }
    public ICommand CommandCommand { set; get; }

    public PostModel()
    {
        PostImagePath = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Message.png";
    }
}