using PAC.Scripts.Runtime.Managers.LevelConditionManager;
using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.Managers.SoundManager;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.MVP.Views;
using PAC.Scripts.Runtime.ScriptableObjects;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime
{
    public class Launcher : MonoBehaviour
    {
        private Locator _locator;
        
        // Configs
        [SerializeField] private GameConfig gameConfig;

        // Mono Managers
        [SerializeField] private SoundManager soundManager;
        
        // Custom Managers
        private IViewManager _viewManager;
        private ILevelManager _levelManager;
        private ILevelConditionManager _levelConditionManager;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _locator = new Locator();
            
            _locator.Register<GameConfig>(gameConfig);

            _viewManager = new ViewManager();
            _locator.Register<IViewManager>(_viewManager);
            
            _levelManager = new LevelManager();
            _locator.Register<ILevelManager>(_levelManager);
            
            _levelConditionManager = new LevelConditionManager();
            _locator.Register<ILevelConditionManager>(_levelConditionManager);
            
            _locator.Register<ISoundManager>(soundManager);
        }

        private void Start()
        {
            _viewManager.LoadView(new LoadViewParams<MainMenuView>("MainMenuView"));
        }
    }
}