using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MiniCRM.Domain.Collections
{
    public class NotifyCollection<T> : ObservableCollection<T> where T : NotifyPropertyObject
    {
        #region ctors

        public NotifyCollection()
        {
            this.CollectionChanged += Items_CollectionChanged;
        }

        public NotifyCollection(List<T> list) : base(list)
        {
            AddRange(list);
            this.CollectionChanged += Items_CollectionChanged;
        }

        public NotifyCollection(IEnumerable<T> collection) : base(collection)
        {
            AddRange(collection);
            this.CollectionChanged += Items_CollectionChanged;
        }

        #endregion

        private void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.OldItems != null)
                    foreach (INotifyPropertyChanged item in e.OldItems)
                        item.PropertyChanged -= Item_PropertyChanged;

                if (e.NewItems != null)
                    foreach (INotifyPropertyChanged item in e.NewItems)
                        item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}
