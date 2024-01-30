using System.Diagnostics;
using System.Threading;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class LikedCommand:CommandBase
{
    private bool initialLike;
    private bool state=true;
    private LikeService _likeService;
    private Timer _usernameTimer;

    public LikedCommand(LikeService likeService )
    {
        _likeService = likeService;
    }
    public override void Execute(object parameter)
    {
        if (parameter is PostModel post)
        {
                initialLike = post.IsLiked;

            // _postInteractionService.Execute( post);
            if (post.IsLiked)
                post.TotalLike++;
            else
            {
                post.TotalLike--;
            }
            _usernameTimer?.Dispose();
            _usernameTimer = new Timer(CheckUsername, post, 500, Timeout.Infinite);
        }
        

        
    }
    
    private void CheckUsername(object state)
    {
    
        if (!_usernameTimer.Change(Timeout.Infinite, Timeout.Infinite))
        {
            return;
        }

        if (state is PostModel post)
        {
            if (post.IsLiked)
            {
                _likeService.ExecuteLikeAdd(post);
            }
            else
            {
                _likeService.ExecuteLikeDelete(post);
            }
        }

    }
}