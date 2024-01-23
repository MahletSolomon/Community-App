using MainProject.MVVM.Model;

namespace MainProject.MVVM.ViewModel;

public class PostControlViewModel
{
    private Post _post;
    public string Caption => _post.Caption;
    public string ImagePath => _post.ImagePath;
    public string Date => _post.Date;

    public PostControlViewModel(Post post)
    {
        _post = post;
    }
}