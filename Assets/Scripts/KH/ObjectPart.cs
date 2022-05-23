using UnityEngine;

namespace KH
{
    public class ObjectPart : MonoBehaviour
    {
        [SerializeField] private Transform _center;
        public Transform Center => _center;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Fall(Vector3 directionOfForce, int fallForce)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(directionOfForce * fallForce);
            _rigidbody.AddTorque(50, 50, 50);
        }
    }
}