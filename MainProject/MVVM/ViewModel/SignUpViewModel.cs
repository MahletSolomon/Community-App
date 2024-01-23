using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class SignUpViewModel:ViewModelBase
{
    public ICommand NavigateLoginCommand { get; }
    public SignUpViewModel(NavigationStore navigationStore)
    {
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
            new NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore)));
    }
    
}