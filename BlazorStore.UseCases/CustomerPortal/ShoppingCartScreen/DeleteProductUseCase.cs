using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;

        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<Order> ExecuteAsync(int productId)
        {
            var order = await this.shoppingCart.DeleteProductAsync(productId);
            this.shoppingCartStateStore.UpdateLineItemsCount();

            return order;
        }
    }
}
