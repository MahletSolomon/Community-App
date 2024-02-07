using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using MainProject.Services;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class AddCommentCommand:CommandBase
{
    private CommentViewModel _commentViewModel;
    private AddCommentService _addCommentService;
    
    public AddCommentCommand(CommentViewModel commentViewModel)
    {
        _commentViewModel = commentViewModel;
        _addCommentService = new AddCommentService(_commentViewModel);
        
    }
    public override void Execute(object parameter)
    {
        _commentViewModel.Comments.Add(new CommentModel(_commentViewModel.PostId,_commentViewModel.NewComment)
        {
            PostedOnId = _commentViewModel.PostId,
            CommentMessage = _commentViewModel.NewComment,
            UserProfilePicture = _commentViewModel.UserInformationModel.ProfilePictureUrl,
            Name = _commentViewModel.UserInformationModel.FirstName + " " + _commentViewModel.UserInformationModel.LastName
        });
        _addCommentService.Execute();
        _commentViewModel.Post.TotalComment += 1;
    }
}