using UnityEngine;

namespace Scriptable_Objects.Coins_Manager_Settings
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Presets/Coins Manager", order = 0)]
    public class CoinsManagerSettings : ScriptableObject
    {
        public float SpawnTime;
        public int SpawnAmount;
        public int RewardAmount;
        public float SpawnRadius;
        
        // TODO - Make Addresables
        public GameObject CoinPrefab;
        public float CoinSpeed;
    }
}