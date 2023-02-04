using DG.Tweening;
using UnityEngine;

namespace Roots.Decorations
{
    public class RootDecoration : MonoBehaviour
    {
        private bool _killed = false;
        [SerializeField] private LineRenderer _lr;
        [SerializeField] private Transform _followTransform;
        
        public void StartOn(LetterBehaviour lb, LetterBehaviour next)
        {
            Register(lb);
            Register(next);
            _lr.SetPosition(0, lb.transform.position);
        }

        public void AddLetter(LetterBehaviour lb)
        {
            Register(lb);
        }

        private void Register(LetterBehaviour lb)
        {
            lb.OnDecayed += KillMe;
            lb.OnPoisoned += KillMe;
        }

        private void KillMe()
        {
            if (_killed)
                return;
            _killed = true;
            _lr.material.DOColor(Color.clear, 2f)
                .OnComplete(() => Destroy(gameObject));
        }

        public void KillMe(LetterBehaviour letterBehaviour) => KillMe();
    }
}