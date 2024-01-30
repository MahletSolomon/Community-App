using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class OpenCommentCommand:NewWindowCommand
{
    private ObservableCollection<CommentModel> currentComments { get; set; }
    private OpenCommentService _openCommentService;
    private CommentViewModel _commentViewModel;
    private CommentWindow _commentWindow;

    public OpenCommentCommand(CommentWindow commentWindow, CommentViewModel commentViewModel):base(commentWindow,commentViewModel)
    {
       
        //_openCommentService = openCommentService;
        _commentViewModel = commentViewModel;
        _commentWindow = commentWindow;
        
    }
    public override void Execute(object parameter)
    {
        
        if (parameter is PostModel post)
        {
            if (!_commentWindow.IsVisible)
            {
                _commentViewModel.CurrentComments.Clear();
                _commentViewModel.PostId = post.PostID;
                MessageBox.Show(post.PostID);
                foreach (var c in _commentViewModel.Comments)
                {
                    
                 
                    if (post.PostID == c.PostedOnId)
                    {
                        _commentViewModel.CurrentComments.Add(c);
                        
                     
                    }

                    post.TotalComment = _commentViewModel.CurrentComments.Count;
                }
                _commentWindow.Show();    
            }
            else
            {
                _commentWindow.Hide();
            }
            
           
            
        }
        
    }
}