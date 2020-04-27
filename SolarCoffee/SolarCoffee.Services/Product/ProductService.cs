using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly SolarDbContext _db;

        public ProductService(SolarDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Retrieves all Products
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }
        
        /// <summary>
        /// Retrieves a Product by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        /// <summary>
        /// Adds a new Product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product)
        {
            try
            {
                _db.Products.Add(product);
                var newInventory = new ProductInventory
                {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10,
                };
                _db.ProductInventories.Add(newInventory);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    IsSuccess = true,
                    Message = "Product added",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Archives a product by setting boolean IsArchived to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<bool> ArchiveProduct(int id)
        {
            try
            {
                var product = GetProductById(id);
                product.IsArchived = true;
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Archived product",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}