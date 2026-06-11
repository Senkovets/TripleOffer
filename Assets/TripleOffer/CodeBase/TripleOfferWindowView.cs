using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class TripleOfferWindowView : OfferWindowView
    {
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _timerText; // Поле для таймера в окне

        [Inject] private IWindowService _windowService;
        [Inject] private OfferUiRegistry _uiRegistry;
        [Inject] private IEventBus _eventBus;

        private IOffer _offer;

        private void OnEnable()
        {
            _eventBus.Subscribe<OfferCompletedEvent>(
                OnOfferCompleted);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<OfferCompletedEvent>(
                OnOfferCompleted);
        }
        
        public override void Setup(IOffer offer)
        {
            base.Setup(offer);
            _offer = offer;

            BuildItems();
        
            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(Close);

            StopAllCoroutines();
            StartCoroutine(UpdateTimerRoutine());
        }

        private IEnumerator UpdateTimerRoutine()
        {
            while (_offer != null)
            {
                if (!_offer.IsAvailable)
                {
                    Close(); // закрываем окно
                    yield break;
                }
        
                if (_timerText != null)
                    _timerText.text = _offer.RemainingTimeStr;
            
                yield return new WaitForSeconds(1f);
            }
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
        
        private void OnOfferCompleted(OfferCompletedEvent evt)
        {
            Close();
        }
    }
}