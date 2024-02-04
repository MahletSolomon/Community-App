using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MainProject.Utilities;

    public class LinkedListObservableCollection<T> :LinkedList<T>, INotifyCollectionChanged
    {

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public new void AddLast(T item)
        {
            base.AddLast(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }
        public new void AddFirst(T item)
        {
            base.AddFirst(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public T RemoveLast()
        {
            if (base.Count == 0)
                throw new InvalidOperationException("The collection is empty");

            T lastItem = base.Last.Value;
            base.RemoveLast();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, lastItem));
            return lastItem;
        }

    }
