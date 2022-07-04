using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.ViewProductScreen
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}