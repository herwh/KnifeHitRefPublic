using System;
using System.Collections;
using KH;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _waitForSecond;

        private static readonly int ButtonClick = Animator.StringToHash("ButtonClick");
        private Coroutine _coroutine;

        public void RestartGame()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(AnimationCoroutine(CommonFunctions.RestartScene));
            }
        }

        public void GoToMenu()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(AnimationCoroutine(LoadMenuScene));
            }
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -
                                   1); //active scene = 1(gamescene) => 0 menu
        }

        private IEnumerator AnimationCoroutine(Action onComplete)
        {
            _animator.SetTrigger(ButtonClick);
            
            yield return new WaitForSeconds(_waitForSecond);
            
            onComplete();
            _coroutine = null;
        }
    }
}

