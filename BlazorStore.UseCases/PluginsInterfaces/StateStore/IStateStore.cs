using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.PluginsInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListener(Action listener);
        void RemoveStateChangeListener(Action listener);
        void BrodcastStateChange();
    }
}
