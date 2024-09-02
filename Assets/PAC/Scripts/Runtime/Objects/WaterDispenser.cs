using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class WaterDispenser : CompleteableObject, IActivateable
    {
        [SerializeField] private ParticleSystem waterParticle;
        [SerializeField] private Transform glassFillPoint;
        [SerializeField] private Transform galloon;
        
        private Glass _glass;
        
        private Tween _gallonBounceTween;
        
        public Transform GetGlassFillPoint()
        {
            return glassFillPoint;
        }

        public void SetGlass(Glass glass)
        {
            _glass = glass;
        }

        public async void Activate()
        {
            if (!_glass)
                return;
            
            _gallonBounceTween?.Kill();
            _gallonBounceTween = galloon.DOScale(1.1f, 0.15f).SetLoops(4, LoopType.Yoyo);
            
            waterParticle.Play();
            await UniTask.Delay(2000);
            _glass?.Fill();
            _glass = null;
            Complete();
        }

        private void OnDestroy()
        {
            _gallonBounceTween?.Kill();
        }
    }
}