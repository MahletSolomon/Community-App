using System;
using System.Windows;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class NewWindowCommand : CommandBase
{
    private Window _window { get; set; }
    ViewModelBase _postFeedViewModel;
    private Type _windowType;
    public NewWindowCommand(Window window, ViewModelBase feedViewModel)
    {
        _window = window;
        _postFeedViewModel = feedViewModel;
        _window.DataContext = _postFeedViewModel;
        _windowType = window.GetType();
    }
    public override void Execute(object parameter)
    {
            
                
        _window.ShowDialog();
            
        //if(!_window.IsVisible)
        // {
        //     _window.Activate();
        // }

    }
}