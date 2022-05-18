using UnityEngine;

namespace KH
{
    public class HapticInitializer : MonoBehaviour
    {
        private void Start()
        {
            Vibration.Init();
        }
    }
}