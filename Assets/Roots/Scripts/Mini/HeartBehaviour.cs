using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sequence = DG.Tweening.Sequence;

namespace Roots.Mini
{
    public class HeartBehaviour : MonoBehaviour
    {
        public static HeartBehaviour Instance;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;
        [SerializeField] private AudioSource _as;

        private Sequence _beatSequence;
        public event Action OnGameOver;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            _beatSequence = DOTween.Sequence()
                .AppendCallback(() => _as.PlayOneShot(AudioClipContainer.Instance.Heart))
                .Join(transform.DOScale(Vector3.one * .8f, .3f))
                .Join(transform.DOScale(Vector3.one * .72f, .9f))
                .SetLink(gameObject)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void GameOver()
        {
            if(HiScore.Instance)
                HiScore.Instance.ProposeHighScore(ScoresBehaviour.Instance.Points);
            _beatSequence.Kill();
            _as.PlayOneShot(AudioClipContainer.Instance.HeartBroken);
            _left.gameObject.SetActive(true);
            _right.gameObject.SetActive(true);
            _spriteRenderer.enabled = false;

            var s1 = DOTween.Sequence()
                .Append(_left.DOMove(_left.transform.position + Vector3.left * 1f, 3f))
                .Join(_left.DOScale(Vector3.one * 5f, 3f))
                .OnComplete(() => SceneManager.LoadScene("MenuScene"));
            
            var s2 = DOTween.Sequence()
                .Append(_right.DOMove(_right.transform.position + Vector3.right * 1f, 3f))
                .Join(_right.DOScale(Vector3.one * 5f, 3f));

            s1.Join(s2);
            OnGameOver?.Invoke();
            ;
        }
    }
}