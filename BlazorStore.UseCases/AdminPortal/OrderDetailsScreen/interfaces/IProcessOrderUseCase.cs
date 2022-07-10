namespace BlazorStore.UseCases.AdminPortal.OrderDetailsScreen
{
    public interface IProcessOrderUseCase
    {
        bool Execute(int orderId, string adminUserName);
    }
}