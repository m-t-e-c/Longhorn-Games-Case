using System.Threading.Tasks;
using UnityEngine;

namespace PAC.Scripts.Runtime.Strategies
{
    public abstract class Strategy : ScriptableObject
    {
        public abstract Task Execute(Transform source, Transform target); 
    }
}