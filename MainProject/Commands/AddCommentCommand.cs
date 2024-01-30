using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class AddCommentCommand:CommandBase
{
    
    // private NewCommentService _newCommentService;
    private CommentViewModel _commentViewModel;
    
    private string id;
    
    public AddCommentCommand(CommentViewModel commentViewModel)
    {
        _commentViewModel = commentViewModel;
        

    }
    public override void Execute(object parameter)
    {
       // MessageBox.Show(_commentViewModel.PostId);
        _commentViewModel.CurrentComments.Add(new CommentModel(_commentViewModel.PostId,_commentViewModel.NewComment));
        _commentViewModel.Comments.Add(new CommentModel(_commentViewModel.PostId,_commentViewModel.NewComment));
        // foreach (PostModel p in _commentViewModel.PostFeedViewModel.Posts)
        // {
        //     if (p.PostID == _commentViewModel.PostId)
        //         p.TotalComment++;
        // }
        
        _commentViewModel.NewComment = null;


    }
}