using System;
using Roots.Mini;
using UnityEngine;
using UnityEngine.UI;

namespace Roots.Energy
{
    public class EnergyManager : MonoBehaviour
    {
        public static EnergyManager Instance;

        [SerializeField] private Image _fillImage;
        private float Val = 100f;
        private float ValMax = 100f;

        private void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            Val -= (3.5f * Time.deltaTime);
            if (Val <= 0)
            {
                HeartBehaviour.Instance.GameOver();
            }

            _fillImage.fillAmount = (Val / ValMax);
        }

        public void AddEnergy(float count)
        {
            Val += count;
            if (Val > ValMax)
            {
                Val = ValMax;
            }
        }
    }
}