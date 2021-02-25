using System.Collections.Generic;

namespace FunctionalDotNet
{
    /// <summary>
    /// The result of something.
    ///
    /// Has two states:
    /// - Success: <see cref="Errors"/> is empty.
    /// - Failure: <see cref="Errors"/> is populated.
    /// </summary>
    public interface IResult
    {
        bool IsSuccess { get; }
        IEnumerable<string> Errors { get; }
    }
}