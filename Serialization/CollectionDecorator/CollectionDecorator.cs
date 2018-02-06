namespace CollectionDecorator
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Base class for concrete collection decorators.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CollectionDecorator<T> : ICollection<T>
    {
        private ICollection<T> Collection;

        public CollectionDecorator(ICollection<T> Collection)
        {
            Trace.WriteLine("CollectionDecorator constructor called");
            this.Collection = Collection;
        }

        #region implementation of ICollection<T>

        public virtual void Add(T item)
        {
            Collection.Add(item);
        }

        public virtual void Clear()
        {
            Collection.Clear();
        }

        public virtual bool Contains(T item)
        {
            return Collection.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return Collection.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return Collection.IsReadOnly; }
        }

        public virtual bool Remove(T item)
        {
            return Collection.Remove(item);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (Collection as System.Collections.IEnumerable).GetEnumerator();
        }

        #endregion
    }
}
