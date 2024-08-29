using System.Collections.Generic;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.UI
{
    public class LevelConditionsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject levelConditionPrefab;
        
        private readonly Dictionary<LevelConditionIndicator, CompleteableObject> _levelConditionIndicators = new();

        public void Initialize(List<CompleteableObject> levelConditions)
        {
            foreach (CompleteableObject levelCondition in levelConditions)
            {
                var levelConditionIndicator = Instantiate(levelConditionPrefab, transform).GetComponent<LevelConditionIndicator>();
                _levelConditionIndicators.Add(levelConditionIndicator, levelCondition);
            }
        }
    }
}