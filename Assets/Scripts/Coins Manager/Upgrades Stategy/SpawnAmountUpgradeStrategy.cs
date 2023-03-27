using Collector_Scripts;
using Collector_Scripts.Upgrades_Stategy;
using Game_User_Interface;
using Scriptable_Objects.Coins_Manager_Settings;
using Zenject;

namespace Coins_Manager.Upgrades_Stategy
{
    public class SpawnAmountUpgradeStrategy : IUpgradeStrategy
    {
        private Collector _collector;
        private UserInterfaceHandler _uiHandler;

        [Inject]
        public SpawnAmountUpgradeStrategy(Collector collector, UserInterfaceHandler uiHandler)
        {
            _collector = collector;
            _uiHandler = uiHandler;
        }
        
        public void Upgrade(CoinsManagerSettings settings)
        {
            if (_collector.ReduceCoins(settings.SpawnAmount * 100))
            {
                settings.SpawnAmount += 1;
                _uiHandler.UpgradeButtons.UpdateSpawnAmount(settings.SpawnAmount);
            }
        }
    }
}