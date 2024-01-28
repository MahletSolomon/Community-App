using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class NewPostService:ConnectionBaseService
{
    private PostModel _postModel;
    private LoginModel _loginModel;
    public NewPostService(PostFeedViewModel postFeedViewModel,LoginModel loginModel )
    {
        _postModel = new PostModel()
        {
            PostCaption = postFeedViewModel.Caption,

        };
        _loginModel = loginModel;
    }

    public void Execute()
    {
        MessageBox.Show("Hello");
    }
    
}