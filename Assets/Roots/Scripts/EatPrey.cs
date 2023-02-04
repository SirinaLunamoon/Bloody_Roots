using System;
using DG.Tweening;
using UnityEngine;

namespace Roots
{
    public class EatPrey : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lr;
        [SerializeField] private Transform _followTransform;
        
        public void Setup(LetterBehaviour letter, Prey prey, Action onFinished)
        {
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