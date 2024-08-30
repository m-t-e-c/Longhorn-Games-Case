using PAC.Scripts.Runtime.Managers.LevelConditionManager;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.MVP.Views;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime.Level
{
    public class LevelController : MonoBehaviour
    {
        private ILevelConditionManager _levelConditionManager;
        private IViewManager _viewManager;

        private void Start()
        {
            _levelConditionManager = Locator.Instance.Get<ILevelConditionManager>();
            _viewManager = Locator.Instance.Get<IViewManager>();
            
            _levelConditionManager.OnAllConditionsMet += OnAllConditionsMet;
        }

        private void OnAllConditionsMet()
        {
            ShowLevelComplete();
        }

        private void ShowLevelComplete()
        {
            _viewManager.LoadView(new LoadViewParams<LevelCompletedView>("LevelCompletedView"));
        }
    }
}