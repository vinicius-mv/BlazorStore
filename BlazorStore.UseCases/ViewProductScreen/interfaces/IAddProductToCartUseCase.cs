using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;

namespace BlazorStore.UseCases.ViewProductScreen
{
    public interface IAddProductToCartUseCase
    {
        void Execute(int productId);
    }
}