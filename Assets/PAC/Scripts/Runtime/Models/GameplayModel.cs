using System.Collections.Generic;
using PAC.Scripts.Runtime.Objects;

namespace PAC.Scripts.Runtime.Models
{
    public class GameplayModel : BaseModel
    {
        public bool IsMusicActive { get; private set; }
        public bool IsSoundActive { get; private set; }
        public List<CompleteableObject> LevelConditions { get; private set; }
        public int Level { get; private set; }
        
        public GameplayModel()
        {
            IsMusicActive = true;
            IsSoundActive = true;
            
            // Todo : Replace with real data.
            LevelConditions = new List<CompleteableObject>();
            Level = 1;
        }
        
        public void SetMusicActive(bool isActive)
        {
            IsMusicActive = isActive;
            NotifyDataChanged();
        }
        
        public void SetSoundActive(bool isActive)
        {
            IsSoundActive = isActive;
            NotifyDataChanged();
        }
    }
}