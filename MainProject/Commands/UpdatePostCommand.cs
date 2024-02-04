using System.Threading.Tasks;
using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;

namespace WpfApp1.Commands;

public class UpdatePostCommand : CommandBase
{

    Window window;
    
    public UpdatePostService _updatePostService;

    public UpdatePostCommand(UpdatePostService updatePostService,UserPostWindow window)
    {
        _updatePostService = updatePostService;
        this.window = window;
    }


    public override void Execute(object parameter)
    {
        
        _updatePostService.Execute();
       window.Hide();
        
    }
}