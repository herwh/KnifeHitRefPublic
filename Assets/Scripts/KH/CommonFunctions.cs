using UnityEngine.SceneManagement;

namespace KH
{
    public static class CommonFunctions
    {
        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //active scene = 1 (gamescene)
        }
    }
}