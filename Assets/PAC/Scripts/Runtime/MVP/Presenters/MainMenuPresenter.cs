using PAC.Scripts.Runtime.MVP.Models;
using PAC.Scripts.Runtime.MVP.Views;

namespace PAC.Scripts.Runtime.MVP.Presenters
{
    public class MainMenuPresenter : BasePresenter<MainMenuView>
    {
        private readonly MainMenuModel _model;
        
        public MainMenuPresenter(MainMenuView view) : base(view)
        {
            _model = new MainMenuModel();
            _model.OnDataChanged += OnDataChanged;
        }
        
        private void OnDataChanged()
        {
        }
        
        public void StartGame()
        {
            _model.StartGame();
        }
        
        public void ShowLevelsPanel()
        {
            _model.ShowLevelsView();
        }
        
        public override void Dispose()
        {
            _model.OnDataChanged -= OnDataChanged;
            _model.Dispose();
        }
    }
}