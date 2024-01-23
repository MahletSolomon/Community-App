namespace MainProject.MVVM.Model;

public class Post
{
    public string Caption { get; set; }
    public string Date { get; set; }
    public string ImagePath { get; set; }
    public string ProfileName { get; set; }
    public string ProfilePicture { get; set; }

    public Post(string caption, string date, string imagePath, string profileName, string profilePicture)
    {
        Caption = caption;
        Date = date;
        ImagePath = imagePath;
        ProfileName = profileName;
        ProfilePicture = profilePicture;
    }
}