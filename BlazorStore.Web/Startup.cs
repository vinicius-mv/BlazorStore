using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorStore.Web.Data;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
//using BlazorStore.DataStore.HardCoded;
using BlazorStore.DataStore.SQL.Dapper;
using BlazorStore.UseCases.CustomerPortal.SearchProductScreen;
using BlazorStore.UseCases.CustomerPortal.ViewProductScreen;
using BlazorStore.UseCases.PluginsInterfaces.UI;
using BlazorStore.UseCases.CustomerPortal.ShoppingCartScreen;
using BlazorStore.UseCases.PluginsInterfaces.StateStore;
using BlazorStore.StateStore.DI;
using BlazorStore.CoreBusiness.Services.Interfaces;
using BlazorStore.CoreBusiness.Services;
using BlazorStore.UseCases.CustomerPortal.OrderConfirmationScreen;
using BlazorStore.UseCases.AdminPortal.OutstandingOrdersScreen;
using BlazorStore.UseCases.AdminPortal.OrderDetailsScreen;
using BlazorStore.UseCases.AdminPortal.ProcessedOrdersScreen;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlazorStore.DataStore.SQL.Dapper.Helpers;

namespace BlazorStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication(WebConstants.Cookies.AuthenticationScheme)
                .AddCookie(WebConstants.Cookies.AuthenticationScheme, config =>
                {
                    config.Cookie.Name = WebConstants.Cookies.AuthenticationScheme;
                    config.LoginPath = "/authenticate";
                });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<IShoppingCart, ShoppingCart.LocalStorage.ShoppingCart>();
            services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

            services.AddTransient<IDataAccess>(sp => new DataAccess(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

            services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
            services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
            services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
            services.AddTransient<IViewProcessedOrdersScreenUseCase, ViewProcessedOrdersScreenUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
