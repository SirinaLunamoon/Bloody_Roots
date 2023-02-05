using UnityEngine;

namespace Roots
{
    public class PreyScaler : MonoBehaviour
    {
        private float _top = 2.6f;
        private float _bottom = -5.5f;

        private float ScaleMin = .8f;
        private float ScaleMax = 1.7f;

        private void Update()
        {
            float mScale = Mathf.InverseLerp(_top, _bottom, transform.position.y);
            transform.localScale = Vector3.one * Mathf.Lerp(ScaleMin, ScaleMax, mScale);
        }
    }
}