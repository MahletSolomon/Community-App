using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MainProject.MVVM.Model;
using MainProject.Utilities;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class CommentViewModel:ViewModelBase
{
    private LinkedListObservableCollection<CommentModel> comments;

    public LinkedListObservableCollection<CommentModel> Comments
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
    private RetrieveCommentService _retrieveCommentService;
    private string newComment;
    public string NewComment
    {
        get { return newComment;}
        set { newComment = value; OnPropertyChanged(); }
    }
    public ICommand AddCommentCommand { get; set; }
    public PostModel Post;
    public LoginModel LoginModel;
    public UserInformationModel UserInformationModel;
    public CommentViewModel(PostModel postModel,LoginModel loginModel,UserInformationModel userInformationModel)
    {

        Post = postModel;
        LoginModel = loginModel;
        Comments = new LinkedListObservableCollection<CommentModel>();
        _retrieveCommentService = new RetrieveCommentService(Comments, this);
        _retrieveCommentService.Execute();
        AddCommentCommand = new AddCommentCommand(this);
        UserInformationModel = userInformationModel;

    }
   
}