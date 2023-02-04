using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Assertions;

namespace Roots
{
    [RequireComponent(typeof(LineRenderer))]
    public class UndergroundRootView : MonoBehaviour
    {
        public const int MAX_POS_COUNT = 2;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private List<KeyCode> _letters;

        public bool IsUpgradable => _lineRenderer.positionCount < MAX_POS_COUNT;
        public KeyCode LastLetter => _letters[^1];

        public void PerformGrow(LetterBehaviour startBehaviour, LetterBehaviour endBehaviour, Action onFinished)
        {
            _letters.Add(startBehaviour.Letter);
            _letters.Add(endBehaviour.Letter);
            var position = startBehaviour.transform.position;
            _targetTransform.position = position;
            _lineRenderer.SetPositions(new []
            {
                position, 
                _targetTransform.position
            });

            var seq = DOTween.Sequence()
                .Append(_targetTransform.DOMove(endBehaviour.transform.position, SetupManager.Access._timeToGrow))
                .SetLink(gameObject)
                .OnUpdate(() => _lineRenderer.SetPosition(1, _targetTransform.position))
                .OnComplete(() =>
                {
                    onFinished?.Invoke();
                });
        }

        public void Poison(Action onFinish)
        {
            DOTween.Sequence()
                .Join(_lineRenderer.material.DOColor(Color.green, 1f))
                .OnComplete(() => onFinish?.Invoke());
        }

        public void UpgradeTo(LetterBehaviour letterBehaviour, Action onFinished)
        {
            _letters.Add(letterBehaviour.Letter);
            Assert.IsTrue(_lineRenderer.positionCount < MAX_POS_COUNT);
            var positions = new List<Vector3>();
            for (int i = 0; i < _lineRenderer.positionCount; i++)
            {
                positions.Add(_lineRenderer.GetPosition(i));
            }
            positions.Add(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1));
            _lineRenderer.positionCount++;
            _lineRenderer.SetPositions(positions.ToArray());
            var seq = DOTween.Sequence()
                .Append(_targetTransform.DOMove(letterBehaviour.transform.position, SetupManager.Access._timeToDecay))
                .SetLink(gameObject)
                .OnUpdate(() => _lineRenderer.SetPosition(_lineRenderer.positionCount-1, _targetTransform.position))
                .OnComplete(() => onFinished?.Invoke());
        }
    }
}