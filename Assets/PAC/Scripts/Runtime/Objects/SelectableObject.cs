using System.Collections.Generic;
using DG.Tweening;
using PAC.Scripts.Runtime.Gameplay;
using PAC.Scripts.Runtime.Strategies;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class SelectableObject : MonoBehaviour
    {
        public List<InteractionRule> interactionRules;

        private Vector3 _startPosition;

        protected Sequence SelectSequence;
        protected Sequence FloatSequence;

        private bool _isSelected;

        private void Start()
        {
            _startPosition = transform.position;
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
            SelectSequence.Join(transform.DOMove(_startPosition + Vector3.up * 0.2f, 0.5f).SetEase(Ease.OutBack));

            SelectSequence.OnComplete(() =>
            {
                FloatSequence = DOTween.Sequence();
                FloatSequence.Append(transform.DOMoveY(_startPosition.y + 0.3f, 1f).SetEase(Ease.InOutSine))
                    .SetLoops(-1, LoopType.Yoyo);
            });
        }

        public virtual void Deselect()
        {
            if (!_isSelected)
                return;

            _isSelected = false;
            
            FloatSequence.Kill();
            SelectSequence.Kill();

            transform.DOMove(_startPosition, 0.5f).SetEase(Ease.InBack);
        }
    }
}