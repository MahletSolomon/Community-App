namespace MainProject.MVVM.Model;

public class CommentModel
{
    public string CommentId { get; set; }
    public string PostedOnId { get; set; }
    public string CommentMessage { get; set; }
    public string CommentDate { get; set; }
    public string CommentBy { get; set; }
    public string Name { get; set; }
    public string UserProfilePicture { get; set; }
    

    public CommentModel( string postedOnId=null, string commentMessage=null)
    {
        PostedOnId = postedOnId;
        CommentMessage = commentMessage;
    }
}