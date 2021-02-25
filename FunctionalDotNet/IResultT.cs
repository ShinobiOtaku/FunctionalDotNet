namespace FunctionalDotNet
{
    /// <summary>
    /// The result of something.
    ///
    /// Has two states:
    /// - Success: <see cref="ItemOrDefault"/> is populated,<see cref="Errors"/> is empty.
    /// - Failure: <see cref="ItemOrDefault"/> is set to the default <see cref="T"/>,<see cref="Errors"/> is populated.
    /// </summary>
    public interface IResult<out T> : IResult
    {
        T ItemOrDefault { get; }
    }
}