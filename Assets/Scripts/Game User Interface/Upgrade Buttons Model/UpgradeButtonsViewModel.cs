using System;
using Coins_Manager;
using Collector_Scripts;
using UnityEngine;
using Zenject;

namespace Game_User_Interface.Upgrade_Buttons_Model
{
    [Serializable]
    public class UpgradeButtonsViewModel
    {
        [SerializeField] private UpgradeButtonsView _view;

        public event Action SpawnTimeUpgrade;
        public event Action SpawnAmountUpgrade;
        public event Action RewardAmountUpgrade;
        
        public void Bind()
        {
            _view.SpawnTimePressed += OnSpawnTimeUpgrade;
            _view.SpawnAmountPressed += OnSpawnAmountUpgrade;
            _view.RewardAmountPressed += OnRewardAmountUpgrade;
        }

        public virtual void OnSpawnTimeUpgrade() => SpawnTimeUpgrade?.Invoke();
        public virtual void OnSpawnAmountUpgrade() => SpawnAmountUpgrade?.Invoke();
        public virtual void OnRewardAmountUpgrade() => RewardAmountUpgrade?.Invoke();

        public void UpdateSpawnTime(float seconds) => _view.SpawnTime.SetText($"{seconds:F}S");
        public void UpdateSpawnAmount(int amount) => _view.SpawnAmount.SetText($"{amount} COIN");
        public void UpdateRewardAmount(int amount) => _view.RewardAmount.SetText($"{amount} COINS");
    }
}