using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApniShop.Models
{
    public class Sell_Item_Context : DbContext
    {
        public Sell_Item_Context(DbContextOptions<Sell_Item_Context> options) : base(options)
        {

        }
        public DbSet<Sell_Item> SellItemsDB { get; set; }
    }
}
