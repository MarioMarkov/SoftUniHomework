using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                var productsToAdd = GetProductsToSeed();

                db.Products.AddRange(productsToAdd);

                var storesToAdd = GetStoresToSeed();

                db.Stores.AddRange(storesToAdd);

                db.SaveChanges();
            }   
        }

        private static List<Store> GetStoresToSeed()
        {
            List<Store> stores = new List<Store>();

            var store1 = new Store()
            {
                Name ="Bolero",
            };
            stores.Add(store1);

            return stores;
        }

        private static List<Product> GetProductsToSeed()
        {
            List<Product> products = new List<Product>();

            var product1 = new Product()
            {
                Name = "Banana",
                Price = 2.50m,
                Quantity = 10
            };
            var product2 = new Product()
            {
                Name = "Tomato",
                Price = 2.20m,
                Quantity = 5
            };
            var product3 = new Product()
            {
                Name = "Apple",
                Price = 1.50m,
                Quantity = 8
            };

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            return products;
        }
    }
}
