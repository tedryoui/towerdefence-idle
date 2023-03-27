using System.ComponentModel;
using Coins_Manager;
using Coins_Manager.Upgrades_Stategy;
using Collector_Scripts;
using Collector_Scripts.Upgrades_Stategy;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CoinsManagerInstaller : MonoInstaller
    {
        [SerializeField] private CoinsManager _coinsManager;
        
        public override void InstallBindings()
        {
            Container.Bind<IUpgradeStrategy>().WithId("SpawnTimeUpgrade").To<SpawnTimeUpgradeStrategy>().AsTransient();
            Container.Bind<IUpgradeStrategy>().WithId("SpawnAmountUpgrade").To<SpawnAmountUpgradeStrategy>().AsTransient();
            Container.Bind<IUpgradeStrategy>().WithId("RewardAmountUpgrade").To<RewardAmountUpgradeStrategy>().AsTransient();
            
            Container.Bind<CoinsManager>()
                .FromInstance(_coinsManager)
                .AsSingle()
                .NonLazy();
        }
    }
}