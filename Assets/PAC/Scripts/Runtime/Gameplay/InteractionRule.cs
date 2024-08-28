using PAC.Scripts.Runtime.Strategies;
using UnityEngine;

namespace PAC.Scripts.Runtime.Gameplay
{
    [System.Serializable]
    public struct InteractionRule
    {
        public GameObject matchWith;
        public Strategy strategy;
    }
}