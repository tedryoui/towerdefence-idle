using System;
using System.Collections;
using System.Collections.Generic;
using Coins_Manager.Upgrades_Stategy;
using Collector_Scripts;
using Collector_Scripts.Upgrades_Stategy;
using DG.Tweening;
using Game_User_Interface;
using Scriptable_Objects.Coins_Manager_Settings;
using UnityEngine;
using Zenject;

namespace Coins_Manager
{
    public class CoinsManager : MonoBehaviour
    {
        private UserInterfaceHandler _uiHandler;
        private Collector _collector;
        
        // TODO - Hide in settings
        [SerializeField] public CoinsManagerSettings _settings;
        [Inject(Id = "SpawnTimeUpgrade")] private IUpgradeStrategy SpawnTimeUpgradeStrategy;
        [Inject(Id = "SpawnAmountUpgrade")] private IUpgradeStrategy SpawnAmountUpgradeStrategy;
        [Inject(Id = "RewardAmountUpgrade")] private IUpgradeStrategy RewardAmountUpgradeStrategy;

        [Inject]
        public void Init(Collector collector, UserInterfaceHandler uiHandler)
        {
            _collector = collector;
            _uiHandler = uiHandler;
        }

        private void Start()
        {
            // TODO - Load from cloud/disk
            _settings = Instantiate(_settings);

            InitializeUpgradeStrategies();

            StartCoroutine(SpawnDelay());
        }

        // TODO - Somehow hide that into parameter class
        private void InitializeUpgradeStrategies()
        {
            _uiHandler.UpgradeButtons.SpawnTimeUpgrade += () => SpawnTimeUpgradeStrategy.Upgrade(_settings);
            _uiHandler.UpgradeButtons.UpdateSpawnTime(_settings.SpawnTime);
            _uiHandler.UpgradeButtons.SpawnAmountUpgrade += () => SpawnAmountUpgradeStrategy.Upgrade(_settings);
            _uiHandler.UpgradeButtons.UpdateSpawnAmount(_settings.SpawnAmount);
            _uiHandler.UpgradeButtons.RewardAmountUpgrade += () => RewardAmountUpgradeStrategy.Upgrade(_settings);
            _uiHandler.UpgradeButtons.UpdateRewardAmount(_settings.RewardAmount);
        }

        private IEnumerator SpawnDelay()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_settings.SpawnTime);

                for (int i = 0; i < _settings.SpawnAmount; i++)
                {
                    var coin = CreateCoin();
                    AnimateCoin(coin);
                }
            }
        }

        private void AnimateCoin(GameObject coin)
        {
            coin.transform.DOLocalRotate(new(360.0f, 360.0f, 360.0f), _settings.CoinSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
            coin.transform
                .DOMove(_collector.transform.position, _settings.CoinSpeed)
                .SetEase(Ease.InCubic)
                .OnComplete(() =>
                {
                    _collector.AddCoins(_settings.RewardAmount);
                    Destroy(coin);

                    coin.transform.DOKill();
                });
            
        }

        private GameObject CreateCoin()
        {
            var rndPosition = this.ComputeRandomPosition(_settings.SpawnRadius);
            var coin = Instantiate(_settings.CoinPrefab, rndPosition, Quaternion.identity, transform);
            return coin;
        }
    }
}