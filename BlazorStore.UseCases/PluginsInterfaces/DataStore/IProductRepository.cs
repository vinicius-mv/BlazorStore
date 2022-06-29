using BlazorStore.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.PluginsInterfaces.DataStore
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);

        Product GetProduct(int id);
    }
}
