using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly IShoppingCart shoppingCart;

        public AddProductToCartUseCase(IProductRepository productRepository, IShoppingCart shoppingCart)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;   
        }

        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            await shoppingCart.AddProductÁsync(product);
        }
    }
}
