using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApniShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Availability { get; set; }

        public int Demand { get; set; }

        public float rating { get; set; }

        public float NoofPeopleWhoRated { get; set; }
    }
}
