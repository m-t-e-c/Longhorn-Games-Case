using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Glass : SelectableObject
    {
        [SerializeField] private Renderer glassRenderer;
        [SerializeField] private ParticleSystem waterParticleSystem;
        
        private Sequence _moveSequence;
        private Sequence _returnSequence;

        private bool _isFilledWithWater;
        private bool _isWateredPlant;
        
        public async UniTask<bool> MoveToDispenser(WaterDispenser waterDispenser)
        {
            if (_isFilledWithWater)
                return false;
            
            SelectSequence?.Kill();
            FloatSequence?.Kill();
            
            var fillPoint = waterDispenser.GetGlassFillPoint();
            
            _moveSequence?.Kill();
            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(transform.DOMove(fillPoint.position, 1f));
            _moveSequence.Join(transform.DORotate(fillPoint.rotation.eulerAngles, 1f));
            _moveSequence.OnComplete(() =>
            {
                waterDispenser.SetGlass(this);
            });

            await _moveSequence.AsyncWaitForCompletion();
            return true;
        }
        
        public async UniTask<bool> WaterThePlant(Vase vase)
        {
            if (!_isFilledWithWater)
                return false;
            
            SelectSequence?.Kill();
            FloatSequence?.Kill();
            
            _moveSequence?.Kill();
            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(transform.DOMove(vase.GetWaterFillPoint().position, 1f));
            _moveSequence.Join(transform.DORotate(vase.GetWaterFillPoint().rotation.eulerAngles, 1f));
            _moveSequence.OnComplete(() =>
            {
                waterParticleSystem.Play();   
            });

            await _moveSequence.AsyncWaitForCompletion();
            await vase.FillWithWater();
            await UniTask.Delay(1500);
            glassRenderer.material.color = Color.white;
            _isWateredPlant = true;
            PlayReturnSequence();
            return true;
        }

        public async UniTask<bool> MoveToGarbageBin(GarbageBin bin)
        {
            if (!_isWateredPlant)
                return false;
            
            SelectSequence?.Kill();
            FloatSequence?.Kill();
            
            _moveSequence?.Kill();
            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(transform.DOMove(bin.GetGarbageFillPoint().position, 0.75f));
            _moveSequence.Join(transform.DORotate(bin.GetGarbageFillPoint().rotation.eulerAngles, 0.75f));
            _moveSequence.Join(transform.DOScale(0f, 1f));

            await _moveSequence.AsyncWaitForCompletion();
            bin.Fill();
            SetUsed();
            return true;
        }
        
        public void Fill()
        {
            glassRenderer.material.color = new Color(0.18f, 0.72f, 1f);
            _isFilledWithWater = true;
            PlayReturnSequence();
        }
        
        private void PlayReturnSequence()
        {
            _returnSequence = DOTween.Sequence();
            _returnSequence.Append(transform.DOMove(StartPosition, 1f));
            _returnSequence.Join(transform.DORotate(StartRotation, 1f));
            _returnSequence.OnComplete(Deselect);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _moveSequence?.Kill();
            _returnSequence?.Kill();
        }
    }
}