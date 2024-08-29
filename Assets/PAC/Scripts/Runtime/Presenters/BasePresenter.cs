using System;

namespace PAC.Scripts.Runtime.Presenters
{
    public abstract class BasePresenter<T> : IDisposable
    {
        protected readonly T View;
        protected BasePresenter(T view) => View = view;
        public virtual void Dispose(){}
    }
}