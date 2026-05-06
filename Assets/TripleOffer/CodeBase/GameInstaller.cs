using Zenject;

namespace TripleOffer.CodeBase
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Core services
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