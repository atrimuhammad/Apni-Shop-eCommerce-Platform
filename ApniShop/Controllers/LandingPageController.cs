using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApniShop.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult LandingPage()
        {
            return View();
        }
    }
}
