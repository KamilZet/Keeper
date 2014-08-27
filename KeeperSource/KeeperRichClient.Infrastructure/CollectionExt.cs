using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace System.Collections.Generic
{
    public static class CollectionExt
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

    }
}
