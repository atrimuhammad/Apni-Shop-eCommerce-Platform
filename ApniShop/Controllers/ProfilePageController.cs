using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ApniShop.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly LoginAppDbContext _auc;
        private readonly RegistrationAppDbContext _buc;
        private readonly RegistrationAppDbContext _cuc;

        public ProfilePageController(LoginAppDbContext auc, RegistrationAppDbContext buc, RegistrationAppDbContext cuc)
        {
            _auc = auc;
            _buc = buc;
            _cuc = cuc;
        }

        public IActionResult ProfilePage()
        {
            Login k = _auc.Loginn.OrderByDescending(i => i.LoginId).FirstOrDefault();

            Registration r = _buc.Registrations.FirstOrDefault(i => i.Email == k.Email);

            Registration rec = new Registration
            {
                Name = r.Name,
                MobileNo = r.MobileNo,
                Email = r.Email
            };

            return View(rec);
        }

        public IActionResult UpdatePersonalInfo()
        {
            Login k = _auc.Loginn.OrderByDescending(i => i.LoginId).FirstOrDefault();

            Registration r = _buc.Registrations.FirstOrDefault(i => i.Email == k.Email);

            Registration rec = new Registration
            {
                Name = r.Name,
                MobileNo = r.MobileNo
            };

            return View(rec);
        }

        public IActionResult SaveUpdatedRegInfo(Registration rr)
        {
            Login k = _auc.Loginn.OrderByDescending(i => i.LoginId).FirstOrDefault();

            Registration r = _buc.Registrations.FirstOrDefault(i => i.Email == k.Email);

            var reg = new Registration
            {
                UserId = r.UserId
            };

            reg.Name = rr.Name;
            _cuc.Entry(reg).Property("Name").IsModified = true;
            _cuc.SaveChanges();

            return View("~/ProfilePage/ProfilePage");
        }
    }
}
