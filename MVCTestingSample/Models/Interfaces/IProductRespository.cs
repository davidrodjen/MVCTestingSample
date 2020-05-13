﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models.Interfaces
{
    interface IProductRespository
    {
        /// <summary>
        /// CRUD Functionality Interface Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task AddProductAsync(Product p);

        Task UpdateProductAsync(Product p);

        Task DeleteProductAsync(Product p);
    }
}
