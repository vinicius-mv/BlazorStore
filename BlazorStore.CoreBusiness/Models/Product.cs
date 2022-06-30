using System;

namespace BlazorStore.CoreBusiness.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
    }
}
