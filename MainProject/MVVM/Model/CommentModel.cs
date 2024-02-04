namespace MainProject.MVVM.Model;

public class CommentModel
{
    public string CommentId { get; set; }
    public string PostedOnId { get; set; }
    public string CommentMessage { get; set; }
    public string CommentDate { get; set; }
    public string CommentBy { get; set; }
    public string UserName { get; set; }
    public string UserProfilePicture { get; set; }
    

    public CommentModel( string postedOnId, string commentMessage)
    {
        PostedOnId = postedOnId;
        CommentMessage = commentMessage;
    }

}