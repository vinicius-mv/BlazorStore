using BlazorStore.CoreBusiness.Models;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> ExecuteAsync();
    }
}