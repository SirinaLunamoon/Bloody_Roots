using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Roots.Mini;
using Unity.Mathematics;
using UnityEngine;

namespace Roots
{
    public class LetterBehaviour : MonoBehaviour
    {
        public event Action<LetterBehaviour> OnDecayed;
        public event Action OnPoisoned;

        [SerializeField] private KeyCode _letter;
        private SpriteRenderer _spriteRenderer;
        private LetterBehaviour _parent;

        private readonly List<ChildInfo> _children = new List<ChildInfo>();

        public bool _isCenter;
        public KeyCode Letter => _letter;

        private Color originalColor;

        public readonly EasyBlocker ActionBlocker = new();
        
        public bool HasRoot
        {
            get;
            private set;
        }

        public bool NoChildren => _children.Count == 0; 

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            originalColor = _spriteRenderer.color;
            RootsManager.Instance.RegisterLetterBehaviour(this);
            if (_isCenter)
                HasRoot = true;
        }

        public void EatPrey(Prey prey)
        {
            prey.Halt();
            var eat = Instantiate(PrefabsManager.Instance.EatPreyPrefab);
            eat.Setup(this, prey, null);
            //Destroy(prey.gameObject);
            Debug.Log("POINTS!");
            // Play Eat Animation
            // Destroy Prey
        }

        public void BadDecision()
        {
            var badDecision = Instantiate(PrefabsManager.Instance.BadDecisionPrefab, transform.position, quaternion.identity);
            badDecision.Setup(this, Kill);
        }

        public void Kill()
        {
            var seq = DOTween.Sequence()
                .Append(_spriteRenderer.DOColor(Color.red, SetupManager.Access._timeToDecay))
                .OnStart(() => ActionBlocker.AddBlocker("KILL"))
                .AppendCallback(() =>
                {
                    HasRoot = false;
                    OnDecayed?.Invoke(this);
                    OnDecayed = null;
                })
                .Append(_spriteRenderer.DOColor(originalColor, SetupManager.Access._timeToDecay))
                .AppendCallback(() => ActionBlocker.RemoveBlocker("KILL"));
        }

        public void GrowChildRoot(LetterBehaviour other)
        {
            var upgradableRoot = _parent?.FindRoot(this);
            if (upgradableRoot)
            {
                upgradableRoot.UpgradeTo(other, Callback);
                this.ActionBlocker.AddBlocker(upgradableRoot);
                other.ActionBlocker.AddBlocker(upgradableRoot);
                _children.Add(new ChildInfo()
                {
                    Children = other,
                    Connection = upgradableRoot
                });
                other.MarkRootAsParent(this);
                other.OnDecayed += RemoveConnection;
                return;
            }
            // Play grow animation
            upgradableRoot = Instantiate(PrefabsManager.Instance.UndergroundRootViewPrefab);
            upgradableRoot.PerformGrow(this, other, Callback);
            this.ActionBlocker.AddBlocker(upgradableRoot);
            other.ActionBlocker.AddBlocker(upgradableRoot);
            _children.Add(new ChildInfo()
            {
                Children = other,
                Connection = upgradableRoot
            });
            // Mark other as hasRoot
            other.MarkRootAsParent(this);
            other.OnDecayed += RemoveConnection;

            void Callback()
            {
                this.ActionBlocker.RemoveBlocker(upgradableRoot);
                other.ActionBlocker.RemoveBlocker(upgradableRoot);
                other.HasRoot = true;
            }
        }

        private UndergroundRootView FindRoot(LetterBehaviour letterBehaviour)
        {
            var candidate =
                _children.FirstOrDefault(c => c.CanGrow && c.Connection.LastLetter == letterBehaviour._letter);
            return candidate?.Connection ? candidate?.Connection : null;
        }

        private void MarkRootAsParent(LetterBehaviour other)
        {
            _parent = other;
            other.OnDecayed += StartDecay;
            other.OnPoisoned += StartPoisoned;
        }

        public void Poison()
        {
            //OnDecayed?.Invoke(this);
            StartPoisoned();
        }

        private void RemoveConnection(LetterBehaviour lb)
        {
            var x = _children.FirstOrDefault(c => c.Children == lb);
            if (x == null)
            {
                Debug.Log("No connection!");
            }

            x.Children.OnDecayed -= RemoveConnection;
            _children.Remove(x);
            Destroy(x.Connection.gameObject);
        }

        void StartDecay(LetterBehaviour _)
        {
            Kill();
        }

        void StartPoisoned()
        {
            if (_isCenter)
            {
                HeartBehaviour.Instance.GameOver();
                Debug.Log("GAME OVER");
                return;
            }

            var par = _parent?._children.FirstOrDefault(c => c.Connection.LastLetter == this._letter);
            if (par != null)
            {
                par.Connection.Poison(_parent.Poison);
                StartDecay(this);
            }
            else
            {
                par.Children.Poison();
            }
        }
    }
}
