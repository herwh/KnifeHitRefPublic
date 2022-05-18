using TMPro;
using UnityEngine;

namespace KH
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _tempScoreText;
        [SerializeField] private KnifeController _knifeController;

        private int _scoreCount;

        private int _tempScoreCount;

        private void OnEnable()
        {
            if (_knifeController != null)
            {
                _knifeController.KnifeWithLogCollision += UpdateScoreCount;
                _knifeController.GameOver += CheckNewScoreCount;
            }

            LoadScoreCount();
            DisplayScoreCount();
        }

        private void OnDisable()
        {
            if (_knifeController != null)
            {
                _knifeController.KnifeWithLogCollision -= UpdateScoreCount;
                _knifeController.GameOver -= CheckNewScoreCount;
            }
        }

        private void LoadScoreCount()
        {
            _scoreCount = PlayerPrefs.GetInt("scoreCount", 0);
            _tempScoreCount = PlayerPrefs.GetInt("tempScoreCount", 0);
        }

        private void UpdateScoreCount()
        {
            _tempScoreCount++;
            PlayerPrefs.SetInt("tempScoreCount", _tempScoreCount);
            DisplayScoreCount();
        }

        private void CheckNewScoreCount()
        {
            if (_tempScoreCount > _scoreCount)
            {
                _scoreCount = _tempScoreCount;
                PlayerPrefs.SetInt("scoreCount", _scoreCount);
            }

            DisplayScoreCount();
            _tempScoreCount = 0;
            PlayerPrefs.SetInt("tempScoreCount", _tempScoreCount);

        }

        private void DisplayScoreCount()
        {
            if (_scoreText != null)
            {
                _scoreText.text = $"Score {_scoreCount}";
            }

            if (_tempScoreText != null)
            {
                _tempScoreText.text = _tempScoreCount.ToString();
            }
        }
    }
}