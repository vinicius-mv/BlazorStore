﻿using BlazorStore.CoreBusiness.Models;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStore.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string cstrShoppingCart = "BlazorStore.ShoppingCart";

        private readonly IJSRuntime jSRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepository)
        {
            this.jSRuntime = jSRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await this.GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await this.SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await this.GetOrder();
            order.RemoveProduct(productId);
            await this.SetOrder(order);

            return order;
        }

        public Task EmptyAsync()
        {
            return this.SetOrder(null);
        }
        public async Task<Order> GetOrderAsync()
        {
            return await this.GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await this.SetOrder(order);

            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await this.GetOrder();

            if (quantity < 0)
                return order;
            else if (quantity == 0)
                return await DeleteProductAsync(productId);
            
            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId  == productId);
            if(lineItem != null) lineItem.Quantity = quantity;
            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;

            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                await this.SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            var serializedOrder = JsonConvert.SerializeObject(order);
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, serializedOrder);
        }
    }
}
