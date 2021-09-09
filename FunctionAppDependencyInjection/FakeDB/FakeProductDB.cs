﻿using FunctionAppDependencyInjection.Domain;
using System.Collections.Generic;
using System.Linq;

namespace FunctionAppDependencyInjection.FakeProductDB
{
    public class FakeProductDB : IFakeProductDB
    {
        private List<Product> products;

        public FakeProductDB()
        {
            products = new List<Product>();
            products.Add(new Product { ProductID = 1, ProductName = "Ducati 916" });
            products.Add(new Product { ProductID = 2, ProductName = "Benelli TNT Cafe racer" });
        }

        public IEnumerable<Product> GetProducts()
        {
            return products.AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return products.Find(p => p.ProductID == id);
        }

        public Product CreateProduct(string productname)
        {
            var newProduct = new Product() { ProductID = products.Count + 1, ProductName = productname };
            products.Add(newProduct);
            return newProduct;
        }
    }
}