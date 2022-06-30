using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.SearchProductScreen
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}