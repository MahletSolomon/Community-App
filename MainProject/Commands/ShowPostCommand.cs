using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class ShowPostCommand:CommandBase
{
    private CommunityCardModel _communityCardModel;
    private AccountViewModel _accountViewModel;
    private UserPostViewModel _userPostViewModel;
    private UserPostWindow userPostWindow;
    private RetriveCommunityFromPostService _retriveCommunity;
    //private AccountViewModel AccountViewModel;
    public ShowPostCommand(AccountViewModel accountViewModel)
    {
        _accountViewModel = accountViewModel;
        _communityCardModel = new CommunityCardModel();
    }
    public override void Execute(object parameter)
    {
        if (parameter is PostModel post)
        {

            _retriveCommunity = new RetriveCommunityFromPostService(post.PostCommunity, _communityCardModel);
            _retriveCommunity.Execute();
            userPostWindow = new UserPostWindow();
            userPostWindow.DataContext = new UserPostViewModel(_communityCardModel,userPostWindow,post);
            userPostWindow.Show();

        }
      
    }
}