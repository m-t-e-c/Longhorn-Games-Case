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

        public void Select()
        {
            transform.DOMove(_startPosition + Vector3.up * 0.15f, 0.5f).SetEase(Ease.OutBounce);
        }

        public void Deselect()
        {
            transform.DOMove(_startPosition, 0.5f).SetEase(Ease.OutBounce);
        }
    }
}