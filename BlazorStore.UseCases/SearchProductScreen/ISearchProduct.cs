using BlazorStore.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorStore.UseCases.SearchProductScreen
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}