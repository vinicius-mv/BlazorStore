using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public Task<Order> ExecuteAsync()
        {
            return shoppingCart.GetOrderAsync();
        }
    }
}
