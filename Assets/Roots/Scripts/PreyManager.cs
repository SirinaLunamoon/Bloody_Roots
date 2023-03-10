using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roots
{
    public class PreyManager : MonoBehaviour
    {
        private float _timeToNextSpawn = 5f;
        public static PreyManager Instance
        {
            get; private set;
        }

        private readonly List<Prey> _registeredPreys = new();
        private readonly List<PreySpawn> _registeredSpawns = new();

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

        public Prey GetPreyAtLocation(LetterBehaviour letterBehaviour)
        {
            float closest = SetupManager.Access._distRootToPrey + .1f;
            Prey found = null;
            foreach (var prey in _registeredPreys.Where(p => !p.IsKilled))
            {
                var dist = Vector3.Distance(prey.transform.position, letterBehaviour.transform.position);
                if (dist < closest)
                {
                    closest = dist;
                    found = prey;
                }
            }

            return found;
        }

        void Update()
        {
            _timeToNextSpawn -= Time.deltaTime;

            if (_timeToNextSpawn < 0f || Input.GetKeyDown(KeyCode.Return))
            {
                if(_timeToNextSpawn < 0f)
                    _timeToNextSpawn = Random.Range(SetupManager.Access._spawnMin, SetupManager.Access._spawnMax);
                var possibleSpawns = _registeredSpawns.Where(s => s._direction == false).ToList();
                var selectedSpawn = possibleSpawns.ElementAt(Random.Range(0, possibleSpawns.Count));

                var possibleExits = _registeredSpawns.Where(s => s._direction).ToList();
                var targetSpawn = possibleExits.ElementAt(Random.Range(0, possibleExits.Count));

                var spawnedPrey = Instantiate(PrefabsManager.Instance.PreyPrefab, selectedSpawn.transform.position, quaternion.identity);
                spawnedPrey.GoTo(targetSpawn.transform.position);
            }
        }

        public void RegisterSpawn(PreySpawn preySpawn)
        {
            _registeredSpawns.Add(preySpawn);
            
        }
    }
}