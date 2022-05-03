using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFProduct.Models;

namespace EFProduct.Controllers
{
    public class ProdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(Prod p)
        {
            if(ModelState.IsValid)
            {
                ProductDBContext dBContext = new ProductDBContext();
                dBContext.Add(p);
                dBContext.SaveChanges();
                return Content("Product Created");
            }
            return View("Index");
        }
    }
}
