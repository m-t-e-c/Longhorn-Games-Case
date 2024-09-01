using PAC.Scripts.Runtime.MVP.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.MVP.Views
{
    public class MainMenuView : BaseView<MainMenuView>
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button levelsButton;

        private MainMenuPresenter _presenter;
        
        protected override void Start()
        {
            base.Start();
            
            _presenter = new MainMenuPresenter(this);
            
            startGameButton.onClick.AddListener(OnStartGameButtonClicked);
            levelsButton.onClick.AddListener(OnLevelsButtonClicked);
        }
        
        private void OnStartGameButtonClicked()
        {
            _presenter.StartGame();
        }
        
        private void OnLevelsButtonClicked()
        {
            _presenter.ShowLevelsPanel();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _presenter?.Dispose();
            startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
            levelsButton.onClick.RemoveListener(OnLevelsButtonClicked);
        }
    }
}