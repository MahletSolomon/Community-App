using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class OpenCommentCommand:CommandBase
{
    private ObservableCollection<CommentModel> currentComments { get; set; }
    CommentWindow CommentWindow;
    private LoginModel _loginModel;
    private UserInformationModel _userInformationModel;
    public OpenCommentCommand(LoginModel loginModel,UserInformationModel userInformationModel)
    {
        _loginModel = loginModel;
        _userInformationModel = userInformationModel;
    }
    public override void Execute(object parameter)
    {
        
        if (parameter is PostModel post)
        {
            CommentWindow = new CommentWindow();
            CommentWindow.DataContext = new CommentViewModel(post,_loginModel,_userInformationModel);
            CommentWindow.Show();

        }
        
    }
}