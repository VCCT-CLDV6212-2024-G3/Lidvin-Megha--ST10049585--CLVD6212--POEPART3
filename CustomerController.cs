using CLVD6212_POEPART3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD6212_POEPART3.Controllers
{
    public class CustomerController : Controller
    {
        public Customer usrtbl = new Customer();

        [HttpPost]
        public ActionResult Customer(Customer customer)
        {
            var result = usrtbl.insert_customer(customer);
            return RedirectToAction("Customer", "Home");
        }

        [HttpGet]
        public ActionResult Customer()
        {
            return View(usrtbl);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
