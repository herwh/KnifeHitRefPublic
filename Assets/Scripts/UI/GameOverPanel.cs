using KH;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _waitForSecond;
        [SerializeField]private AudioSource _buttonSound;

        private static readonly int ButtonClick = Animator.StringToHash("ButtonClick");
        private Coroutine _coroutine;
        

        public void RestartGame()
        {
            if (_coroutine == null)
            {
                _buttonSound.Play();
                _animator.SetTrigger(ButtonClick);
                _coroutine = StartCoroutine(CommonFunctions.DelayCoroutine(RestartScene, _waitForSecond));
            }
        }

        public void GoToMenu()
        {
            if (_coroutine == null)
            {
                _buttonSound.Play();
                _animator.SetTrigger(ButtonClick);
                _coroutine = StartCoroutine(CommonFunctions.DelayCoroutine(LoadMenuScene, _waitForSecond));
            }
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -
                                   1); //active scene = 1(gamescene) => 0 menu
            _coroutine = null;
        }

        private void RestartScene()
        {
            CommonFunctions.RestartScene();
            _coroutine = null;
        }
        
    }
}

