using UnityEngine;

namespace Coins_Manager
{
    public static class CoinsManagerHelper
    {
        public static Vector3 ComputeRandomPosition(this CoinsManager manager, float radius)
        {
            var rndAngle = UnityEngine.Random.Range(0, 360);
            var direction = Quaternion.Euler(0, rndAngle, 0) * manager.transform.forward;
            var position = direction * radius;
            
            return manager.transform.position + position;
        }
    }
}