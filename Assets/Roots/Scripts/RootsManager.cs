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
                    var prey = PreyManager.Instance.GetPreyAtLocation(kc);
                    if (prey != null)
                    {
                        behaviour.EatPrey(prey);
                    }
                    else if(!behaviour._isCenter)
                    {
                        behaviour.Kill();
                    }
                }
                else
                {
                    var possibleParent = FindPossibleParentForKey(kc);
                    if (possibleParent != null)
                    {
                        possibleParent.GrowChildRoot(behaviour);
                    }
                }
            }
            else
            {
                Debug.LogError($"Cannot find letter behaviour for {kc}!");
            }
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