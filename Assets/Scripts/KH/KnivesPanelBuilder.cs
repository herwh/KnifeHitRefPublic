using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KH
{
    public class KnivesPanelBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject _knivesPanel;
        [SerializeField] private Image _knifeSpritePrefab;
        [SerializeField] private KnifeController _knifeController;

        private List<Image> _knifeSprites;
        private void Start()
        {
            _knifeSprites = new List<Image>();
            KnivesPanelBuild(_knifeController.NumberOfKnives);
            _knifeController.KnifeThrowing += RemoveUpperKnife;
        }

        private void OnDestroy()
        {
            _knifeController.KnifeThrowing -= RemoveUpperKnife;
        }

        private void RemoveUpperKnife()
        {
            var upperKnife = _knifeSprites.First();
            upperKnife.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
            _knifeSprites.Remove(upperKnife);
        }

        private void KnivesPanelBuild(int knivesCount)
        {
            for (int knifeIndex = 0; knifeIndex < knivesCount; knifeIndex++)
            {
                var knife = Instantiate(_knifeSpritePrefab, Vector3.zero, Quaternion.identity, _knivesPanel.transform);
                _knifeSprites.Add(knife);
            }
        }
    }
}