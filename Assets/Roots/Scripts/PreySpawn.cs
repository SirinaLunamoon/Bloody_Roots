using UnityEngine;

namespace Roots
{
    public class PreySpawn : MonoBehaviour
    {
        [SerializeField] public bool _direction;

        void Start()
        {
            PreyManager.Instance.RegisterSpawn(this);
        }
    }
}