using CLVD6212_POEPART3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6212_POEPART3.Controllers
{
    public class ProductController : Controller
    {
        public Product prodtbl = new Product();

        [HttpPost]
        public IActionResult MyWork(Product products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("MyWork", "Home");
        }

        [HttpGet]
        public IActionResult MyWork()
        {
            return View(prodtbl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
