using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roots.Clouds
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        private float speed;

        void Start()
        {
            speed = Random.Range(_minSpeed, _maxSpeed);
        }

        private void Update()
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));

            if (transform.position.x < -15f)
            {
                transform.Translate(Vector3.right * 30f);
            }
        }
    }
}