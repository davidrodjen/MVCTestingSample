﻿using MVCTestingSample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models
{
    /// <summary>
    /// Implements interface, lightbulb
    /// </summary>
    public class EFProductRepository : IProductRespository
    {

        public Task AddProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
