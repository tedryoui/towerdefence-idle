using System;
using DG.Tweening;
using Game_User_Interface;
using Scriptable_Objects.Collector_Settings;
using UnityEngine;
using Zenject;

namespace Collector_Scripts
{
    public class Collector : MonoBehaviour
    {
        private UserInterfaceHandler _uiHandler;

        [SerializeField] private CollectorSettings _settings;

        [Inject]
        public void Init(UserInterfaceHandler uiHandler)
        {
            _uiHandler = uiHandler;
        }

        private void Awake()
        {
            _settings = Instantiate(_settings);
        }

        private void Start()
        {
            _uiHandler.Coins.Update(_settings.Coins);
        }

        public void AddCoins(int rewardAmount)
        {
            _settings.Coins += rewardAmount;
            _uiHandler.Coins.Update(_settings.Coins);
        }

        public bool ReduceCoins(int reduceAmount)
        {
            if (_settings.Coins < reduceAmount) return false;

            DOVirtual.Int(_settings.Coins, _settings.Coins - reduceAmount, 1.0f, (val) =>
            {
                _uiHandler.Coins.Update(val);
            });
            _settings.Coins -= reduceAmount;
            
            return true;

        }
    }
}