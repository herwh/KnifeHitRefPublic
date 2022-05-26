using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace KH
{
    public class BonusSpawner : MonoBehaviour
    {
        [FormerlySerializedAs("_bonusProbability")] [SerializeField] private BonusData _bonusData;
        [SerializeField] private Transform _bonusStartPosition;

        public event Action BonusIsDestroyed;
        private Bonus _bonus;

        private void Start()
        {
            BonusSpawn();
        }

        private void BonusSpawn()
        {
            int appleProbability = Random.Range(1, 100);
            if (appleProbability < _bonusData.Probability)
            {
                GameObject instance =
                    Instantiate(_bonusData.Bonus, _bonusStartPosition);
                _bonus = instance.GetComponent<Bonus>();
                _bonus.BonusIsDestroyed +=
                    BonusOnBonusIsDestroyed;
            }
        }

        private void BonusOnBonusIsDestroyed()
        {
            if (BonusIsDestroyed != null)
            {
                BonusIsDestroyed();
            }

            _bonus.BonusIsDestroyed -= BonusOnBonusIsDestroyed;
        }

        public void DestroyBonuses()
        {
            if (_bonus != null && !_bonus.IsDestroyed)
            {
                _bonus.DestroyBonus();
            }
        }
    }
}