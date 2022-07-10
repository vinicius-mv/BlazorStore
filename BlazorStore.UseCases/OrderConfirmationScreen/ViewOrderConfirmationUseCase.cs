using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.OrderConfirmationScreen
{
    public class ViewOrderConfirmationUseCase : IViewOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrderConfirmationUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Execute(string uniqueId)
        {
            return this.orderRepository.GetOrderByUniqueId(uniqueId);
        }
    }
}
