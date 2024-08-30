using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public class LevelConditionManager : MonoBehaviour , ILevelConditionManager
    {
        [SerializeField] private List<LevelCompletionCondition> completionConditions;
        
        public delegate void LevelCompletedHandler();
        public event LevelCompletedHandler OnLevelCompleted;
        
        private void Awake()
        {
            InitializeConditions();
        }

        private void InitializeConditions()
        {
            foreach (var condition in completionConditions)
            {
                condition.Initialize();
                condition.OnConditionMet += CheckLevelCompletion;
            }
        }
        
        public List<LevelCompletionCondition> GetCompletionConditions()
        {
            return completionConditions;
        }

        private void CheckLevelCompletion()
        {
            foreach (var condition in completionConditions)
            {
                if (!condition.IsMet)
                {
                    return;
                }
            }

            OnLevelCompleted?.Invoke();
            Debug.Log("Level Completed!");
        }
    }
}