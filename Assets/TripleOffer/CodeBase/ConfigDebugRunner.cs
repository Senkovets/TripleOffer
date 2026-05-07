using UnityEngine;
using Zenject;


namespace TripleOffer.CodeBase
{
    public class ConfigDebugRunner : MonoBehaviour
    {
        [Inject] private IConfigService _configService;

        private void Start()
        {
            var offers = _configService.LoadOffers();

            foreach (var offer in offers)
            {
                Debug.Log($"[ConfigDebugRunner] Loaded offer: {offer.Title}");

                foreach (var item in offer.Offers)
                {
                    Debug.Log($"[ConfigDebugRunner] Item: {item.Title}");

                    foreach (var reward in item.Rewards)
                    {
                        Debug.Log($"[ConfigDebugRunner] Reward type: {reward.GetType().Name}");
                    }
                }
            }
        }
    }
}