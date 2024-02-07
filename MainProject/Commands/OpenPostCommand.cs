using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class OpenPostCommand:CommandBase
{    
    
    public NewPostWindow NewPostWindow { get; set; }
    private PostFeedViewModel _postFeedViewModel;
    public OpenPostCommand(PostFeedViewModel postFeedViewModel)
    {
        _postFeedViewModel = postFeedViewModel;
    }
    public override void Execute(object parameter)
    {
        NewPostWindow = new NewPostWindow();
        NewPostWindow.DataContext = new CreatePostViewModel(_postFeedViewModel._LoginModel,_postFeedViewModel._userInformationModel,_postFeedViewModel.communityCardModel,_postFeedViewModel,NewPostWindow);
        NewPostWindow.Show();
    }
}