using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace MainProject.MVVM.ViewModel;

public class CommentViewModel:ViewModelBase
{
    
    public ICommand AddCommentCommand { get; set; }

    public CommentViewModel()
    {
       

    }
}
