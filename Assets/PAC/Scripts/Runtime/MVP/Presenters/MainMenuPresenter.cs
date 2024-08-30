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

            UpdateView();
        }
        
        private void OnDataChanged()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            // Update view with model data
        }
        
        public void StartGame()
        {
            _model.StartGame();
        }
        
        public void ShowLevelsPanel()
        {
            _model.ShowLevelsPanel();
        }
        
        public override void Dispose()
        {
            _model.OnDataChanged -= OnDataChanged;
            _model.Dispose();
        }
    }
}