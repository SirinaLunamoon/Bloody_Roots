using DG.Tweening;
using UnityEngine;

namespace Roots.Mini
{
    public class OnGameOverScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _cg;
        void Start()
        {
            HeartBehaviour.Instance.OnGameOver += HandleGameOver;
        }

        private void HandleGameOver()
        {
            _cg.DOFade(1f, 3f);
        }

        private void OnDestroy()
        {
            HeartBehaviour.Instance.OnGameOver -= HandleGameOver;
        }
    }
}