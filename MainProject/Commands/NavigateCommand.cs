using System;
using System.Windows;
using MainProject.MVVM.ViewModel;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace WpfApp1.Commands;

public class NavigateCommand<TViewModel>:CommandBase 
    where TViewModel : ViewModelBase
{
    private readonly NavigationService<TViewModel> _navigationService;
    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }
    public override void Execute(object parameter)
    {

        _navigationService.Navigate();
    }
}