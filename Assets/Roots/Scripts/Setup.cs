using UnityEngine;

namespace Roots
{
    [CreateAssetMenu(fileName = "Setup", menuName = "Roots/Setup", order = 0)]
    public class Setup : ScriptableObject
    {
        public float _timeToGrow;
        public float _timeToDecay;
        public float _timeToPoisoned;
    }
}