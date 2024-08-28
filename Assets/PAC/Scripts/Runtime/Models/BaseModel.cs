using System;

namespace PAC.Scripts.Runtime.Models
{
    public class BaseModel : IDisposable
    {
        public event Action OnDataChanged;
        
        protected void NotifyDataChanged() => OnDataChanged?.Invoke();
        public virtual void Initialize(){}
        public virtual void Clear() {}
        public virtual void Dispose(){}
    }
}