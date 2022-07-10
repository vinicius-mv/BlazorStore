using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;

namespace BlazorStore.UseCases.CustomerPortal.ViewProductScreen
{
    public interface IAddProductToCartUseCase
    {
        void Execute(int productId);
    }
}