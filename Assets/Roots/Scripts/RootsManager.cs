using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roots
{
    public class RootsManager : MonoBehaviour
    {
        public static RootsManager Instance { get; private set; }

        private readonly Dictionary<KeyCode, LetterBehaviour> _letters = new();
        
        private void Awake()
        {
            RootsManager.Instance = this;
            
            InvokeRepeating(nameof(CheckPoison), 2f, 2f);
        }

        void CheckPoison()
        {
            if (_letters.Values.Any(l => l.IsPoisoned) == false)
            {
                AudioClipContainer.Instance.StopHazard();
            }
        }

        private void OnDestroy()
        {
            _letters.Clear();
            Instance = null;
        }
        
        public void RegisterLetterBehaviour(LetterBehaviour lb)
        {
            if (_letters.ContainsKey(lb.Letter))
            {
                Debug.LogError("This already exists in dict", lb);
                return;
            }
            
            _letters.Add(lb.Letter, lb);
        }

        public void HandleKeyPressed(KeyCode kc)
        {
            if (_letters.TryGetValue(kc, out var behaviour))
            {
                if (behaviour.HasRoot)
                {
                    var prey = PreyManager.Instance.GetPreyAtLocation(behaviour);
                    if (prey != null)
                    {
                        behaviour.EatPrey(prey);
                    }
                    else if(!behaviour._isCenter)
                    {
                        behaviour.BadDecision();
                    }
                }
                else if(!behaviour.ActionBlocker.IsBlocked)
                {
                    var possibleParent = FindPossibleParentForKey(kc);
                    if (possibleParent != null)
                    {
                        possibleParent.GrowChildRoot(behaviour);
                        AudioClipContainer.Instance.PlayRandomGrowClip();
                    }
                }
            }
            else
            {
                Debug.LogError($"Cannot find letter behaviour for {kc}!");
            }
        }

        public LetterBehaviour FindBombProposition()
        {
            var rootLetters = Neighbours.For(KeyCode.G);
            var possible = _letters.Values.Where(l => l.HasRoot && !l._isCenter && l.NoChildren).ToList();
            possible.RemoveAll(p => rootLetters.Contains(p.Letter));
            if (possible.Count > 0)
            {
                return possible[Random.Range(0, possible.Count)];
            }
            return null;
        }

        private LetterBehaviour FindPossibleParentForKey(KeyCode kc)
        {
            var possibilities = Neighbours.For(kc)
                .Where(k => _letters.ContainsKey(k) && _letters[k].HasRoot).ToArray();
            if (possibilities.Length > 0)
            {
                return _letters[possibilities[Random.Range(0, possibilities.Length)]];
            }

            return null;
        }
    }
}