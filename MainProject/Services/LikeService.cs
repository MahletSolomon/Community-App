using System.Collections.ObjectModel;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Services;

public class LikeService
{
    private PostFeedViewModel _postFeedViewModel;
    //private  ObservableCollection<PostModel> _postModel;
    public LikeService(PostFeedViewModel postFeedViewModel)
    {
        _postFeedViewModel = postFeedViewModel;
        //_postModel = postModel;
    }

    public void Execute(PostModel postModel)
    {
        MessageBox.Show(postModel.TotalLike.ToString());
        postModel.TotalLike++;
    }
}