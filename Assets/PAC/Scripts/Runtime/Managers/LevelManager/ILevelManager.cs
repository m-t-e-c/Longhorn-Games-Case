namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public interface ILevelManager
    {
        int GetLevelIndex();
        void LoadNextLevel();
        void LoadLevel(int index);
        void RestartLevel();
        void LoadMainMenu();
    }
}