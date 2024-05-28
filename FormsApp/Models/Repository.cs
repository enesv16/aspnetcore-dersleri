using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, CategoryName = "Phone" });
            _categories.Add(new Category { CategoryId = 2, CategoryName = "Computer" });

            _products.Add(new Product { ProductId = 1, ProductName = "İphone 14", Price = 40000, Image = "1.jpg", IsActive = false, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, ProductName = "İphone 15", Price = 45000, Image = "2.jpg", IsActive = false, CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, ProductName = "İphone 16", Price = 50000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, ProductName = "İphone 17", Price = 55000, Image = "4.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 5, ProductName = "Macbook Pro", Price = 95000, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductId = 6, ProductName = "Macbook Air", Price = 80000, Image = "6.jpg", IsActive = true, CategoryId = 2 });

        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void CreateProduct(Product entity)
        {
            entity.ProductId = _products.Count + 1;
            _products.Add(entity);
        }

        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);

            if (entity != null)
            {
                entity.ProductName = updatedProduct.ProductName;
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }
        
        public static void EditIsActive(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);

            if (entity != null)
            {
                entity.IsActive = updatedProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);
            if (entity != null)
            {
                _products.Remove(entity);
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}