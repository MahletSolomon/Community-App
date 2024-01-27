using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class NewPostCommand : CommandBase
{
        
    PostFeedViewModel PostFeedViewModel;
    Window window;
    public NewPostCommand( NewPostWindow window, PostFeedViewModel viewModel) 
    {
        PostFeedViewModel = viewModel;
        this.window = window;
        PostFeedViewModel.Caption = "";
        PostFeedViewModel.GetPicture = "";

    }


    public override void Execute(object parameter)
    {
        //MessageBox.Show(PostFeedViewModel.Caption);
        var newPost = new Post(PostFeedViewModel.Caption, "C:\\Users\\hp\\Downloads\\CommunityApp-c8a35b3e0a1fb6b659bf4e3f5aab677d86684835\\CommunityApp-c8a35b3e0a1fb6b659bf4e3f5aab677d86684835\\MainProject\\MVVM\\Images\\leaf.jpg");
        PostFeedViewModel.Posts.Add(newPost);
        PostFeedViewModel.Caption = string.Empty;
        PostFeedViewModel.GetPicture = string.Empty;
        window.Hide();
        //window.ClosingRequestedsted?.Invoke();



    }
}