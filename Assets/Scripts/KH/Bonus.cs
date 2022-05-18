using System;
using UnityEngine;

namespace KH
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private ObjectDestroyer _destroyer;
        public bool IsDestroyed => _isDestroyed;
        public event Action BonusIsDestroyed;

        private bool _isDestroyed;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == 7) //7 - knife
            {
                DestroyBonus();
                if (BonusIsDestroyed != null)
                {
                    BonusIsDestroyed();
                }
            }
        }

        public void DestroyBonus()
        {
            transform.SetParent(null);
            _destroyer.Destroy();
            _isDestroyed = true;
        }
    }
}