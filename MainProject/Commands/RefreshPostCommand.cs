using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.ViewModel;
using MainProject.Utilities;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class RefreshPostCommand:AsyncCommandBase
{
    private RetrieveCommunityPostService _retrieveCommunityPostService;

    private PostFeedViewModel _postFeedViewModel;
    public RefreshPostCommand(PostFeedViewModel postFeedViewModel)
    {
        _postFeedViewModel = postFeedViewModel;
        _retrieveCommunityPostService = new RetrieveCommunityPostService(_postFeedViewModel._LoginModel.ID);

    }
    protected override async Task ExecuteAsync(object parameter)
    {
        try
        {
            StackObservableCollection<PostModel> Post=new StackObservableCollection<PostModel>();
            _retrieveCommunityPostService.Execute(_postFeedViewModel.communityCardModel.ID,Post);
            _postFeedViewModel.Posts = Post;
            _postFeedViewModel._postStorage[_postFeedViewModel.communityCardModel.ID] = Post;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}