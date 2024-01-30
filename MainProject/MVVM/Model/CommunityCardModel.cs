using System;
using System.Collections.ObjectModel;

namespace MainProject.MVVM.Model;

public class CommunityCardModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string OwnerID { get; set; }
    public string OwnerPictureUrl { get; set; }
    public string OwnerName { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string MemberTotal { get; set; }
    public string PostTotal { get; set; }
    public DateTime CreatedDate { get; set; }
    public ObservableCollection<PostModel> Posts { get; set; }


}