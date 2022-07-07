using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using System;

namespace BlazorStore.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action Listeners; 

        public void AddStateChangeListener(Action listener) => this.Listeners += listener;
        
        public void RemoveStateChangeListener(Action listener) => this.Listeners -= listener;

        public void BrodcastStateChange() => this.Listeners?.Invoke();        
    }
}
