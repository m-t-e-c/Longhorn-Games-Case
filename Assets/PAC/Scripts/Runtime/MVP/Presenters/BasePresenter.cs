using System;

namespace PAC.Scripts.Runtime.MVP.Presenters
{
    public abstract class BasePresenter<T> : IDisposable
    {
        protected readonly T View;
        protected BasePresenter(T view) => View = view;
        public virtual void Dispose(){}
    }
}