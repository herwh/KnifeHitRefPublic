using TMPro;
using UnityEngine;


namespace KH
{
    public class BonusCounter : MonoBehaviour
    {
        [SerializeField] private BonusSpawner _bonusSpawner;
        [SerializeField] private TextMeshProUGUI _bonusText;

        private int _bonusCount;

        private void OnEnable()
        {
            if (_bonusSpawner != null)
            {
                _bonusSpawner.BonusIsDestroyed += UpdateBonusCount;
            }

            LoadBonusCount();
            DisplayBonusCount();
        }

        private void OnDisable()
        {
            if (_bonusSpawner != null)
            {
                _bonusSpawner.BonusIsDestroyed -= UpdateBonusCount;
            }
        }

        private void UpdateBonusCount()
        {
            _bonusCount++;
            DisplayBonusCount();
            PlayerPrefs.SetInt("bonusCount", _bonusCount);
        }


        private void LoadBonusCount()
        {
            _bonusCount = PlayerPrefs.GetInt("bonusCount", 0);
        }

        private void DisplayBonusCount()
        {
            _bonusText.text = _bonusCount.ToString();
        }
    }
}