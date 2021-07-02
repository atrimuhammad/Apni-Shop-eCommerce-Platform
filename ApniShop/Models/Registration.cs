using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApniShop.Models
{
    public class Registration
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile #.")]
        [Display(Name = "MobileNo")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Please Enter the Confirm Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Pwd")]
        public string ConfirmPwd { get; set; }
    }
}
