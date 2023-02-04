using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Roots
{
    public class AudioClipContainer : MonoBehaviour
    {
        [SerializeField] private AudioSource _growClipSource;
        [SerializeField] private AudioSource _hazardAudioSource;
        
        public List<AudioClip> Screams;
        public List<AudioClip> Grow;
        public List<AudioClip> Stab;
        public AudioClip Heart;
        public AudioClip HeartBroken;
        
        public static AudioClipContainer Instance;

        private void Awake()
        {
            Instance = this;
        }

        public AudioClip RandomScream()
        {
            return Screams[Random.Range(0, Screams.Count)];
        }

        public AudioClip RandomStabClip()
        {
            return Stab[Random.Range(0, Stab.Count)];
        }

        public void PlayRandomGrowClip()
        {
            _growClipSource.PlayOneShot(Grow[Random.Range(0, Grow.Count)]);
        }

        public void PlayHazard()
        {
            _hazardAudioSource.DOFade(.5f, 3f);
        }

        public void StopHazard()
        {
            _hazardAudioSource.DOFade(0f, .5f);
        }
    }
}