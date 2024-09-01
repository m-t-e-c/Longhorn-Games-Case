using PAC.Scripts.Runtime.MVP.Models;
using PAC.Scripts.Runtime.MVP.Views;

namespace PAC.Scripts.Runtime.MVP.Presenters
{
    public class LevelsPresenter : BasePresenter<LevelsView>
    {
        private readonly LevelsModel _model;
        public LevelsPresenter(LevelsView view) : base(view)
        {
            _model = new LevelsModel();
            _model.OnDataChanged += UpdateView;
            
            UpdateView();
        }

        private void UpdateView()
        {
            View.InitializeLevelButtons(_model.GetLevelIndexes());
        }
        
        public void LoadLevel(int levelNumber)
        {
            _model.LoadLevel(levelNumber);
        }
        
        public override void Dispose()
        {
            _model.OnDataChanged -= UpdateView;
            _model.Dispose();
        }
    }
}