using Microsoft.EntityFrameworkCore;
using MVCTestingSample.Models.Interfaces;
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
        // Add field
        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a product to the data store
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Task AddProductAsync(Product p)
        {
            _context.Add(p);
            return _context.SaveChangesAsync();

            //throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Product p)
        {
            _context.Remove(p);
            return _context.SaveChangesAsync();
            
            //throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.Name).ToListAsync();

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a product by the ID, or null if
        /// no product matches
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Where(p => p.ProductId == id).SingleOrDefaultAsync();

            //throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            return _context.SaveChangesAsync();

            //throw new NotImplementedException();
        }
    }
}
