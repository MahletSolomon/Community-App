namespace MainProject.MVVM.Model;

public class Post
{
    public string Caption { get; set; }
    public string Date { get; set; }
    public string ImagePath { get; set; }
    public string ProfileName { get; set; }
    public string ProfilePicture { get; set; }

    public Post(string caption=null,  string imagePath=null,string date=null, string profileName=null, string profilePicture=null)
    {
        Caption = caption;
        Date = date;
        ImagePath = imagePath;
        ProfileName = profileName;
        ProfilePicture = profilePicture;
    }
}