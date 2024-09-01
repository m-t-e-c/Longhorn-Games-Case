using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.ServiceLocator;

namespace PAC.Scripts.Runtime.MVP.Models
{
    public class LevelCompletedModel : BaseModel
    {
        private readonly ILevelManager _levelManager;
        
        public LevelCompletedModel()
        {
            _levelManager = Locator.Instance.Get<ILevelManager>();
        }
        
        public void NextLevel()
        {
            _levelManager.LoadNextLevel();
        }
        
        public void ReturnToMainMenu()
        {
            _levelManager.LoadMainMenu();
        }
    }
}