using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.UI
{
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private GameObject[] settingsOptions;
        
        private Button _button;
        private Sequence _buttonsSequence;
        private bool _isSettingsOpen;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }
        
        private void OnButtonClicked()
        {
            _isSettingsOpen = !_isSettingsOpen;

            _buttonsSequence?.Kill();
            _buttonsSequence = DOTween.Sequence();

            var sequenceOptions = _isSettingsOpen ? settingsOptions : settingsOptions.Reverse();

            foreach (var settingsOption in sequenceOptions)
            {
                _buttonsSequence.Append(settingsOption.transform.DOScale(_isSettingsOpen ? Vector3.one : Vector3.zero, 0.2f));
            }
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}