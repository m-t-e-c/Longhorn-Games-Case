using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime
{
    public class Launcher : MonoBehaviour
    {
        private Locator _locator;
        
        private void Awake()
        {
            Debug.Log("Launcher Awake");
            _locator = new Locator();
        }
    }
}