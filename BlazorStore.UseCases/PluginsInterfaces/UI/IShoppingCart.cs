using BlazorStore.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.PluginsInterfaces.UI
{
    public interface IShoppingCart
    {
        Task<Order> GetOrderAsync();

        Task<Order> AddProductÁsync(Product product);

        Task<Order> UpdateQuantityAsync(int productId, int quantity);

        Task<Order> UpdateOrderAsync(Order order);

        Task<Order> DeleteProductAsync(int productId);

        Task<Order> PlaceOrderAsync();

        Task EmptyAsync();
    }
}
