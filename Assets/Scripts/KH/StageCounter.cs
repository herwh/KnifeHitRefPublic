using TMPro;
using UnityEngine;

namespace KH
{
    public class StageCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _stageText;
        [SerializeField] private KnifeController _knifeController;
        [SerializeField] private TextMeshProUGUI _tempStageText;

        private int _stageCount;

        private int _tempStageCount;

        private void OnEnable()
        {
            if (_knifeController != null)
            {
                _knifeController.LevelComplete += UpdateStageCount;
                _knifeController.GameOver += CheckNewStageCount;
            }

            LoadStageCount();
            DisplayStageCount();
        }

        private void OnDisable()
        {
            if (_knifeController != null)
            {
                _knifeController.LevelComplete -= UpdateStageCount;
                _knifeController.GameOver -= CheckNewStageCount;
            }
        }

        private void LoadStageCount()
        {
            _stageCount = PlayerPrefs.GetInt("stageCount", 0);
            _tempStageCount = PlayerPrefs.GetInt("tempStageCount", 0);
        }

        private void UpdateStageCount()
        {
            _tempStageCount++;
            PlayerPrefs.SetInt("tempStageCount", _tempStageCount);

        }

        public void CheckNewStageCount()
        {
            if (_tempStageCount > _stageCount)
            {
                _stageCount = _tempStageCount;
                PlayerPrefs.SetInt("stageCount", _stageCount);
            }

            DisplayStageCount();
            _tempStageCount = 0;
            PlayerPrefs.SetInt("tempStageCount", _tempStageCount);

        }

        private void DisplayStageCount()
        {
            if (_stageText != null)
            {
                _stageText.text = $"Stage {_stageCount + 1}";
            }

            if (_tempStageText != null)
            {
                _tempStageText.text = $"Stage {_tempStageCount + 1}";
            }
        }
    }
}