using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class WaterDispenser : CompleteableObject
    {
        [SerializeField] private Transform glassFillPoint;

        public Transform GetGlassFillPoint()
        {
            return glassFillPoint;
        }
        
        public void FillGlass()
        {
            Complete();
        }
    }
}