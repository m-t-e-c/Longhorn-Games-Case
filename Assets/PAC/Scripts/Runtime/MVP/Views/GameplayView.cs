using System.Collections.Generic;
using PAC.Scripts.Runtime.Level;
using PAC.Scripts.Runtime.MVP.Presenters;
using PAC.Scripts.Runtime.UI;
using TMPro;
using UnityEngine;

namespace PAC.Scripts.Runtime.MVP.Views
{
    public class GameplayView : BaseView<GameplayView>
    {
        [SerializeField] private SettingsToggleButton musicButton;
        [SerializeField] private SettingsToggleButton soundButton;
        [SerializeField] private TextMeshProUGUI levelLabel;
        [SerializeField] private LevelConditionsPanel levelConditionPanel;
        
        private GameplayPresenter _presenter;

        protected override void Start()
        {
            base.Start();
            _presenter = new GameplayPresenter(this);
            
            musicButton.Button.onClick.AddListener(OnMusicButtonClicked);
            soundButton.Button.onClick.AddListener(OnSoundButtonClicked);
        }
        
        private void OnMusicButtonClicked()
        {
            _presenter.ToggleMusic();
        }
        
        private void OnSoundButtonClicked()
        {
            _presenter.ToggleSound();
        }

        public void UpdateLevelLabel(int level)
        {
            levelLabel.text = $"LEVEL {level}";
        }

        public void UpdateLevelConditions(List<LevelCompletionCondition> levelConditions)
        {
            levelConditionPanel.Initialize(levelConditions);
        }
        
        public void SetMusicActive(bool isActive)
        {
            musicButton.UpdateData(isActive);
        }

        public void SetSoundActive(bool isActive)
        {
            soundButton.UpdateData(isActive);
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
            
            musicButton.Button.onClick.RemoveListener(OnMusicButtonClicked);
            soundButton.Button.onClick.RemoveListener(OnSoundButtonClicked);
        }
    }
}