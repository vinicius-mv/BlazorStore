using BlazorStore.CoreBusiness.Models;
using System.Collections.Generic;

namespace BlazorStore.UseCases.AdminPortal.ProcessedOrdersScreen
{
    public interface IViewProcessedOrdersScreenUseCase
    {
        IEnumerable<Order> Execute();
    }
}