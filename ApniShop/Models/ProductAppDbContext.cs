using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApniShop.Models
{
    public class ProductAppDbContext : DbContext
    {
        public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
