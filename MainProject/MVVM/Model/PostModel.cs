using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MainProject.MVVM.Model;

public class PostModel:INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public string PostID { get; set; }
    public string PostCaption { get; set; }
    public string PostDate { get; set; }
    public string PostBy { get; set; }
    public int PostCommunity { get; set; }
    public string PostImagePath { get; set; }
    public string UserProfileName { get; set; }
    public string UserProfilePicture { get; set; }
    public bool IsLiked { get; set; }
    
    private int _totalLike;

    public int TotalLike
    {
        get { return _totalLike;}
        set { _totalLike = value; OnPropertyChanged(); }
    }
    private int _totalComment;

    public int TotalComment
    {
        get { return _totalComment;}
        set { _totalComment = value; OnPropertyChanged(); }
    }

    

    public PostModel()
    {
        PostImagePath = "C:/Users/abiym/RiderProjects/CommunityApp/MainProject/Image/Icon/Message.png";
    }

    

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}