using System.Collections.Generic;
using System.Linq;
using PAC.Scripts.Runtime.Level;
using UnityEngine;

namespace PAC.Scripts.Runtime.UI
{
    public class LevelConditionsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject levelConditionPrefab;
        
        private readonly Dictionary<LevelConditionIndicator, LevelCompletionCondition> _levelConditionIndicators = new();

        public void Initialize(List<LevelCompletionCondition> levelConditions)
        {
            foreach (LevelCompletionCondition levelCondition in levelConditions)
            {
                levelCondition.OnConditionMet += OnConditionMet;
                var levelConditionIndicator = Instantiate(levelConditionPrefab, transform).GetComponent<LevelConditionIndicator>();
                _levelConditionIndicators.Add(levelConditionIndicator, levelCondition);
            }
        }

        private void OnConditionMet()
        {
            var levelConditionIndicator = _levelConditionIndicators.FirstOrDefault(x => x.Value.IsMet).Key;
            levelConditionIndicator?.SetCompleted();
        }
    }
}