using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
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
            return View(Database.ListOfProducts);
        }

        [HttpPost]
        public IActionResult Index(int productId, int age)
        {
            var product = Database.ListOfProducts.FirstOrDefault(e => e.Id == productId);
            var price = product.Price;
            
            if (age < 12)
            {
                price /= 2;
            } 
            else if (age >= 65)
            {
                price -=(price * 0.2);
            }
            
            return View("Result", price);
        }
        
    }
}