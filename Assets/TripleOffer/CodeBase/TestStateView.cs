using TMPro;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class TestStateView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gemsText;
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _premiumText;
        [SerializeField] private TMP_Text _skinsText;

        [Inject] private WalletService _wallet;
        [Inject] private ProfileService _profile;
        [Inject] private IEventBus _eventBus;

        private void OnEnable()
        {
            _eventBus.Subscribe<WalletChangedEvent>(Refresh);
            _eventBus.Subscribe<ProfileChangedEvent>(Refresh);
            Refresh();
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<WalletChangedEvent>(Refresh);
            _eventBus.Unsubscribe<ProfileChangedEvent>(Refresh);
        }

        private void Refresh(object evt = null)
        {
            _gemsText.text = $"Gems: {_wallet.Gems}";
            _coinsText.text = $"Coins: {_wallet.Coins}";
            _premiumText.text = $"Premium: {_profile.PremiumDays} days";
            _skinsText.text = $"Skins: {string.Join(", ", _profile.Skins)}";
        }
    }
}