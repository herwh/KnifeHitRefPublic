using System.Collections.Generic;
using UnityEngine;

namespace KH
{
    public class ObjectDestroyer : MonoBehaviour
    {
        [SerializeField] private List<ObjectPart> _parts;
        [SerializeField] private int _fallForce;

        public void Destroy()
        {

            foreach (var part in _parts)
            {
                Vector3 up = new Vector3(0, 1, 0); 
                Vector3 distanceToCenter = part.Center.position - transform.position;
                Vector3 directionOfForce = distanceToCenter.normalized;
                part.Fall(directionOfForce + up, _fallForce);
            }
        }
    }
}