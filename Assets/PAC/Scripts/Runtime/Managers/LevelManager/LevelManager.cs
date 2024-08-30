using UnityEngine.SceneManagement;

namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public class LevelManager : ILevelManager
    {
        private int _currentLevelIndex;

        public int GetLevelIndex()
        {
            return _currentLevelIndex;
        }

        public void LoadNextLevel()
        {
            
        }

        public void LoadLevel(int index)
        {
           
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}