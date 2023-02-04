using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roots
{
    public class AudioClipContainer : MonoBehaviour
    {
        public List<AudioClip> Screams;

        public static AudioClipContainer Instance;

        private void Awake()
        {
            Instance = this;
        }

        public AudioClip RandomScream()
        {
            return Screams[Random.Range(0, Screams.Count)];
        }
    }
}