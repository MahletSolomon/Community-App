using System;
using System.Windows;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Commands;

public class NewWindowCommand : CommandBase
{
    private Window _window { get; set; }
    ViewModelBase _viewModel;
    
    public NewWindowCommand(Window window, ViewModelBase feedViewModel)
    {
        _window = window;
        _viewModel = feedViewModel;
        _window.DataContext = feedViewModel;
        
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