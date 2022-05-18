using KH;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public void RestartGame()
        {
            CommonFunctions.RestartScene();
        }

        public void GoToMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -
                                   1); //active scene = 1(gamescene) => 0 menu
        }
    }
}

