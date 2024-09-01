using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;
using PAC.Scripts.Runtime.Managers.LevelConditionManager;
using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.ScriptableObjects;
using PAC.Scripts.Runtime.ServiceLocator;

namespace PAC.Scripts.Runtime.MVP.Models
{
    public class GameplayModel : BaseModel
    {
        public bool IsMusicActive { get; private set; }
        public bool IsSoundActive { get; private set; }
        public List<LevelCompletionCondition> LevelConditions { get; private set; } = new();
        public int Level { get; private set; }

        private readonly GameConfig _gameConfig;
        private readonly ILevelConditionManager _levelConditionManager;
        private readonly ILevelManager _levelManager;
        
        public GameplayModel()
        {
            _gameConfig = Locator.Instance.Get<GameConfig>();
            _levelConditionManager = Locator.Instance.Get<ILevelConditionManager>();
            _levelManager = Locator.Instance.Get<ILevelManager>();
            
           GetSettingsDataFromConfig();
           GetLevelData();
           NotifyDataChanged();
        }

        private void GetSettingsDataFromConfig()
        {
            IsMusicActive = _gameConfig.IsMusicActive;
            IsSoundActive = _gameConfig.IsSoundActive;
        }
        
        private void GetLevelData()
        {
            LevelConditions = _levelConditionManager.GetCompletionConditions();
            Level = _levelManager.GetLevelIndex();
        }
        
        public void SetMusicActive(bool isActive)
        {
            IsMusicActive = isActive;
            NotifyDataChanged();
        }
        
        public void SetSoundActive(bool isActive)
        {
            IsSoundActive = isActive;
            NotifyDataChanged();
        }
    }
}