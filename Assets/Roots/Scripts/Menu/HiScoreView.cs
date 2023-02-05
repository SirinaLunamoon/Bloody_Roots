using TMPro;
using UnityEngine;

namespace Roots.Menu
{
    public class HiScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmPro;
        
        void Start()
        {
            var hs = HiScore.Instance.LastScore;
            if (hs > 0)
            {
                _tmPro.text = $"Your score: {hs}";
            }
            else
            {
                _tmPro.text = "";
            }
        }
    }
}