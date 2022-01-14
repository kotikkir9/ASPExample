using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp.Models;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();

        // Gets data everytime this model is called
        public IndexModel()
        {
            Products = Database.ListOfProducts;
        }

        // Gets data only on a GET request
        //public void OnGet()
        //{
        //    Products = Database.ListOfProducts;
        //}

        [BindProperty]
        [Required]
        public int Age { get; set; }
        [BindProperty]
        [Required]
        public int ProductId { get; set; }

        public IActionResult OnPostCalculate()  
        {
            // If fetching data using OnGet():
            //var price = Database.ListOfProducts.FirstOrDefault(e => e.Id == ProductId)?.Price;

            // If fetcing data everything this model is called:
            var price = Products.FirstOrDefault(e => e.Id == ProductId)?.Price;

            if (Age < 12)
            {
                price /= 2;
            }
            else if (Age >= 65)
            {
                price -= (price * 0.2);
            }

            return RedirectToPage("Result", new { price });
        }
    }
}
