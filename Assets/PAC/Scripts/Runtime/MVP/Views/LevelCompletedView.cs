using PAC.Scripts.Runtime.MVP.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.MVP.Views
{
    public class LevelCompletedView : BaseView<LevelCompletedView>
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button mainMenuButton;
        
        private LevelCompletedPresenter _presenter;

        protected new void Start()
        {
            base.Start();
            
            _presenter = new LevelCompletedPresenter(this);
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnNextLevelButtonClicked()
        {
            _presenter.NextLevel();
        }

        private void OnMainMenuButtonClicked()
        {
            _presenter.ReturnToMainMenu();
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
            nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }
    }
}