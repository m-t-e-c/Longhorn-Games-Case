using System;
using System.Collections.Generic;
using PAC.Scripts.Runtime.MVP.Presenters;
using PAC.Scripts.Runtime.UI;
using UnityEngine;

namespace PAC.Scripts.Runtime.MVP.Views
{
    public class LevelsView : BaseView<LevelsView>
    {
        [SerializeField] private GameObject levelButtonPrefab;
        [SerializeField] private RectTransform levelsContainer;

        private LevelsPresenter _presenter;
        
        protected override void Start()
        {
            base.Start();
            _presenter = new LevelsPresenter(this);
        }

        public void InitializeLevelButtons(List<int> levelIndexes)
        {
            for (var i = 0; i < levelIndexes.Count; i++)
            {
                var levelButton = Instantiate(levelButtonPrefab, levelsContainer);
                levelButton.GetComponent<LevelButton>().Init(i + 1, OnLevelButtonClicked);
            }
        }

        private void OnLevelButtonClicked(int levelNumber)
        {
            _presenter.LoadLevel(levelNumber);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _presenter?.Dispose();
        }
    }
}