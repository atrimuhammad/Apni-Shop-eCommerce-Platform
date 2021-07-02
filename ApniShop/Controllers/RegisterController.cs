using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApniShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegistrationAppDbContext _auc;

        public RegisterController(RegistrationAppDbContext auc)
        {
            _auc = auc;
        }

        public IActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveRegistrationInfo(Registration r)
        {
            _auc.Add(r);
            _auc.SaveChanges();
            return View();
        }
    }
}
