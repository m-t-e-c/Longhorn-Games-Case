using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class WaterDispenser : CompleteableObject
    {
        public void FillGlass()
        {
            Complete();
        }
    }
}