using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class LikedCommand:CommandBase
{
    private LikeService _likeService;
    public LikedCommand(LikeService likeService )
    {
        _likeService = likeService;
    }
    public override void Execute(object parameter)
    {
        if (parameter is PostModel post)
        {
            // _postInteractionService.Execute( post);
            if (post.IsLiked)
                post.TotalLike++;
            else
            {
                post.TotalLike--;
            }

            
        }
        
    }
}