using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.AdminPortal.ProcessedOrdersScreen
{
    public class ViewProcessedOrdersScreenUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewProcessedOrdersScreenUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetProcessedOrders();
        }
    }
}
