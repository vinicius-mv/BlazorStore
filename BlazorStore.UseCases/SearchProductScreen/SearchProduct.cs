using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;
using System.Collections.Generic;

namespace BlazorStore.UseCases.SearchProductScreen
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter = null)
        {
            return productRepository.GetProducts(filter);
        }
    }
}
