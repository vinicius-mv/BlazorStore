using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.CustomerPortal.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}