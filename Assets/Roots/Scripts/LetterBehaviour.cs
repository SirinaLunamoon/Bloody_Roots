using System;
using System.Collections.Generic;
using UnityEngine;

namespace Roots
{
    public class LetterBehaviour : MonoBehaviour
    {
        public event Action OnDecayed;
        public event Action OnPoisoned;

        [SerializeField] private KeyCode _letter;

        private readonly List<ChildInfo> _children = new List<ChildInfo>();

        public bool _isCenter;
        public KeyCode Letter => _letter;

        public readonly EasyBlocker ActionBlocker = new();
        
        public bool HasRoot
        {
            get;
            private set;
        }

        private void Start()
        {
            RootsManager.Instance.RegisterLetterBehaviour(this);
            if (_isCenter)
                HasRoot = true;
        }

        public void EatPrey(Prey prey)
        {
            // Play Eat Animation
            // Destroy Prey
        }

        public void Kill()
        {
            // Play Eat Animation
            // StartDecay
            // Kill with children
        }

        public void GrowChildRoot(LetterBehaviour other)
        {
            
            // Play grow animation
            var newRoot = Instantiate(PrefabsManager.Instance.UndergroundRootViewPrefab);
            newRoot.PerformGrow(this.transform, other.transform, Callback);
            this.ActionBlocker.AddBlocker(newRoot);
            other.ActionBlocker.AddBlocker(newRoot);
            _children.Add(new ChildInfo()
            {
                Children = other,
                Connection = newRoot
            });
            // Mark other as hasRoot
            other.MarkRootAsParent(this);

            void Callback()
            {
                this.ActionBlocker.RemoveBlocker(newRoot);
                other.ActionBlocker.RemoveBlocker(newRoot);
                other.HasRoot = true;
            }
        }

        private void MarkRootAsParent(LetterBehaviour other)
        {
            other.OnDecayed += StartDecay;
            other.OnPoisoned += StartPoisoned;
        }

        void StartDecay()
        {
            
        }
        
        void StartPoisoned() { }
    }
}
