using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KH
{
    public class KnifeSpawner : MonoBehaviour
    {
        [SerializeField] private Knife _knife;
        [SerializeField] private List<Transform> _spawnPosition;
        [SerializeField] private int _knifeMaxCount;

        private List<Knife> _spawnedKnives;

        private void Start()
        {
            _spawnedKnives = new List<Knife>();
            SpawnKnife();
        }

        private void SpawnKnife()
        {
            int knifeCount = Random.Range(1, _knifeMaxCount + 1);
            for (int i = 0; i < knifeCount; i++)
            {
                if (i > _spawnPosition.Count - 1)
                {
                    return;
                }

                _spawnedKnives.Add(Instantiate(_knife, _spawnPosition[i]));
            }
        }

        public void SpawnedKnivesFallOff()
        {
            foreach (Knife k in _spawnedKnives)
            {
                k.KnifeFallingOff();
            }
        }
    }
}