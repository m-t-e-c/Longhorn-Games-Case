using System;

namespace PAC.Scripts.Runtime.MVP.Models
{
    public class BaseModel : IDisposable
    {
        public event Action OnDataChanged;
        protected void NotifyDataChanged() => OnDataChanged?.Invoke();
        public virtual void Dispose(){}
    }
}