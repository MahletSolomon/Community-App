using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Commands;

public abstract class AsyncCommandBase:ICommand
{
    public event EventHandler CanExecuteChanged;
    public virtual bool CanExecute(object parameter) => true;

    public  async void Execute(object parameter)
    {
        await ExecuteAsync(parameter);
    }

    protected abstract Task ExecuteAsync(object parameter);

    protected void OnCanExecuteChange()
    {
        CanExecuteChanged.Invoke(this,new EventArgs());
    }

}