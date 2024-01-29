using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class NewPostCommand : AsyncCommandBase
{
        
    PostFeedViewModel PostFeedViewModel;
    Window window;
    
    public NewPostService _newPostService; 
    public NewPostCommand( NewPostWindow window, NewPostService newPostService) 
    {
        this.window = window;
        _newPostService = newPostService;

    }



    protected  override async Task ExecuteAsync(object parameter)
    {
        
        //MessageBox.Show(PostFeedViewModel.Caption);
        await _newPostService.Execute();
        window.Hide();
        //window.ClosingRequestedsted?.Invoke();
    }
}