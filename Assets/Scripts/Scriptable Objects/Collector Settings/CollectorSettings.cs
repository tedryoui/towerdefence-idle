using UnityEngine;

namespace Scriptable_Objects.Collector_Settings
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Presets/Collector", order = 0)]
    public class CollectorSettings : ScriptableObject
    {
        public int Coins;
    }
}