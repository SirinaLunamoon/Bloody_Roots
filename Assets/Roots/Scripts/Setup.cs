using UnityEngine;

namespace Roots
{
    [CreateAssetMenu(fileName = "Setup", menuName = "Roots/Setup", order = 0)]
    public class Setup : ScriptableObject
    {
        public float _timeToGrow;
        public float _timeToDecay;
        public float _timeToPoisoned;
        public float _distRootToPrey = .5f;
        
        public float _spawnMax = 4f;
        public float _spawnMin = 2.5f;

        public float _spawnBombMin = 10f;
        public float _spawnBombMax = 22f;

        [Header("ENERGY")]
        public float EnergyPerEnemy = 10;
        public float InitialEnergyPerSecond = 3f;
        public float AddEnergyDrawPerEatenPrey = .1f;
        public float MaxEnergyLostPerSecond = 4.5f;

    }
}