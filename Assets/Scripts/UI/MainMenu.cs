using KH;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private StageCounter _stageCounter;

        private void Start()
        {
            _stageCounter.CheckNewStageCount();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //active scene = 0, gamescene = 0+1
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}