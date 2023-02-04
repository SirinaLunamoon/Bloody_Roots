using UnityEngine;

namespace Roots
{
    public class AcidBombManager : MonoBehaviour
    {
        public static AcidBombManager Instance;

        private float _timeToNextSpawn = 25f;

        private void Awake()
        {
            Instance = this;
        }

        bool TrySpawnBomb()
        {
            var target = RootsManager.Instance.FindBombProposition();
            if (target != null)
            {
                var bomb = Instantiate(PrefabsManager.Instance.BombPrefab);
                bomb.Setup(target);
                return true;
            }

            return false;
        }

        void Update()
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0f || Input.GetKeyDown(KeyCode.Space))
            {
                if (TrySpawnBomb())
                {
                    _timeToNextSpawn =
                        Random.Range(SetupManager.Access._spawnBombMin, SetupManager.Access._spawnBombMax);
                }
                else
                {
                    _timeToNextSpawn =
                        SetupManager.Access._spawnBombMin * .5f;
                }
            }
        }
    }
}