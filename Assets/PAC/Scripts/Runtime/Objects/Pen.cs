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

            _drawingSequence.OnComplete(() =>
            {
                Sequence rotateSequence = DOTween.Sequence();
                rotateSequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 15), 0.2f).SetEase(Ease.InOutSine))
                    .SetLoops(4, LoopType.Yoyo);
                rotateSequence.Append(transform.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.InOutSine));
                rotateSequence.OnComplete(() =>
                {
                    whiteboard.Drawn(color);
                });
                rotateSequence.Play();
            });

            await _drawingSequence.AsyncWaitForCompletion();

        }
    }
}