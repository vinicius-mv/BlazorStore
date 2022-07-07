using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using System;

namespace BlazorStore.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners; 

        public void AddStateChangeListener(Action listener) => this.listeners += listener;
        
        public void RemoveStateChangeListener(Action listener) => this.listeners -= listener;


        public void BrodcastStateChange()
        {
            this.listeners?.Invoke();
        }
    }
}
