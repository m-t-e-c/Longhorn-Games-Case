using System;
using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class CompleteableObject : MonoBehaviour
    {
        public event Action<CompleteableObject> OnComplete;
        public bool IsComplete { get; private set; }

        protected void Complete()
        {
            IsComplete = true;
            OnComplete?.Invoke(this);
        }
    }
}