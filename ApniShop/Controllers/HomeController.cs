using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApniShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductImageAppDbContext _duc;

        public HomeController(ProductImageAppDbContext duc, ILogger<HomeController> logger)
        {
            _duc = duc;
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
            ProductImage img = _duc.ProductImage.FirstOrDefault(i => i.ImageTitle == "achair");

            string imageBase64Data = Convert.ToBase64String(img.ImageData);

            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            ViewBag.ImageTitle = img.ImageTitle;

            ViewBag.ImageDataUrl = imageDataURL;
            */
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
