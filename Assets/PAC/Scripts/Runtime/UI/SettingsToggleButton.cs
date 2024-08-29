using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.UI
{
    public class SettingsToggleButton : MonoBehaviour
    {
        [SerializeField] private Image settingsIcon;
        [SerializeField] private Sprite activeIcon;
        [SerializeField] private Sprite deactiveIcon;
        
        public Button Button { get; private set; }
        private bool _isSettingActive;
        
        private void Awake()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnButtonClicked);
        }

        public void UpdateData(bool isActive)
        {
            _isSettingActive = isActive;
            settingsIcon.sprite = _isSettingActive ? activeIcon : deactiveIcon;
        }
        
        private void OnButtonClicked()
        {
            settingsIcon.sprite = _isSettingActive ? activeIcon : deactiveIcon;
        }
        
        private void OnDestroy()
        {
            Button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}