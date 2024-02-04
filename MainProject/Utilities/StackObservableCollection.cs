using System.Collections.Generic;
using System.Collections.Specialized;

namespace MainProject.Utilities;

public class StackObservableCollection<T>:Stack<T>,INotifyCollectionChanged
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public new void Push(T item)
    {
        base.Push(item);
        CollectionChanged?.Invoke(this,new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item));
    }
}