using Cysharp.Threading.Tasks;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    [CreateAssetMenu(fileName = "ThrowGlassToGarbageStrategy", menuName = "PAC/Strategies/Throw Glass To Garbage Strategy", order = 0)]
    public class ThrowGlassToGarbageStrategy : Strategy
    {
        public override async UniTask<bool> Execute(Transform source, Transform target)
        {
            var garbageBin = target.GetComponent<GarbageBin>();
            if (garbageBin != null)
            {
                var glass = source.GetComponent<Glass>();
                var result = await glass.MoveToGarbageBin(garbageBin);
                return result;
            }
            return false;
        }
    }
}