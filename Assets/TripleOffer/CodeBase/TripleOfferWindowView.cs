using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class TripleOfferWindowView
        : OfferWindowView
    {
        [SerializeField]
        private Transform _itemsContainer;

        [SerializeField]
        private Button _closeButton;

        [Inject]
        private IWindowService _windowService;

        [Inject]
        private OfferUiRegistry _uiRegistry;

        private IOffer _offer;

        public override void Setup(IOffer offer)
        {
            _offer = offer;

            BuildItems();

            _closeButton.onClick.AddListener(Close);
        }

        private void BuildItems()
        {
            ClearOldItems();
            
            OfferUiEntry uiEntry =
                _uiRegistry.Get(_offer.EventId);

            if (uiEntry == null)
            {
                Debug.LogError(
                    $"No UI entry for offer: {_offer.EventId}");

                return;
            }

            foreach (var item in _offer.Items)
            {
                OfferItemView prefab =
                    uiEntry.GetItemPrefab(
                        item.ItemViewId);

                if (prefab == null)
                {
                    Debug.LogError(
                        $"No item prefab for ItemViewId: {item.ItemViewId}");

                    continue;
                }

                OfferItemView itemView =
                    Instantiate(
                        prefab,
                        _itemsContainer);

                itemView.Setup(item, _offer);
            }
        }

        private void ClearOldItems()
        {
            foreach (Transform child in _itemsContainer)
            {
                Destroy(child.gameObject);
            }
        }

        private void Close()
        {
            _windowService.Close(this);
        }
    }
}