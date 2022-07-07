using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.StateStore.DI
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<int> GetItemsCountAsync()
        {
            var order = await shoppingCart.GetOrderAsync();
            if(order != null && order.LineItems != null && order.LineItems.Count > 0)
                return order.LineItems.Count;

            return 0;
        }

        public void UpdateLineItemsCount()
        {
            base.BrodcastStateChange();
        }

        public void UpdateProductQuantity()
        {
            base.BrodcastStateChange();
        }
    }
}
