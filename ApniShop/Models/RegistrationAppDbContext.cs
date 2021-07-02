using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApniShop.Models
{
    public class RegistrationAppDbContext: DbContext
    {
        public RegistrationAppDbContext(DbContextOptions<RegistrationAppDbContext> options) : base(options)
        {

        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
