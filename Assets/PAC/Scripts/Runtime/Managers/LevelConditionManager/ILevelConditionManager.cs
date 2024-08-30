using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;

namespace PAC.Scripts.Runtime.Managers.LevelConditionManager
{
    public interface ILevelConditionManager
    {
        List<LevelCompletionCondition> GetCompletionConditions();
    }
}