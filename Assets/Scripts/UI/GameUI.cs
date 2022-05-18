using KH;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private KnifeController _knifeController;
        [SerializeField] private GameObject _gameOverPanel;

        private void Start()
        {
            _knifeController.GameOver += KnifeControllerOnGameOver;
        }

        private void KnifeControllerOnGameOver()
        {
            _gameOverPanel.SetActive(true);
            _knifeController.GameOver -= KnifeControllerOnGameOver;
        }
    }
}