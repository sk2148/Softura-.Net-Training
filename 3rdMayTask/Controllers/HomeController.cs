using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdoMVC.DAL;

namespace AdoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerDAL custDAL = new CustomerDAL();
            List<Customer> CustomerList = new List<Customer>();
            CustomerList = custDAL.GetAllCustomers();
            return View(CustomerList);
        }
        public IActionResult Create()
        {
            CustomerDAL custDAL = new CustomerDAL();
            List<Customer> CustomerList = new List<Customer>();
            CustomerList = custDAL.NewCustomer("Sekar","sv67@gmail.com","7855469954");
            return Content("Saved");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
