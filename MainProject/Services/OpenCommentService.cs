using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class OpenCommentService:ConnectionBaseService
{
    private CommentViewModel _commentViewModel;

    public OpenCommentService(CommentViewModel commentViewModel)
    {
        _commentViewModel = commentViewModel;
    }

    public void Execute(PostModel postModel)
    {
        
    }
}