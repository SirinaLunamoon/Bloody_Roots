using DG.Tweening;
using UnityEngine;

namespace Roots.Mini
{
    public class HeartBehaviour : MonoBehaviour
    {
        public static HeartBehaviour Instance;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        private Sequence _beatSequence;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            _beatSequence = DOTween.Sequence()
                .Join(transform.DOScale(Vector3.one * 4f, .3f))
                .Join(transform.DOScale(Vector3.one * 3f, .9f))
                .SetLink(gameObject)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void GameOver()
        {
            _beatSequence.Kill();
            _left.gameObject.SetActive(true);
            _right.gameObject.SetActive(true);
            _spriteRenderer.enabled = false;

            var s1 = DOTween.Sequence()
                .Append(_left.DOMove(_left.transform.position + Vector3.left * 1f, 3f))
                .Join(_left.DOScale(Vector3.one * 5f, 3f));
            
            var s2 = DOTween.Sequence()
                .Append(_right.DOMove(_right.transform.position + Vector3.right * 1f, 3f))
                .Join(_right.DOScale(Vector3.one * 5f, 3f));

            s1.Join(s2);
        }
    }
}