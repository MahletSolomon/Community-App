using WpfApp1.Stores;

namespace MainProject.MVVM.ViewModel;

public class MainViewModel:ViewModelBase
{
    private NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChange += OnCurrentViewModelChange;
    }

    private void OnCurrentViewModelChange()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}