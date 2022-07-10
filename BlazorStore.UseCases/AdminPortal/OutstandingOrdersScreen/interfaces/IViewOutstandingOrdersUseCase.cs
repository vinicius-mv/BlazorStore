using BlazorStore.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorStore.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}