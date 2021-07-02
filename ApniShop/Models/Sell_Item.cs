using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApniShop.Models
{
    public class Sell_Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemUnitPrice { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemDescription { get; set; }
        public Sell_Item()
        {

        }
    }
}
