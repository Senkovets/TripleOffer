using System;

namespace TripleOffer.CodeBase
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow =>
            DateTime.UtcNow;
    }
}