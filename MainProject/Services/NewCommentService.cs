using System.Collections.ObjectModel;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class NewCommentService:ConnectionBaseService
{
    
    

    private CommentModel _commentModel;
    private CommentViewModel _commentViewModel;
    public ObservableCollection<CommentModel> Comments { get; set; }

    public NewCommentService(CommentViewModel commentViewModel)
    {
        _commentViewModel = commentViewModel;
    }

    public void Execute()
    {
        for (int i = 0; i < 5; i++)
        {
            Comments.Add(new CommentModel()
            {
                CommentMessage = "hello"

            });
        }




    }
}