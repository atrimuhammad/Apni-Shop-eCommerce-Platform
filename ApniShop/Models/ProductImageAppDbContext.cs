using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApniShop.Models
{
    public class ProductImageAppDbContext:DbContext
    {
        public ProductImageAppDbContext(DbContextOptions<ProductImageAppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductImage> ProductImage { get; set; }
    }
}
