using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<LevelCompletionCondition> completionConditions;
        
        public delegate void LevelCompletedHandler();
        public event LevelCompletedHandler OnLevelCompleted;

        private void Start()
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