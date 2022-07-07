using BlazorStore.CoreBusiness.Models;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.ShoppingCartScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> ExecuteAsync(int productId);
    }
}