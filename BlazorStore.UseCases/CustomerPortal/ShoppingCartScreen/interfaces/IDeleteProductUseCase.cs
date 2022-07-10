using BlazorStore.CoreBusiness.Models;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> ExecuteAsync(int productId);
    }
}