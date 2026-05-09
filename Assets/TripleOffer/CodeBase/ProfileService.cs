using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class ProfileService
    {
        private readonly IEventBus _eventBus;
        public int PremiumDays { get; private set; }
        public List<string> Skins { get; private set; } = new();

        public ProfileService(IEventBus eventBus) => _eventBus = eventBus;

        public void AddPremium(int days)
        {
            PremiumDays += days;
            _eventBus.Publish(new ProfileChangedEvent());
        }

        public void AddSkin(string skinId)
        {
            if (!Skins.Contains(skinId))
            {
                Skins.Add(skinId);
                _eventBus.Publish(new ProfileChangedEvent());
            }
        }
    }
}