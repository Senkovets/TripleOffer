namespace TripleOffer.CodeBase
{
    public class OfferCompletedEvent
    {
        public string EventId;

        public OfferCompletedEvent(
            string eventId)
        {
            EventId = eventId;
        }
    }
}