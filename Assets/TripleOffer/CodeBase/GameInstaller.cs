using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private OfferUiRegistry _uiRegistry;
        public override void InstallBindings()
        {
            Container.Bind<OfferUiRegistry>().FromInstance(_uiRegistry).AsSingle();
            
            Container.Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle();

            Container.Bind<IConfigService>()
                .To<JsonConfigService>()
                .AsSingle();

            Container.Bind<IOfferFactory>()
                .To<OfferFactory>()
                .AsSingle();

            Container.Bind<IOfferService>()
                .To<OfferService>()
                .AsSingle();
            
            Container.Bind<IClock>()
                .To<SystemClock>()
                .AsSingle();

            Container.Bind<ISaveLoadService>()
                .To<FileSaveLoadService>()
                .AsSingle();
            

            Container.Bind<WalletService>().AsSingle();
            
            Container.Bind<IEventBus>().To<EventBus>().AsSingle();
            
            

            // Reward handlers (MULTI BIND)
            Container.Bind<IRewardHandler>().To<GemsRewardHandler>().AsSingle();
            Container.Bind<IRewardHandler>().To<PremiumRewardHandler>().AsSingle();
            Container.Bind<IRewardHandler>().To<SkinRewardHandler>().AsSingle();
            Container.Bind<IRewardHandler>().To<CoinsRewardHandler>().AsSingle();

            // Granter
            Container.Bind<GameRewardGranter>().AsSingle();
        }
    }
}