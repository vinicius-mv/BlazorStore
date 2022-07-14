using BlazorStore.CoreBusiness.Models;
using BlazorStore.DataStore.SQL.Dapper.Helpers;
using BlazorStore.UseCases.PluginsInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Product GetProduct(int id)
        {
            string sql = @"SELECT * FROM Product WHERE ProductId = @ProductId";
            return dataAccess.QuerySingle<Product, dynamic>(sql, new { ProductId = id });
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            IEnumerable<Product> result;

            if (string.IsNullOrWhiteSpace(filter))
            {
                string sql = @"SELECT * FROM Product";
                result = dataAccess.Query<Product, dynamic>(sql, new { });
            }
            else
            {
                string sql = @"SELECT * FROM Product WHERE Name LIKE '%@Filter%'";
                result = dataAccess.Query<Product, dynamic>(sql, new { Filter = filter });
            }
            return result;
        }
    }
}
