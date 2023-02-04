using System;
using DG.Tweening;
using UnityEngine;

namespace Roots
{
    [RequireComponent(typeof(LineRenderer))]
    public class UndergroundRootView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _targetTransform;

        public void PerformGrow(Transform startTransform, Transform endTransform, Action onFinished)
        {
            var position = startTransform.position;
            _targetTransform.position = position;
            _lineRenderer.SetPositions(new []
            {
                position, 
                _targetTransform.position
            });

            var seq = DOTween.Sequence()
                .Append(_targetTransform.DOMove(endTransform.position, SetupManager.Access._timeToGrow))
                .SetLink(gameObject)
                .OnUpdate(() => _lineRenderer.SetPosition(1, _targetTransform.position))
                .OnComplete(() =>
                {
                    onFinished?.Invoke();
                });
        }
    }
}