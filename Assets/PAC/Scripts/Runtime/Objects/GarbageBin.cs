using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class GarbageBin : CompleteableObject
    {
        [SerializeField] private Transform garbageFillPoint;
        
        private Sequence _bounceSequence;
        
        public Transform GetGarbageFillPoint()
        {
            return garbageFillPoint;
        }

        public void Fill()
        {
            _bounceSequence?.Kill();
            _bounceSequence = DOTween.Sequence();
            _bounceSequence.Append(transform.DOScale(Vector3.one * 1.2f, 0.1f));
            _bounceSequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.1f));
            _bounceSequence.Append(transform.DOScale(Vector3.one, 0.1f));
            Complete();
        }

        private void OnDestroy()
        {
            _bounceSequence?.Kill();
        }
    }
}