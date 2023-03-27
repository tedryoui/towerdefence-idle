using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game_User_Interface.Upgrade_Buttons_Model
{
    public class UpgradeButtonsView : MonoBehaviour
    {
        [Inject]
        public void Init(UserInterfaceHandler uiHandler)
        {
            uiHandler.UpgradeButtons.Bind();
        }
        
        public event Action SpawnTimePressed;
        public event Action SpawnAmountPressed;
        public event Action RewardAmountPressed;

        public TextMeshProUGUI SpawnTime;
        public TextMeshProUGUI SpawnAmount;
        public TextMeshProUGUI RewardAmount;

        public virtual void OnSpawnTimePressed()
        {
            SpawnTimePressed?.Invoke();
        }

        public virtual void OnSpawnAmountPressed()
        {
            SpawnAmountPressed?.Invoke();
        }

        public virtual void OnRewardAmountPressed()
        {
            RewardAmountPressed?.Invoke();
        }
    }
}