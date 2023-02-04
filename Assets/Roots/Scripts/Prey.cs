using DG.Tweening;
using UnityEngine;

namespace Roots
{
    public class Prey : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        [SerializeField] private Sprite[] _killSeq;
        [SerializeField] private SpriteRenderer _renderer;
        public KeyCode CurrLocation => KeyCode.A;
        private Sequence seq;

        public void Start()
        {
            PreyManager.Instance.RegisterPrey(this);
        }

        public void GoTo(Vector3 target)
        {
            var duration = Vector3.Distance(transform.position, target) / _speed;
            seq = DOTween.Sequence()
                .SetLink(gameObject)
                .Append(transform.DOMove(target, duration))
                .OnComplete(() => Destroy(gameObject));
        }

        public void OnDestroy()
        {
            if (PreyManager.Instance)
                PreyManager.Instance.UnregisterPrey(this);
        }

        public void Halt()
        {
            seq.Kill();
            DOTween.Sequence()
                .SetLink(gameObject)
                .AppendCallback(() => _renderer.sprite = _killSeq[0])
                .AppendInterval(.2f)
                .AppendCallback(() => _renderer.sprite = _killSeq[1])
                .AppendInterval(.2f)
                .AppendCallback(() => _renderer.sprite = _killSeq[2])
                .AppendInterval(.2f)
                .AppendCallback(() => _renderer.sprite = _killSeq[3])
                .AppendInterval(.2f)
                .AppendCallback(KillMe)
                .Play();
        }

        void KillMe() => Destroy(gameObject);
    }
}