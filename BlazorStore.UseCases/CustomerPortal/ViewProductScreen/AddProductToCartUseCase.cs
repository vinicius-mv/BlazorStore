using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.CustomerPortal.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly IShoppingCart shoppingCart;

        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public AddProductToCartUseCase(IProductRepository productRepository, IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;   
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            await shoppingCart.AddProductAsync(product);

            shoppingCartStateStore.UpdateLineItemsCount();
        }
    }
}
