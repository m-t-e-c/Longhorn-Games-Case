using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Pen : SelectableObject
    {
        private Sequence _drawingSequence;
        
        public async UniTask DrawWhiteBoard(Whiteboard whiteboard, Color color)
        {
            SelectSequence?.Kill();
            FloatSequence?.Kill();
            
            _drawingSequence = DOTween.Sequence();

            _drawingSequence.Append(transform.DOMove(whiteboard.GetDrawingPoint().position, 1f));
            _drawingSequence.Join(transform.DORotate(whiteboard.GetDrawingPoint().rotation.eulerAngles, 1f));
            _drawingSequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 15), 0.2f).SetEase(Ease.InOutSine).SetLoops(4, LoopType.Yoyo));
            _drawingSequence.Append(transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.InOutSine));
            _drawingSequence.AppendCallback(() =>
            {
                whiteboard.Drawn(color);
            });
            _drawingSequence.Append(transform.DOMove(whiteboard.GetPenHolderPoint().position, 1f));
            _drawingSequence.Join(transform.DORotate(whiteboard.GetPenHolderPoint().rotation.eulerAngles, 1f));
            _drawingSequence.OnComplete(SetUsed);

            await _drawingSequence.AsyncWaitForCompletion();
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _drawingSequence?.Kill();
        }
    }
}