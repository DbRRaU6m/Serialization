namespace ParentDecorator
{
    using CollectionDecorator;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Decorator class for management of parent references.
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>

    // Note that no parameterless constructor is available, as it is not needed during deserialization.

    // http://www.thomaslevesque.com/2009/06/12/c-parentchild-relationship-and-xml-serialization/

    public class ParentDecorator<T> : CollectionDecorator<T> where T : IChild<T>
    {
        /// <summary>
        /// Parent object which is to be referenced from the inserted elements.
        /// </summary>
        private T Parent;

        public ParentDecorator(ICollection<T> Collection, T Parent)
            : base(Collection)
        {
            Trace.WriteLine("ParentDecorator constructor called");
            this.Parent = Parent;
        }

        #region implementation of ICollection<T>

        public override void Add(T item)
        {
            Trace.WriteLine("ParentDecorator Add called");
            base.Add(item);
            if (null != item)
            {
                item.Parent = Parent;
            }
        }

        public override bool Remove(T item)
        {
            Trace.WriteLine("ParentDecorator Remove called");
            var Result = base.Remove(item);
            if (Result && null != item)
            {
                item.Parent = default(T);
            }
            return Result;
        }

        #endregion
    }
}
