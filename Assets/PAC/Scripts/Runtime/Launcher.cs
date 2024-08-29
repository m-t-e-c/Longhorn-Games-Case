using PAC.Scripts.Runtime.Managers.LevelManager;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime
{
    public class Launcher : MonoBehaviour
    {
        private Locator _locator;

        private IViewManager _viewManager;
        
        private void Awake()
        {
            _locator = new Locator();

            _viewManager = new ViewManager();
            _locator.Register<IViewManager>(_viewManager);
        }
    }
}