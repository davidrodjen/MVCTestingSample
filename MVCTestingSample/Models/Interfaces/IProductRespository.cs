using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models.Interfaces
{
    public interface IProductRespository
    {
        /// <summary>
        /// CRUD Functionality Interface Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Changed the interface to list
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProductsAsync();

        Task AddProductAsync(Product p);

        Task UpdateProductAsync(Product p);

        Task DeleteProductAsync(Product p);
    }
}
