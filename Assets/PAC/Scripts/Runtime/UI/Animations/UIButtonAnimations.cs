using DG.Tweening;
using PAC.Scripts.Runtime.Managers.SoundManager;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PAC.Scripts.Runtime.UI.Animations
{
    public class UIButtonAnimations : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
    {
        private ISoundManager _soundManager;
        
        private Tween _pointerDownTween;
        private Tween _pointerUpTween;

        private void Start()
        {
            _soundManager = Locator.Instance.Get<ISoundManager>();
        }

        private void PlayPointerDownAnimation()
        {
            _pointerDownTween?.Kill();
            _pointerDownTween = transform.DOScale(Vector3.one * 0.92f, 0.1f);
            _soundManager.PlaySound("button_click");
        }

        private void PlayPointerUpAnimation()
        {
            _pointerUpTween?.Kill();
            _pointerUpTween = transform.DOScale(Vector3.one, 0.1f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PlayPointerDownAnimation();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PlayPointerUpAnimation();
        }
        
        private void OnDestroy()
        {
            _pointerDownTween?.Kill();
            _pointerUpTween?.Kill();
        }
    }
}