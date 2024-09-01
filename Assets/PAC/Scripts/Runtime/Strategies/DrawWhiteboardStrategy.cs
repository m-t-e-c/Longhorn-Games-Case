using Cysharp.Threading.Tasks;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    [CreateAssetMenu(fileName = "DrawWhiteboardStrategy", menuName = "PAC/Strategies/Draw Whiteboard Strategy", order = 0)]
    public class DrawWhiteboardStrategy : Strategy
    {
        [SerializeField] private Color color;
        
        public override async UniTask Execute(Transform source, Transform target)
        {
            var whiteboard = target.GetComponent<Whiteboard>();
            if (whiteboard != null)
            {
                var pen = source.GetComponent<Pen>();
                await pen.DrawWhiteBoard(whiteboard, color);
            }
        }
    }
}