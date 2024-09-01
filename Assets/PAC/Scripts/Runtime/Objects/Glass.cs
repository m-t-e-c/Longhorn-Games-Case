using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Glass : SelectableObject
    {
        [SerializeField] private Renderer glassRenderer;
        
        public async UniTask FillWithDispenser(WaterDispenser waterDispenser)
        {
            SelectSequence?.Kill();
            FloatSequence?.Kill();
            
            var fillPoint = waterDispenser.GetGlassFillPoint();
            var fillSequence = DOTween.Sequence();
            fillSequence.Append(transform.DOMove(fillPoint.position, 1f));
            fillSequence.Join(transform.DORotate(fillPoint.rotation.eulerAngles, 1f));
            fillSequence.OnComplete(() =>
            {
                waterDispenser.FillGlass();
                glassRenderer.material.color = new Color(0.18f, 0.72f, 1f);
            });

            await fillSequence.AsyncWaitForCompletion();
        }
    }
}