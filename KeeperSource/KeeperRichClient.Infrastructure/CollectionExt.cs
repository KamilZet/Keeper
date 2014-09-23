


namespace System.Collections.ObjectModel
{
    using System.Collections.Generic;

    public static class CollectionExt
    {
        
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

    }
}
