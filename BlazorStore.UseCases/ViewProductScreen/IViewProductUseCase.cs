using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.ViewProductScreen
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}