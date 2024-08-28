using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    [System.Serializable]
    public struct InteractionRule
    {
        public GameObject matchWith;
        public Strategy strategy;
    }
}