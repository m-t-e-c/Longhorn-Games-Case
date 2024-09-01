using PAC.Scripts.Runtime.MVP.Models;
using PAC.Scripts.Runtime.MVP.Views;
using UnityEngine;

namespace PAC.Scripts.Runtime.MVP.Presenters
{
    public class LevelCompletedPresenter : BasePresenter<LevelCompletedView>
    {
        private LevelCompletedModel _model;
        
        public LevelCompletedPresenter(LevelCompletedView view) : base(view)
        {
            _model = new LevelCompletedModel();
            _model.OnDataChanged += OnDataChanged;
        }
        
        private void OnDataChanged()
        {
            // Update view
        }
        
        public void NextLevel()
        {
           _model.NextLevel();
        }
        
        public void ReturnToMainMenu()
        {
            _model.ReturnToMainMenu();
        }
        
        public override void Dispose()
        {
            _model.OnDataChanged -= OnDataChanged;
            _model = null;
        }
    }
}