using UnityEngine;

namespace PAC.Scripts.Runtime.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "PAC/Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [field:SerializeField] public bool IsSoundActive { get; private set; }
        [field:SerializeField] public bool IsMusicActive { get; private set; }
        
        public void ToggleSound()
        {
            IsSoundActive = !IsSoundActive;
        }
        
        public void ToggleMusic()
        {
            IsMusicActive = !IsMusicActive;
        }
    }
}