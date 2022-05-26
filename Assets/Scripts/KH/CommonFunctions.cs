using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KH
{
    public static class CommonFunctions
    {
        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //active scene = 1 (gamescene)
        }
        
        public static IEnumerator DelayCoroutine(Action onComplete, float delay)
        {
            yield return new WaitForSeconds(delay);
            
            onComplete();
        }
    }
}