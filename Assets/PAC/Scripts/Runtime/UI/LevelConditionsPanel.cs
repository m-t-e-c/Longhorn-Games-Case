using System.Collections.Generic;
using System.Linq;
using PAC.Scripts.Runtime.Level;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.UI
{
    public class LevelConditionsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject levelConditionPrefab;

        private readonly Dictionary<LevelConditionIndicator, CompleteableObject> _levelConditionIndicators = new();

        public void Initialize(LevelCompletionCondition levelCondition)
        {
            var completeConditionAllObjectsUsed = levelCondition as CompleteConditionAllObjectsUsed;
            if (completeConditionAllObjectsUsed != null)
            {
                foreach (var completeableObject in completeConditionAllObjectsUsed.ObjectsToComplete)
                {
                    completeableObject.OnComplete += OnComplete;
                    var levelConditionIndicator = Instantiate(levelConditionPrefab, transform).GetComponent<LevelConditionIndicator>();
                    _levelConditionIndicators.Add(levelConditionIndicator, completeableObject);
                }
            }
        }

        private void OnComplete(CompleteableObject completeableObject)
        {
            var levelConditionIndicator = _levelConditionIndicators.FirstOrDefault(x => x.Value == completeableObject).Key;
            levelConditionIndicator?.SetCompleted();
        }
    }
}