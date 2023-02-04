using UnityEngine;
using UnityEngine.Serialization;

namespace Roots
{
    public class PrefabsManager : MonoBehaviour
    {
        public static PrefabsManager Instance;

        [FormerlySerializedAs("_undergroundRootViewPrefab")] public UndergroundRootView UndergroundRootViewPrefab;
        public Prey PreyPrefab;
        public EatPrey EatPreyPrefab;
        public BombBehaviour BombPrefab;
        
        void Awake()
        {
            Instance = this;
        }
    }
}