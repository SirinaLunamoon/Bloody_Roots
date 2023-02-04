using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roots
{
    public class PreyManager : MonoBehaviour
    {
        public static PreyManager Instance
        {
            get; private set;
        }

        private readonly List<Prey> _registeredPreys = new();

        private void Awake()
        {
            PreyManager.Instance = this;
        }

        public void RegisterPrey(Prey prey)
        {
            _registeredPreys.Add(prey);
        }

        public void UnregisterPrey(Prey prey)
        {
            _registeredPreys.Remove(prey);
        }

        public Prey GetPreyAtLocation(KeyCode kc)
        {
            return _registeredPreys.FirstOrDefault(p => p.CurrLocation == kc);
        }
    }
}