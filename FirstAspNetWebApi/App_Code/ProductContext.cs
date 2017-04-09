using System.Collections.Generic;
using System.Linq;
using StoneChallenge.Controllers;
using StoneChallenge.Models;
using System;

namespace StoneChallenge
{
    public class ProductContext
    {
        private static readonly List<Product> Products = new List<Product>();

        static ProductContext()
        {
            Products.Add(new Product() {Id = 1 ,List = new List<UInt32> { 1,2} });
            Products.Add(new Product() {Id = 2, List = new List<UInt32> { 0, 1,3,4 } });
            Products.Add(new Product() {Id = 3, List = new List<UInt32> { 1, 4 ,5, 4294967295 } });
          
        }

        //get : /api/Product/{id}
        public Product GetProduct(int id)
        {
            var product = Products.Find(p => p.Id == id);
            return product;
        }

        // get: /api/Product
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Product AddProduct(Product p)
        {
            Products.Add(p);
            return p;
        }

        // DELETE api/product/{id}
        public void Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
        // PUT api/product/{id}
        public bool Update(int id, Product product)
        {
            Product rProduct = Products.FirstOrDefault(p => p.Id == id);
            if (rProduct != null)
            {
                rProduct = product;
                return true;
            }
            return false;
        }
    }
}