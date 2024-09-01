using System;
using DG.Tweening;
using PAC.Scripts.Runtime.Managers.ViewManager;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime.MVP.Views
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup;
        [SerializeField] private bool forceAddToViewList;

        public bool ignoreStartFadeAnimation;
        protected string ViewName;

        private IViewManager _viewManager;
        
        private Tween _fadeTween;

        protected void Awake()
        {
            if (ignoreStartFadeAnimation) 
                return;
            
            canvasGroup.alpha = 0;
            _fadeTween = canvasGroup.DOFade(1, 0.2f);
        }

        protected virtual void Start()
        {
            _viewManager = Locator.Instance.Get<IViewManager>();

            if (forceAddToViewList)
            {
                _viewManager.ForceAddToViewList(new LoadViewParams<T>(ViewName), gameObject);
            }
        }

        protected virtual void Close()
        {
            _fadeTween = canvasGroup.DOFade(0, 0.1f).OnComplete(() => _viewManager?.DestroyView<T>());
        }
        
        protected virtual void OnDestroy()
        {
            _viewManager.DestroyView<T>();
            _fadeTween?.Kill();
        }
    }
}