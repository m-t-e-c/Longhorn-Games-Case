using Cysharp.Threading.Tasks;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    [CreateAssetMenu(fileName = "WaterThePlantStrategy", menuName = "PAC/Strategies/Water The Plant Strategy", order = 0)]
    public class WaterThePlantStrategy : Strategy
    {
        public override async UniTask<bool> Execute(Transform source, Transform target)
        {
            var vase = target.GetComponent<Vase>();
            if (vase != null)
            {
                var glass = source.GetComponent<Glass>();
                var result = await glass.WaterThePlant(vase);
                return result;
            }

            return false;
        }
    }
}