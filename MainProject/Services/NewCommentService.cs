using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class NewCommentService:ConnectionBaseService
{
    private CommentModel _commentModel;
    private CommentViewModel _commentViewModel;
    
    public ObservableCollection<CommentModel> Comments { get; set; }
    

    public NewCommentService(ObservableCollection<CommentModel> comments, CommentViewModel commentViewModel)
    {
        Comments = comments;
        _commentViewModel = commentViewModel;
    }

    public void Execute()
    {
        // if(_commentViewModel.Po)
        //     Comments.Add(new CommentModel("21",_commentViewModel.NewComment)
        //    );
        
        
        
    }

}