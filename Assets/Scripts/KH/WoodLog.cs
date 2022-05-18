using UnityEngine;

namespace KH
{
    public class WoodLog : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private ObjectDestroyer _destroyer;
        [SerializeField] private KnifeSpawner _knifeSpawner;
        [SerializeField] private BonusSpawner _bonusSpawner;

        void Update()
        {
            LogRotation();
        }

        private void LogRotation()
        {
            transform.Rotate(0, _speed * Time.deltaTime, 0);
        }

        public void DestroyWoodLog()
        {
            Stop();
            _destroyer.Destroy();
            _knifeSpawner.SpawnedKnivesFallOff();
            _bonusSpawner.DestroyBonuses();
        }

        public void Stop()
        {
            _speed = 0;
        }
    }
}
