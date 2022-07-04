﻿using BlazorStore.CoreBusiness.Models;

namespace BlazorStore.CoreBusiness.Services.Interfaces
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInformation(string name, string address, string city, string province, string country);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}