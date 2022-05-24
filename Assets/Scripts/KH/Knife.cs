using UnityEngine;

namespace KH
{
    public class Knife : MonoBehaviour
    {
        [SerializeField] private int _fallForce;
        [SerializeField] private Vector3 _torque;
        [SerializeField] private GameObject _knifeEdge;

        public GameObject KnifeEdge => _knifeEdge;
        public delegate void CollisionHandler(Knife knife);

        public event CollisionHandler LogCollision;
        public event CollisionHandler KnifeCollision;

        private Rigidbody _rigidbody;
        private bool _isHit;
        private bool _fallOff;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void KnifeThrowing(float throwForce)
        {
            _rigidbody.AddForce(transform.forward * throwForce);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (!_isHit)
            {
                CollisionHandling(collision);
            }
        }

        private void CollisionHandling(Collision collision)
        {
            if (collision.gameObject.layer == 6) //6 это Log
            {
                Vibration.VibratePop();
                _isHit = true;
                if (LogCollision != null) LogCollision(this);
                SetLogAsParent(collision);
            }
            else if (collision.gameObject.layer == 7) //7 - Knife
            {
                Vibration.Vibrate();
                _isHit = true;
                if (KnifeCollision != null)
                {
                    KnifeCollision(this);
                }

                ThrowBack(-Vector3.up * _fallForce);
            }
        }

        private void SetLogAsParent(Collision collision)
        {
            if (_fallOff == false)
            {
                transform.SetParent(collision.transform);
                _rigidbody.isKinematic = true;
            }
        }

        private void ThrowBack(Vector3 force)
        {

            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.detectCollisions = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.AddForce(force);
            _rigidbody.AddTorque(_torque);
        }

        public void KnifeFallingOff()
        {
            Vector3 forceUp = new Vector3(0, 1, 0);
            _fallOff = true;
            transform.parent = null;
            ThrowBack(forceUp * 100);
        }
    }
}