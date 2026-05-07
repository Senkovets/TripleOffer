using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private List<MonoBehaviour> _windowPrefabs;
        
        public override void InstallBindings()
        {
            // Core services
            var windowMap = _windowPrefabs.ToDictionary(k => k.GetType(), v => v);

            // 2. Core services
            // Передаем созданный словарь специально для WindowService
            Container.Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle()
                .WithArguments(windowMap);
            
            Container.Bind<IConfigService>()
                .To<JsonConfigService>()
                .AsSingle();
            
            Container.Bind<WalletService>().AsSingle();
            
            Container.Bind<IEventBus>().To<EventBus>().AsSingle();
            
            

            // Reward handlers (MULTI BIND)
            Container.Bind<IRewardHandler>().To<GemsRewardHandler>().AsSingle();
            Container.Bind<IRewardHandler>().To<PremiumRewardHandler>().AsSingle();
            Container.Bind<IRewardHandler>().To<SkinRewardHandler>().AsSingle();

            // Granter
            Container.Bind<GameRewardGranter>().AsSingle();
        }
    }
}