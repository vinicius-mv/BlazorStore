using BlazorStore.CoreBusiness.Models;
using BlazorStore.CoreBusiness.Services;
using BlazorStore.CoreBusiness.Services.Interfaces;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;

        private readonly IOrderRepository orderRepository;

        private readonly IShoppingCart shoppingCart;

        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public PlaceOrderUseCase(IOrderService orderService, IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }

        public async Task<string> ExecuteAsync(Order order)
        {
            if (orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqueId = Guid.NewGuid().ToString();
                this.orderRepository.CreateOrder(order);

                await this.shoppingCart.EmptyAsync();

                this.shoppingCartStateStore.UpdateLineItemsCount();

                return order.UniqueId;
            }

            return null;
        }
    }
}
