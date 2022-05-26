using UnityEngine;

namespace KH
{
    [CreateAssetMenu(fileName = "New Bonus", menuName = "Bonus")]
    public class
        BonusData : ScriptableObject
    {
        [SerializeField] private GameObject _bonus;
        [SerializeField] private int _probability;

        public GameObject Bonus => _bonus;
        public int Probability => _probability;
    }
}