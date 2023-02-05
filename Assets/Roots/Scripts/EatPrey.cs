using System;
using DG.Tweening;
using Roots.Energy;
using Roots.Mini;
using Unity.Mathematics;
using UnityEngine;

namespace Roots
{
    public class EatPrey : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lr;
        [SerializeField] private Transform _followTransform;
        [SerializeField] private GameObject _additional;
        [SerializeField] private AudioSource _as;
        [SerializeField] private AudioSource _secAs;

        public void Setup(LetterBehaviour letter, Prey prey, Action onFinished)
        {
            transform.localScale = Vector3.one * 2f;
            Instantiate(_additional, prey.transform.position, quaternion.identity);
            _secAs.PlayOneShot(AudioClipContainer.Instance.RandomStabClip());
            DOTween.Sequence().PrependInterval(.3f).OnComplete(() =>
                _as.PlayOneShot(AudioClipContainer.Instance.RandomScream())
            );
            EnergyManager.Instance.AddEnergy(SetupManager.Access.EnergyPerEnemy);
            var preyPos = prey.transform.position;
            var startPos = letter.transform.position;
            var vec = startPos - preyPos;
            vec *= -2f;
            var endPos = startPos + vec;

            _lr.positionCount = 2;
            _lr.SetPosition(0, startPos);
            _lr.SetPosition(1, startPos);
            _followTransform.position = startPos;
            var seq = DOTween.Sequence()
                .Append(_followTransform.DOMove(endPos, .2f))
                .OnUpdate(() => _lr.SetPosition(1, _followTransform.position))
                .OnComplete(Callback);

            void Callback()
            {
                ScoresBehaviour.Instance.AddPoint();
                onFinished?.Invoke();
                Invoke(nameof(KillMe), 1f);
            }
        }

        void KillMe()
        {
            Destroy(gameObject);
        }
    }
}