using System.Collections.Generic;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Level
{
    public class CompleteConditionAllObjectsUsed : LevelCompletionCondition
    {
        [SerializeField] private List<CompleteableObject> objectsToComplete;
        [SerializeField] private bool findObjectsAtRuntime = true;
        public List<CompleteableObject> ObjectsToComplete => objectsToComplete;

        public override void Initialize()
        {
            if (findObjectsAtRuntime)
                FindCompleteableObjects();
            
            foreach (var obj in objectsToComplete)
            {
                obj.OnComplete += CheckCondition;
            }
        }

        private void FindCompleteableObjects()
        {
            var objects = FindObjectsOfType<CompleteableObject>();
            foreach (var obj in objects)
            {
                if (objectsToComplete.Contains(obj))
                {
                    continue;
                }
                
                objectsToComplete.Add(obj);
            }
        }

        private void CheckCondition(CompleteableObject completeableObject)
        {
            foreach (var obj in objectsToComplete)
            {
                if (!obj.IsComplete)
                {
                    return;
                }
            }

            MarkAsMet();
        }
    }
}