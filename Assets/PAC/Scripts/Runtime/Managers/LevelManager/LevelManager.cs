using System.Collections.Generic;
using System.Threading.Tasks;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.MVP.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public class LevelManager : ILevelManager
    {
        private const string CurrentLevelKey = "CurrentLevelIndex";
        private int _currentLevelIndex;
        private readonly IViewManager _viewManager;

        public LevelManager(IViewManager viewManager)
        {
            _viewManager = viewManager;
            _currentLevelIndex = PlayerPrefs.GetInt(CurrentLevelKey, 1);
        }

        public int GetLevelIndex()
        {
            return _currentLevelIndex;
        }

        public List<int> GetLevels()
        {
            List<int> levels = new List<int>();

            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                levels.Add(i);
            }

            return levels;
        }

        public void LoadNextLevel()
        {
            List<int> levels = GetLevels();
            int nextLevelIndex = _currentLevelIndex + 1;
            if (nextLevelIndex < levels.Count + 1)
            {
                LoadLevel(nextLevelIndex);
            }
            else
            {
                _currentLevelIndex = 1;
                SaveCurrentLevelIndex();
                LoadMainMenu();
            }
        }

        public async void LoadLevel(int levelNumber)
        {
            List<int> levels = GetLevels();

            if (levels.Contains(levelNumber))
            {
                _currentLevelIndex = levelNumber;
                SaveCurrentLevelIndex();
                LoadLoadingView();
                await Task.Delay(1000);

                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelNumber);
                asyncLoad.allowSceneActivation = false;

                while (!asyncLoad.isDone)
                {
                    if (asyncLoad.progress >= 0.9f)
                    {
                        LoadGameplayView();
                        asyncLoad.allowSceneActivation = true;
                    }

                    await Task.Yield();
                }

                UnloadLoadingView();
            }
            else
            {
                Debug.LogWarning($"LevelManager: Level {levelNumber} does not exist!");
            }
        }

        public async void LoadCurrentLevel()
        {
            LoadLoadingView();
            await Task.Delay(1000);
            await LoadSceneAsync(_currentLevelIndex);
            LoadGameplayView();
            UnloadLoadingView();
        }

        public async void RestartLevel()
        {
            LoadLoadingView();
            await Task.Delay(1000);
            await LoadSceneAsync(_currentLevelIndex);
            LoadGameplayView();
            UnloadLoadingView();
        }

        public async void LoadMainMenu()
        {
            LoadLoadingView();
            await Task.Delay(1000);
            await LoadSceneAsync("MainMenu");
            LoadMainMenuView();
            UnloadLoadingView();
        }

        private void LoadLoadingView()
        {
            _viewManager.LoadView(new LoadViewParams<LoadingView>("LoadingView"));
        }

        private void UnloadLoadingView()
        {
            Debug.Log("LevelManager: UnloadLoadingView");
            _viewManager.DestroyView<LoadingView>();
        }

        private void LoadMainMenuView()
        {
            _viewManager.LoadView(new LoadViewParams<MainMenuView>("MainMenuView"));
        }
        
        private void LoadGameplayView()
        {
            _viewManager.LoadView(new LoadViewParams<GameplayView>("GameplayView"));
        }

        private async Task LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                }

                await Task.Yield();
            }
        }

        private async Task LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                }

                await Task.Yield();
            }
        }

        private void SaveCurrentLevelIndex()
        {
            PlayerPrefs.SetInt(CurrentLevelKey, _currentLevelIndex);
            PlayerPrefs.Save();
        }
    }
}