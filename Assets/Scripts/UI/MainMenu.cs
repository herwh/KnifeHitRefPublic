using System;
using System.Collections;
using KH;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private StageCounter _stageCounter;
        [SerializeField] private float _waitForSecond;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _buttonSound;
        private Coroutine _coroutine;

        private void Start()
        {
            _stageCounter.CheckNewStageCount();
        }

        public void StartGame()
        {
            if (_coroutine == null)
            {
                CommonFunctions.PlayButtonSound(_buttonSound);
                _animator.SetTrigger("StartButtonClick");
                _coroutine = StartCoroutine(CommonFunctions.DelayCoroutine(LoadGameScene, _waitForSecond));
            }
        }

        public void ExitGame()
        {
            CommonFunctions.PlayButtonSound(_buttonSound);
            Application.Quit();
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //active scene = 0, gamescene = 0+1
            _coroutine = null;

        }
    }
}