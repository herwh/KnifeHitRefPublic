using System;
using System.Diagnostics;
using UnityEngine;

namespace KH
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private ObjectDestroyer _destroyer;
        [SerializeField] private AudioSource _destroyBonusSound;
        public bool IsDestroyed => _isDestroyed;
        public event Action BonusIsDestroyed;

        private bool _isDestroyed;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == 7) //7 - knife
            {
                DestroyBonus();
            }
        }

        public void DestroyBonus()
        {
            if (!_isDestroyed)
            {
                _destroyBonusSound.Play();
            }

            if (BonusIsDestroyed != null)
            {
                BonusIsDestroyed();
            }

            transform.SetParent(null);
            _destroyer.Destroy();
            _isDestroyed = true;
        }
    }
}