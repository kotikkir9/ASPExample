using System.Collections.Generic;

namespace WebApp.Models
{
    public class Database
    {
        public static ICollection<Product> ListOfProducts { get; set; } = new List<Product>();

        public static void SeedData()
        {
            ListOfProducts.Add(new Product {Id = 1, Name = "Pizza", Price = 70});
            ListOfProducts.Add(new Product {Id = 2, Name = "Pasta", Price = 90});
            ListOfProducts.Add(new Product {Id = 3, Name = "Rice", Price = 50});
        }
    }
}