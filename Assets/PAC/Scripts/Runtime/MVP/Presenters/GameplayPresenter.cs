﻿using PAC.Scripts.Runtime.MVP.Models;
using PAC.Scripts.Runtime.MVP.Views;

namespace PAC.Scripts.Runtime.MVP.Presenters
{
    public class GameplayPresenter : BasePresenter<GameplayView>
    {
        private readonly GameplayModel _model;
        
        public GameplayPresenter(GameplayView view) : base(view)
        {
            _model = new GameplayModel();
            _model.OnDataChanged += OnDataChanged;

            InitializeLevelConditions();
            UpdateView();
        }

        private void OnDataChanged()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            View.SetMusicActive(_model.IsMusicActive);
            View.SetSoundActive(_model.IsSoundActive);
        }

        private void InitializeLevelConditions()
        {
            View.UpdateLevelLabel(_model.Level);
            View.UpdateLevelCondition(_model.LevelCondition);
        }
        
        public void ToggleMusic()
        {
            _model.SetMusicActive(!_model.IsMusicActive);
        }
        
        public void ToggleSound()
        {
            _model.SetSoundActive(!_model.IsSoundActive);
        }

        public override void Dispose()
        {
            _model.OnDataChanged -= OnDataChanged;
            _model.Dispose();
        }
    }
}