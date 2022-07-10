using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.UseCases.AdminPortal.OrderDetailsScreen
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}