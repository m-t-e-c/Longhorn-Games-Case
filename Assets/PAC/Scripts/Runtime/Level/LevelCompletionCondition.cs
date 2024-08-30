using System;
using PAC.Scripts.Runtime.Managers.LevelConditionManager;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime.Level
{
    public abstract class LevelCompletionCondition : MonoBehaviour
    {
        public bool IsMet { get; private set; }
        public event Action OnConditionMet;

        private ILevelConditionManager _levelConditionManager;

        protected void Start()
        {
            _levelConditionManager = Locator.Instance.Get<ILevelConditionManager>();
            _levelConditionManager.RegisterCondition(this);
        }

        protected void MarkAsMet()
        {
            IsMet = true;
            OnConditionMet?.Invoke();
        }

        public abstract void Initialize();
    }
}