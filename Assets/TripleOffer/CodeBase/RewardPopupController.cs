using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class RewardPopupController : MonoBehaviour
    {
        [Inject] private IEventBus _eventBus;
        [Inject] private IWindowService _windowService;

        private RewardPopupView _view;
        
        private void OnEnable()
        {
            _eventBus.Subscribe<RewardGrantedEvent>(OnRewardGranted);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<RewardGrantedEvent>(OnRewardGranted);
        }

        private void OnRewardGranted(RewardGrantedEvent evt)
        {
            foreach (var reward in evt.Rewards)
            {
                switch (reward)
                {
                    case GemsRewardData gems:
                        Debug.Log($"UI: received {gems.Amount} gems");
                        break;

                    case PremiumRewardData premium:
                        Debug.Log($"UI: received premium {premium.Days} days");
                        break;

                    case SkinRewardData skin:
                        Debug.Log($"UI: received skin {skin.SkinId}");
                        break;
                }
            }

            ShowPopup(evt.Rewards);
        }

        private void ShowPopup(List<RewardData> rewards)
        {
            // тут будет реальный UI
           // _view = _windowService.Open<RewardPopupView>();
            _view.Show(rewards);
            Debug.Log("Show reward popup");
        }
    }
}