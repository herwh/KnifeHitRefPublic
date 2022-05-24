using System.Collections;
using UnityEngine;

namespace KH
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private KnifeController _knifeController;
        [SerializeField] private float _waitForSecond;

        private Coroutine _coroutine;

        private void Start()
        {
            _knifeController.LevelComplete += KnifeControllerOnLevelComplete;
        }

        private void KnifeControllerOnLevelComplete()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(CommonFunctions.DelayCoroutine(RestartScene,_waitForSecond));
            }

            _knifeController.LevelComplete -= KnifeControllerOnLevelComplete;
        }

        private void RestartScene()
        {
            CommonFunctions.RestartScene();
            _coroutine = null;
        }
        
        
    }
}