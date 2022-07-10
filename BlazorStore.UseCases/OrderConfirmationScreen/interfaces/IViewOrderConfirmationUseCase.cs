using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}