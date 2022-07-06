using BlazorStore.CoreBusiness.Models;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.ShoppingCartScreen
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}