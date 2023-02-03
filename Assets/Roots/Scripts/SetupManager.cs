using UnityEngine;

namespace Roots
{
    public class SetupManager : MonoBehaviour
    {
        public static Setup Access;
        [SerializeField] Setup _setup;

        private void Awake()
        {
            Access = _setup;
        }
        
    }
}