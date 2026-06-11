using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class ProfileService
    {
        private const string SaveKey = "profile";

        private readonly IEventBus _eventBus;
        private readonly ISaveLoadService _saveLoad;

        public int PremiumDays { get; private set; }
        public List<string> Skins { get; private set; } = new();

        public ProfileService(IEventBus eventBus, ISaveLoadService saveLoad)
        {
            _eventBus = eventBus;
            _saveLoad = saveLoad;
            Load();
        }

        public void AddPremium(int days)
        {
            PremiumDays += days;
            Save();
            _eventBus.Publish(new ProfileChangedEvent());
        }

        public void AddSkin(string skinId)
        {
            if (Skins.Contains(skinId))
                return;

            Skins.Add(skinId);
            Save();
            _eventBus.Publish(new ProfileChangedEvent());
        }

        private void Save()
        {
            _saveLoad.Save(SaveKey, new ProfileState
            {
                PremiumDays = PremiumDays,
                Skins = Skins
            });
        }

        private void Load()
        {
            if (!_saveLoad.Exists(SaveKey))
                return;

            var state = _saveLoad.Load<ProfileState>(SaveKey);
            PremiumDays = state.PremiumDays;
            Skins = state.Skins ?? new List<string>();
        }
    }
}