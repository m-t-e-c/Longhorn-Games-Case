using System;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.LevelManager
{
    public class LoadViewParams<T> : EventArgs
    {
        public readonly string ViewName;
        public Action<T> OnLoad;

        readonly string _viewPresenterType;

        public LoadViewParams(string viewName)
        {
            ViewName = viewName;
            _viewPresenterType = typeof(T).Name;
        }
        
        public string GetViewPresenterType()
        {
            return _viewPresenterType;
        }
    }
    
    public interface IViewManager
    {
        Action<string> OnViewLoaded { get; set; }
        Action<string> OnViewClosed { get; set; }
        void ForceAddToViewList<T>(LoadViewParams<T> viewPresenter, GameObject viewInstance);
        void LoadView<T>(LoadViewParams<T> loadViewParams, bool closeAllViews = false, bool closeLastView = false);
        void DestroyView<T>();
        void DestroyAllViews();
        bool IsAnyViewActive();
        bool IsViewActive<T>();
        bool IsCurrentView(string viewName);
    }
}