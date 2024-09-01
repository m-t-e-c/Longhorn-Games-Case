using System;
using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public class LevelConditionManager : ILevelConditionManager
    {
        private readonly List<LevelCompletionCondition> _completionConditions = new();
       
        public Action OnAllConditionsMet { get; set; }

        public List<LevelCompletionCondition> GetCompletionConditions()
        {
            return _completionConditions;
        }

        public void RegisterCondition(LevelCompletionCondition condition)
        {
            _completionConditions.Add(condition);
            condition.Initialize();
            condition.OnConditionMet += CheckLevelCompletion;
        }

        private void CheckLevelCompletion()
        {
            foreach (var condition in _completionConditions)
            {
                if (!condition.IsMet)
                {
                    return;
                }
            }

            OnAllConditionsMet?.Invoke();
            _completionConditions.Clear();
            Debug.Log("Level Completed!");
        }
    }
}