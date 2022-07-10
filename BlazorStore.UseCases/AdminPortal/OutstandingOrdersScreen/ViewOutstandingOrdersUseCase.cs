using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutstandingOrders();
        }
    }
}
