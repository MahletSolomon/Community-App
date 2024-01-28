using System.Collections.ObjectModel;

namespace MainProject.MVVM.Model;

public class CommunityCardModel
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string OwnerID { get; set; }
    public string OwnerPictureUrl { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public int MemberTotal { get; set; }
    public int PostTotal { get; set; }
    public string CreatedDate { get; set; }
    public ObservableCollection<Post> Posts { get; set; }


}