using System.Collections.Generic;
using DG.Tweening;
using PAC.Scripts.Runtime.Gameplay;
using PAC.Scripts.Runtime.Strategies;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public abstract class SelectableObject : MonoBehaviour
    {
        public List<InteractionRule> interactionRules;

        protected Vector3 StartPosition;
        protected Vector3 StartRotation;

        protected Sequence SelectSequence;
        protected Sequence FloatSequence;

        private bool _isSelected;
        
        public bool IsUsed { get; private set; }

        protected virtual void Start()
        {
            StartPosition = transform.position;
            StartRotation = transform.eulerAngles;
        }

        public Strategy GetStrategyForMatch(GameObject other)
        {
            foreach (var rule in interactionRules)
            {
                if (rule.matchWith == other)
                {
                    return rule.strategy;
                }
            }

            return null;
        }

        public virtual void Select()
        {
            if (_isSelected)
                return;

            _isSelected = true;

            SelectSequence = DOTween.Sequence();
            SelectSequence.Append(transform.DOScale(Vector3.one * 1.2f, 0.1f));
            SelectSequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.1f));
            SelectSequence.Append(transform.DOScale(Vector3.one, 0.1f));
            SelectSequence.Join(transform.DOMove(StartPosition + Vector3.up * 0.2f, 0.5f).SetEase(Ease.OutBack));

            SelectSequence.OnComplete(() =>
            {
                FloatSequence = DOTween.Sequence();
                FloatSequence.Append(transform.DOMoveY(StartPosition.y + 0.3f, 1f).SetEase(Ease.InOutSine))
                    .SetLoops(-1, LoopType.Yoyo);
            });
        }

        protected void SetUsed()
        {
            IsUsed = true;
        }

        public virtual void Deselect()
        {
            if (!_isSelected)
                return;

            _isSelected = false;
            
            FloatSequence.Kill();
            SelectSequence.Kill();

            transform.DOMove(StartPosition, 0.5f).SetEase(Ease.InBack);
        }
        
        protected virtual void OnDestroy()
        {
            SelectSequence?.Kill();
            FloatSequence?.Kill();
        }
    }
}