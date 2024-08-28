using System;
using UnityEngine;

namespace PAC.Scripts.Runtime.Level
{
    public abstract class LevelCompletionCondition : MonoBehaviour
    {
        public bool IsMet { get; protected set; }
        public event Action OnConditionMet;

        protected void MarkAsMet()
        {
            IsMet = true;
            OnConditionMet?.Invoke();
        }

        public abstract void Initialize();
    }
}