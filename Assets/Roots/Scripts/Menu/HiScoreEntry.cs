using System;
using UnityEngine;

namespace Roots.Menu
{
    [Serializable]
    public class HiScoreEntry
    {
        [SerializeField] public int Score;
        [SerializeField] public string Name;

        public HiScoreEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}