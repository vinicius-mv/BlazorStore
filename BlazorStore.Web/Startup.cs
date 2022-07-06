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
using BlazorStore.DataStore.HardCoded;
using BlazorStore.UseCases.SearchProductScreen;
using BlazorStore.UseCases.ViewProductScreen;
using BlazorStore.UseCases.PluginsInterfaces.UI;

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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<IProductRepository, ProductRepository>();

            services.AddScoped<IShoppingCart, ShoppingCart.LocalStorage.ShoppingCart>();

            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddTransient<IShoppingCartUseCase, ShoppingCartUseCase>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
