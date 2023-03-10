using System;
using TMPro;
using UnityEngine;

namespace Roots.Mini
{
    public class ScoresBehaviour : MonoBehaviour
    {
        private string Format = "Score: {0}";
        public static ScoresBehaviour Instance;
        
        private int _points = 0;
        [SerializeField] private TMP_Text _outputText;
        public int Points => _points;
        public event Action OnScore;

        private void Awake()
        {
            Instance = this;
            _points = 0;
        }

        void Start()
        {
            UpdateText();
        }

        public void AddPoint()
        {
            _points += 10;
            _outputText.text = string.Format(Format, _points);
            OnScore?.Invoke();
        }

        void UpdateText()
        {
            _outputText.text = string.Format(Format, _points);
        }
    }
}