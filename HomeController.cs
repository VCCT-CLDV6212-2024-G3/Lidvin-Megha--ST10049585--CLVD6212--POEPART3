using CLVD6212_POEPART3.Models;
using CLVD6212_POEPART3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLVD6212_POEPART3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlobService _blobService;
        private readonly TableService _tableService;
        private readonly QueueService _queueService;
        private readonly FileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, BlobService blobService, TableService tableService, QueueService queueService, FileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _blobService = blobService;
            _tableService = tableService;
            _queueService = queueService;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult Order()
        {
            List<Product> products = Product.GetAllProducts();

            int? customerID = _httpContextAccessor.HttpContext.Session.GetInt32("CustomerID");

            ViewData["Products"] = products;
            ViewData["CustomerID"] = customerID;
            return View();
        }

        public IActionResult Order2()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await _blobService.UploadBlobAsync("product-images", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                await _tableService.AddEntityAsync(profile);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderId)
        {
            await _queueService.SendMessageAsync("order-processing", $"Processing order {orderId}");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await _fileService.UploadFileAsync("contracts-logs", file.FileName, stream);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
