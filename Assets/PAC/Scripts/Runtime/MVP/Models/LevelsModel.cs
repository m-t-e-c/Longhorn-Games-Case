using System.Collections.Generic;
using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.ServiceLocator;

namespace PAC.Scripts.Runtime.MVP.Models
{
    public class LevelsModel : BaseModel
    {
        private readonly List<int> _levels;
        private readonly ILevelManager _levelManager;

        public LevelsModel()
        {
            _levelManager = Locator.Instance.Get<ILevelManager>();
            _levels = _levelManager.GetLevels();
            NotifyDataChanged();
        }
        
        public List<int> GetLevelIndexes()
        {
            return _levels;
        }
        
        public void LoadLevel(int levelNumber)
        {
            _levelManager.LoadLevel(levelNumber);
        }
    }
}