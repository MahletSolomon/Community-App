using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class NewPostCommand : CommandBase
{
        
    PostFeedViewModel PostFeedViewModel;
    Window window;
    public LoginModel LoginModel;
    public NewPostService NewPostService; 
    public NewPostCommand( NewPostWindow window, NewPostService newPostService) 
    {
        this.window = window;
        PostFeedViewModel.Caption = "";
        PostFeedViewModel.GetPicture = "";
        NewPostService = newPostService;

    }


    public override void Execute(object parameter)
    {
        //MessageBox.Show(PostFeedViewModel.Caption);
        
        var newPost = new PostModel();
        PostFeedViewModel.Posts.Add(newPost);
        PostFeedViewModel.Caption = string.Empty;
        PostFeedViewModel.GetPicture = string.Empty;
        NewPostService.Execute();
        window.Hide();
        //window.ClosingRequestedsted?.Invoke();



    }
}