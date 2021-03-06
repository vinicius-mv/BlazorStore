using BlazorStore.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorStore.UseCases.CustomerPortal.SearchProductScreen
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}