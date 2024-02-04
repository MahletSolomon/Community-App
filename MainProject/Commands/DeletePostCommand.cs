using System.Windows;
using MainProject.MVVM.Model;
using MainProject.MVVM.View;
using MainProject.Services;

namespace WpfApp1.Commands;

public class DeletePostCommand:CommandBase
{
    private DeletePostService _deletePostService;
    private UserPostWindow _userPostWindow;
        
    public DeletePostCommand(DeletePostService deletePostService, UserPostWindow userPostWindow)
    {
        _deletePostService = deletePostService;
        _userPostWindow = userPostWindow;
    }
    public override void Execute(object parameter)
    {
        _deletePostService.Execute();
        _userPostWindow.Hide();
    }
}