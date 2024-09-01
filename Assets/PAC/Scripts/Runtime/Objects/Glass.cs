using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Glass : MonoBehaviour
    {
        public void FillWithDispenser(WaterDispenser waterDispenser)
        {
            waterDispenser.FillGlass();
            Debug.Log("Filling glass with water from dispenser");
        }
    }
}