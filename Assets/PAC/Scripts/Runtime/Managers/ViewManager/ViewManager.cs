using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace PAC.Scripts.Runtime.Managers.ViewManager
{
   public class ViewManager : IViewManager
    {
        readonly Dictionary<string, GameObject> _openedViews = new();

        public Action<string> OnViewLoaded { get; set; }
        public Action<string> OnViewClosed { get; set; }

        public void ForceAddToViewList<T>(LoadViewParams<T> viewPresenter, GameObject viewInstance)
        {
            _openedViews[viewPresenter.GetViewPresenterType()] = viewInstance;
        }

        public void LoadView<T>(LoadViewParams<T> loadViewParams, bool closeAllViews = false, bool closeLastView = false)
        {
            if (closeAllViews)
            {
                DestroyAllViews();
            }

            if (closeLastView)
            {
                var lastView = _openedViews.Last();
                GameObject viewInstance = _openedViews[lastView.Key];
                Object.Destroy(viewInstance);
                _openedViews.Remove(lastView.Key);
                OnViewClosed?.Invoke(lastView.Key);
            }
            
            if (!_openedViews.ContainsKey(loadViewParams.GetViewPresenterType()))
            {
                Addressables.LoadAssetAsync<GameObject>(loadViewParams.ViewName).Completed += (obj) =>
                {
                    if (obj.Status == AsyncOperationStatus.Succeeded)
                    {
                        GameObject viewPrefab = obj.Result;
                        GameObject viewInstance = Object.Instantiate(viewPrefab);
                        viewInstance.transform.SetAsLastSibling();
                        viewInstance.GetComponent<Canvas>().sortingOrder = _openedViews.Count + 1;
                        _openedViews[loadViewParams.GetViewPresenterType()] = viewInstance;
                        loadViewParams.OnLoad?.Invoke(viewInstance.GetComponent<T>());
                        OnViewLoaded?.Invoke(loadViewParams.GetViewPresenterType());
                    }
                };
            }
        }

        public void DestroyView<T>()
        {
            var viewName = typeof(T).Name;
            if (_openedViews.ContainsKey(viewName))
            {
                GameObject viewInstance = _openedViews[viewName];
                Object.Destroy(viewInstance);
                _openedViews.Remove(viewName);
                OnViewClosed?.Invoke(viewName);
            }
        }

        public void DestroyAllViews()
        {
            foreach (var view in _openedViews)
            {
                Object.Destroy(view.Value);
            }
            _openedViews.Clear();
        }

        public bool IsAnyViewActive()
        {
            return _openedViews.Count > 0;
        }

        public bool IsViewActive<T>()
        {
            return _openedViews.ContainsKey(typeof(T).Name);
        }

        public bool IsCurrentView(string viewName)
        {
            if (_openedViews.Count == 0)
            {
                return false;
            }
            
            return _openedViews.Last().Key == viewName;
        }
    }
}