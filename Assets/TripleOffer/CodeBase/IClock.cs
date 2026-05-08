using System;

namespace TripleOffer.CodeBase
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}