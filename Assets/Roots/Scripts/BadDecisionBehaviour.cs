using System;
using DG.Tweening;
using UnityEngine;

namespace Roots
{
    public class BadDecisionBehaviour : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lr;
        [SerializeField] private Transform _followTransform;
        [SerializeField] private AudioSource _as;

        public void Setup(LetterBehaviour letter, Action onFinished)
        {
            var startPos = letter.transform.position;
            var topPos = startPos + Vector3.up * SetupManager.Access._distRootToPrey;

            _lr.SetPosition(0, startPos);
            _lr.SetPosition(1, startPos);
            _followTransform.position = startPos;

            DOTween.Sequence()
                .Append(_followTransform.DOMove(topPos, .5f))
                .SetLink(gameObject)
                .OnUpdate(() =>_lr.SetPosition(1, _followTransform.position))
                .Join(_lr.material.DOColor(Color.red, .5f))
                .OnComplete(() =>
                {
                    onFinished?.Invoke();
                    Destroy(gameObject);
                });
        }
    }
}