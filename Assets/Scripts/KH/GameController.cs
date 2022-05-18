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
                _coroutine = StartCoroutine(Wait());
            }

            _knifeController.LevelComplete -= KnifeControllerOnLevelComplete;
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(_waitForSecond);
            CommonFunctions.RestartScene();
            _coroutine = null;
        }
    }
}