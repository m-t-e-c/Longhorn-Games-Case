using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.MVP.Views;
using PAC.Scripts.Runtime.ServiceLocator;

namespace PAC.Scripts.Runtime.MVP.Models
{
    public class MainMenuModel : BaseModel
    {
        private readonly IViewManager _viewManager;
        private readonly ILevelManager _levelManager;
        
        public MainMenuModel()
        {
            _viewManager = Locator.Instance.Get<IViewManager>();
            _levelManager = Locator.Instance.Get<ILevelManager>();
        }
        
        public void StartGame()
        {
            _levelManager.LoadCurrentLevel();
        }
        
        public void ShowLevelsView()
        {
            _viewManager.LoadView(new LoadViewParams<LevelsView>("LevelsView"));
        }
    }
}