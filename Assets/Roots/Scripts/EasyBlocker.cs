using System;
using System.Collections.Generic;

namespace Roots
{
    public class EasyBlocker : IDisposable
    {
        private readonly List<Object> _blockers = new();
        private event Action AwaitingMethods;

        public bool IsBlocked => _blockers.Count > 0;

        public void AddBlocker(Object blocker)
        {
            if (_blockers.Contains(blocker))
                return;

            _blockers.Add(blocker);
        }

        public void RemoveBlocker(Object blocker)
        {
            _blockers.Remove(blocker);

            if (!IsBlocked)
            {
                AwaitingMethods?.Invoke();
                AwaitingMethods = null;
            }
        }

        public void WaitTillUnlocked(Action method)
        {
            if (!IsBlocked)
            {
                method?.Invoke();
                return;
            }

            AwaitingMethods += method;
        }

        public void Dispose()
        {
            AwaitingMethods = null;
        }
    }
}