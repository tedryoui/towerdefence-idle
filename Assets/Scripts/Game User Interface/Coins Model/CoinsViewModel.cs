using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game_User_Interface.Coins_Model
{
    [Serializable]
    public class CoinsViewModel
    {
        [SerializeField] private CoinsView _view;
        
        public void Update(int amount)
        {
            _view.amount.SetText(amount.ToString());
        }
    }
}