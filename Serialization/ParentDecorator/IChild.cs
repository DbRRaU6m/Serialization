namespace ParentDecorator
{
    /// <summary>
    /// Interface for assignment of parent references.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChild<T>
    {
        T Parent { get; set; }
    }
}
