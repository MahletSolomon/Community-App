using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;

using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class CommentViewModel:ViewModelBase
{
    private ObservableCollection<CommentModel> comments;

    public ObservableCollection<CommentModel> Comments
    {
        get { return comments;}
        set { comments = value; OnPropertyChanged(); }
    }
    
    
    private string postId;
    public PostFeedViewModel PostFeedViewModel;
    

    public string PostId
    {
        get { return postId;}
        set { postId = value; OnPropertyChanged(); }
    }
    private ObservableCollection<CommentModel> currentComment;
    public ObservableCollection<CommentModel> CurrentComments
    {
        get { return currentComment;}
        set { currentComment = value; OnPropertyChanged(); }
    }
    private NewCommentService NewCommentService;
    private string newComment;
    public string NewComment
    {
        get { return newComment;}
        set { newComment = value; OnPropertyChanged(); }
    }
    public ICommand AddCommentCommand { get; set; }


    public CommentViewModel()
    {
        
        CurrentComments = new ObservableCollection<CommentModel>();
        Comments = new ObservableCollection<CommentModel>();
        NewCommentService = new NewCommentService(Comments, this);
        AddCommentCommand = new AddCommentCommand(this);
        
        
        Comments.Add(new CommentModel("21", "post 1"));
        Comments.Add(new CommentModel("21", "comment") );
        Comments.Add(new CommentModel("24", "post 2"));
        Comments.Add(new CommentModel("24", "comment") );
        

    }
    public CommentViewModel(PostFeedViewModel postFeedViewModel)
    {
        
        CurrentComments = new ObservableCollection<CommentModel>();
        Comments = new ObservableCollection<CommentModel>();
        NewCommentService = new NewCommentService(Comments, this);
        AddCommentCommand = new AddCommentCommand(this);
        PostFeedViewModel = postFeedViewModel;
        
        Comments.Add(new CommentModel("21", "post 1"));
        Comments.Add(new CommentModel("21", "comment") );
        Comments.Add(new CommentModel("24", "post 2"));
        Comments.Add(new CommentModel("24", "comment") );
        

    }
}

