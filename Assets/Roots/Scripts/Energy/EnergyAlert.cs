using System;
using DG.Tweening;
using UnityEngine;

namespace Roots.Energy
{
    public class EnergyAlert : MonoBehaviour
    {
        private bool alert;

        private Sequence alertSeq;
        private void Update()
        {
            if (!alert && EnergyManager.Instance.CurrVal < 30f)
            {
                StartAlert();
                alert = true;
            }
            else if (alert && EnergyManager.Instance.CurrVal > 40f)
            {
                StopAlert();
                alert = false;
            }
        }

        void StartAlert()
        {
            alertSeq =
                DOTween.Sequence()
                    .Append(transform.DOScale(Vector3.one * 1.2f, .3f))
                    .Append(transform.DOScale(Vector3.one,.5f))
                    .SetLoops(-1);
        }

        void StopAlert()
        {
            alertSeq?.Kill();
            transform.localScale = Vector3.one;
        }
    }
}