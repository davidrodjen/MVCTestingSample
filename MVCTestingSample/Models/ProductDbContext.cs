using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingSample.Models
{
    /// <summary>
    /// ProductDbContext inherits DbContext, install microsoft.entityframeworkcore
    /// </summary>
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
