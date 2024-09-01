using System.Collections.Generic;

namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public interface ILevelManager
    {
        int GetLevelIndex();
        void LoadNextLevel();
        void LoadCurrentLevel();
        void LoadLevel(int levelNumber);
        void RestartLevel();
        void LoadMainMenu();
        List<int> GetLevels();
    }
}