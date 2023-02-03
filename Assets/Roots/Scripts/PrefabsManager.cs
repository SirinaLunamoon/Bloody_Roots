using UnityEngine;
using UnityEngine.Serialization;

namespace Roots
{
    public class PrefabsManager : MonoBehaviour
    {
        public static PrefabsManager Instance;

        [FormerlySerializedAs("_undergroundRootViewPrefab")] public UndergroundRootView UndergroundRootViewPrefab;
        
        void Awake()
        {
            Instance = this;
        }
    }
}