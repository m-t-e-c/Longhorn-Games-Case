using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonLabel; 
        
        public void Init(int levelNumber, Action<int> onClicked)
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(() => onClicked?.Invoke(levelNumber));
            buttonLabel.text = levelNumber.ToString();
        }
    }
}