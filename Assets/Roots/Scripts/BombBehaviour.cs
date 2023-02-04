using DG.Tweening;
using UnityEngine;

namespace Roots
{
    public class BombBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Setup(LetterBehaviour lb)
        {
            this.transform.position = lb.transform.position;
            DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one * .5f, 3f))
                .Join(_spriteRenderer.DOColor(Color.red, .3f))
                .Join(DOTween.Sequence()
                    .Append(_spriteRenderer.DOColor(Color.white, .3f))
                    .Append(_spriteRenderer.DOColor(Color.red, .3f))
                    .Append(_spriteRenderer.DOColor(Color.white, .3f))
                    .Append(_spriteRenderer.DOColor(Color.red, .3f))
                    .Append(_spriteRenderer.DOColor(Color.white, .3f))
                    .Append(_spriteRenderer.DOColor(Color.red, .3f))
                    .Append(_spriteRenderer.DOColor(Color.white, .3f))
                    .Append(_spriteRenderer.DOColor(Color.red, .3f))
                    .Append(_spriteRenderer.DOColor(Color.white, .3f))
                    .Append(_spriteRenderer.DOColor(Color.red, .3f))
                )
                .OnComplete(() =>
                {
                    if (lb.HasRoot)
                    {
                        lb.Poison();
                    }
                    Destroy(gameObject);
                });
        }
    }
}