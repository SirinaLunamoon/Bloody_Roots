using System.Collections.Generic;
using System.IO;
using Roots.Menu;
using UnityEngine;

namespace Roots
{
    
    public class HiScore : MonoBehaviour, IComparer<HiScoreEntry>
    {
        public int LastScore = 0;
        string FileName => Path.Combine(Application.persistentDataPath, POINTS_FILE_NAME);
        private const string POINTS_FILE_NAME = "Points.roots";
        public List<HiScoreEntry> _hiScore;
        public static HiScore Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            
            if(File.Exists(FileName))
            {
                var t = File.ReadAllText(POINTS_FILE_NAME);
                _hiScore = JsonUtility.FromJson<List<HiScoreEntry>>(t);
            }
            else
            {
                _hiScore = new List<HiScoreEntry>()
                {
                    new HiScoreEntry("Zachi", 30),
                    new HiScoreEntry("Lila", 70),
                    new HiScoreEntry("Gosia", 40)
                };
            }
            
            Sort();
            Save();
        }

        void Sort()
        {
            _hiScore.Sort(this);
        }

        void Save()
        {
            File.WriteAllText(FileName, JsonUtility.ToJson(_hiScore));
        }

        public bool ProposeHighScore(int score)
        {
            LastScore = score;
            Sort();
            if (_hiScore.Count < 3 || _hiScore[2].Score < score)
            {
                return true;
            }

            return false;
        }

        public int Compare(HiScoreEntry x, HiScoreEntry y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return x.Score.CompareTo(y.Score);
        }
    }
}