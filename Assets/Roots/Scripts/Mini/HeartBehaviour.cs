using DG.Tweening;
using UnityEngine;

namespace Roots.Mini
{
    public class HeartBehaviour : MonoBehaviour
    {
        void Start()
        {
            DOTween.Sequence()
                .Join(transform.DOScale(Vector3.one * 4f, .3f))
                .Join(transform.DOScale(Vector3.one * 3f, .9f))
                .SetLink(gameObject)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}