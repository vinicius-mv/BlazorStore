using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.CustomerPortal.ViewProductScreen
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}