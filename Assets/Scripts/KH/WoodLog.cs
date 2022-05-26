using UnityEngine;

namespace KH
{
    public class WoodLog : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private ObjectDestroyer _destroyer;
        [SerializeField] private KnifeSpawner _knifeSpawner;
        [SerializeField] private BonusSpawner _bonusSpawner;
        [SerializeField] private GameObject _logParticle;
        [SerializeField] private AudioSource _destroyLogSound;

        //создать партикл через insctantiate когда нож соприкасается с бревном в точке соприкосновения???
        //надо получить точку соприкосновения
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
            _destroyLogSound.Play();
            _knifeSpawner.SpawnedKnivesFallOff();
            _bonusSpawner.DestroyBonuses();
        }

        public void Stop()
        {
            _speed = 0;
        }

        public void CreateHitEffect(Knife knife)
        {
            Instantiate(_logParticle, knife.KnifeEdge.transform.position, _logParticle.transform.rotation);
        }
    }
}
