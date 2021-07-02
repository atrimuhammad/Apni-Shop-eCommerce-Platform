using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApniShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginAppDbContext _auc;
        private readonly RegistrationAppDbContext _buc;

        public LoginController(LoginAppDbContext auc, RegistrationAppDbContext buc)
        {
            _auc = auc;
            _buc = buc;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult AuthorizeLogin(Login l)
        {
            Registration r = _buc.Registrations.FirstOrDefault(i => i.Email == l.Email);

            if((r.Email == l.Email) && (r.Pwd == l.Pwd))
            {
                _auc.Add(l);
                _auc.SaveChanges();

                ViewBag.Message = true;
            }
            else
            {
                ViewBag.Message = false;
            }

            return View();
        }
    }
}
