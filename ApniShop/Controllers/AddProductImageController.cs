using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApniShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApniShop.Controllers
{
    public class AddProductImageController : Controller
    {
        private readonly ProductImageAppDbContext _auc;

        public AddProductImageController(ProductImageAppDbContext auc)
        {
            _auc = auc;
        }

        public IActionResult AddProductImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage()
        {
            foreach (var file in Request.Form.Files)
            {
                ProductImage img = new ProductImage();
                img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _auc.ProductImage.Add(img);
                _auc.SaveChanges();
            }

            ViewBag.Message = "Image(s) stored in database!";

            return View("AddProductImage");
        }

        [HttpPost]
        public ActionResult RetrieveImage()
        {
            ProductImage img = _auc.ProductImage.FirstOrDefault(i => i.Id == 1);

            string imageBase64Data = Convert.ToBase64String(img.ImageData);

            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            ViewBag.ImageTitle = img.ImageTitle;

            ViewBag.ImageDataUrl = imageDataURL;

            return View("AddProductImage");
        }
    }
}
