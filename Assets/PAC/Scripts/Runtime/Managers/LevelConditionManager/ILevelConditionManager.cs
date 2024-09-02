using System;
using PAC.Scripts.Runtime.Level;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public interface ILevelConditionManager
    {
        public Action OnAllConditionsMet { get; set; }
        LevelCompletionCondition GetCompletionCondition();
        void RegisterCondition(LevelCompletionCondition condition);
    }
}