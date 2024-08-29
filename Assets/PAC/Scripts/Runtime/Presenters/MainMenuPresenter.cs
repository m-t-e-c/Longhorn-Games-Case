using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.Presenters
{
    public class MainMenuPresenter : BasePresenter<MainMenuPresenter>
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button levelsButton;
        
        private IViewManager _viewManager;

        protected override void Start()
        {
            base.Start();

            _viewManager = Locator.Instance.Get<IViewManager>();
            
            startGameButton.onClick.AddListener(OnStartGameButtonClicked);
            levelsButton.onClick.AddListener(OnLevelsButtonClicked);
        }
        
        private void OnStartGameButtonClicked()
        {
            Debug.Log("Start Game Button Clicked");
        }
        
        private void OnLevelsButtonClicked()
        {
            Debug.Log("Levels Button Clicked");
        }
    }
}