using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Vase : CompleteableObject
    {
        [SerializeField] private Transform waterFillPoint;
        [SerializeField] private Transform plant;

        private Tween _plantGrowTween;
        
        public Transform GetWaterFillPoint()
        {
            return waterFillPoint;
        }
        
        public async UniTask FillWithWater()
        {
            _plantGrowTween = plant.DOScale(1f, 1f);
            _plantGrowTween.OnComplete(Complete);
            
            await _plantGrowTween.AsyncWaitForCompletion();
        }
    }
}