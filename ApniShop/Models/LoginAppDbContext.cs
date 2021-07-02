using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApniShop.Models
{
    public class LoginAppDbContext : DbContext
    {
        public LoginAppDbContext(DbContextOptions<LoginAppDbContext> options) : base(options)
        {

        }
        public DbSet<Login> Loginn { get; set; }
    }
}
