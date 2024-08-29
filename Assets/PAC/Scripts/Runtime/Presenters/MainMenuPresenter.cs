using PAC.Scripts.Runtime.Models;
using PAC.Scripts.Runtime.Views;

namespace PAC.Scripts.Runtime.Presenters
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
            // Start game
        }
        
        public void ShowLevelsPanel()
        {
            // Show levels panel
        }
        
        public override void Dispose()
        {
            _model.OnDataChanged -= OnDataChanged;
            _model.Dispose();
        }
    }
}