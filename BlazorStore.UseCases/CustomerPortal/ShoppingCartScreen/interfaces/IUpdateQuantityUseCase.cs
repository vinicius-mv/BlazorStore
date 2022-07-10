using BlazorStore.CoreBusiness.Models;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}