using System;
using MainProject.MVVM.ViewModel;

namespace WpfApp1.Stores;

public class NavigationStore
{
    public event Action CurrentViewModelChange;
    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel 
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChange();
        }
    }

    private void OnCurrentViewModelChange()
    {
        CurrentViewModelChange?.Invoke();
    }

}