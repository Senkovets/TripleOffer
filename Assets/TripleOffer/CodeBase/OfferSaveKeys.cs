namespace TripleOffer.CodeBase
{
    public static class OfferSaveKeys
    {
        public static string GetOfferKey(string eventId)
        {
            return $"offer_{eventId}";
        }
    }
}