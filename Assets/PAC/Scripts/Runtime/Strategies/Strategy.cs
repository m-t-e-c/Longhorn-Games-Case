using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    public abstract class Strategy : ScriptableObject
    {
        public abstract UniTask<bool> Execute(Transform source, Transform target); 
    }
}