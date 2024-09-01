﻿using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    [CreateAssetMenu(fileName = "FillGlassWithWaterStrategy", menuName = "PAC/Strategies/Fill Glass With Water Strategy", order = 0)]
    public class FillGlassWithWaterStrategy : Strategy
    {
        public override async UniTask Execute(Transform source, Transform target)
        {
            var waterDispenser = target.GetComponent<WaterDispenser>();
            if (waterDispenser != null)
            {
                var glass = source.GetComponent<Glass>();
                await glass.FillWithDispenser(waterDispenser);
            }
        }
    }
}