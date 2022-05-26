using UnityEngine;

namespace UI
{
    public class DontDestroyOnLoadComponent : MonoBehaviour
    {
        private void Awake()
        {
            //проверка, существует ли компонент на сцене
            var component = FindObjectOfType<DontDestroyOnLoadComponent>();
            if (component != null && component != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}