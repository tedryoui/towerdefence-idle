using Scriptable_Objects.Coins_Manager_Settings;
using UnityEngine;
using Zenject;

namespace Collector_Scripts.Upgrades_Stategy
{
    public interface IUpgradeStrategy
    {
        public void Upgrade(CoinsManagerSettings settings);
    }
}