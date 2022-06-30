using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;

namespace BlazorStore.UseCases.SearchProductScreen
{
    public class ViewProduct : IViewProduct
    {
        private readonly IProductRepository productRepository;

        public ViewProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
