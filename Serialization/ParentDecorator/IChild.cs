namespace ParentDecorator
{
    /// <summary>
    /// Interface for assignment of parent references.
    /// </summary>
    /// <typeparam name="P"></typeparam>
    public interface IChild<P>
    {
        P Parent { get; set; }
    }
}
