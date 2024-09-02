using System;
using PAC.Scripts.Runtime.Level;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public class LevelConditionManager : ILevelConditionManager
    {
        private LevelCompletionCondition _completionCondition;

        public Action OnAllConditionsMet { get; set; }

        public LevelCompletionCondition GetCompletionCondition()
        {
            return _completionCondition;
        }

        public void RegisterCondition(LevelCompletionCondition condition)
        {
            _completionCondition = condition;
            condition.Initialize();
            condition.OnConditionMet += CheckLevelCompletion;
        }

        private void CheckLevelCompletion()
        {
            if (!_completionCondition.IsMet)
            {
                return;
            }

            OnAllConditionsMet?.Invoke();
            Debug.Log("Level Completed!");
        }
    }
}