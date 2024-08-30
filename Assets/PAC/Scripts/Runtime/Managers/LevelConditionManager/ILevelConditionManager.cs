using System;
using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public interface ILevelConditionManager
    {
        public Action OnAllConditionsMet { get; set; }
        List<LevelCompletionCondition> GetCompletionConditions();
        void RegisterCondition(LevelCompletionCondition condition);
    }
}