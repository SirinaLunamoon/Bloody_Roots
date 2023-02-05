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

        public float CurrEnergyLostPerSecond;

        public float CurrVal => Val;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            CurrEnergyLostPerSecond = SetupManager.Access.InitialEnergyPerSecond;
            ScoresBehaviour.Instance.OnScore += HandleOnScore;
        }

        void HandleOnScore()
        {
            CurrEnergyLostPerSecond += SetupManager.Access.EnergyPerEnemy;
            if (CurrEnergyLostPerSecond > SetupManager.Access.MaxEnergyLostPerSecond)
                CurrEnergyLostPerSecond = SetupManager.Access.MaxEnergyLostPerSecond;
        }

        private void OnDestroy()
        {
            if (ScoresBehaviour.Instance)
                ScoresBehaviour.Instance.OnScore -= HandleOnScore;
        }

        void Update()
        {
            Val -= (CurrEnergyLostPerSecond * Time.deltaTime);
            if (Val <= 0)
            {
                HeartBehaviour.Instance.GameOver();
                enabled = false;
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