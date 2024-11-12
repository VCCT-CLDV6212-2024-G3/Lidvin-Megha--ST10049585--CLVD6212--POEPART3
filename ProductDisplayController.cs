using CLVD6212_POEPART3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6212_POEPART3.Controllers
{
    public class ProductDisplayController : Controller
    {
        
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Order()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
