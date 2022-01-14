using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICollection<Product> _products;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _products = Database.ListOfProducts;
        }

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpPost]
        public IActionResult Index(int productId, int age)
        {
            var product = _products.FirstOrDefault(e => e.Id == productId);
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