using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    //[Route("[controller]")]
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _service.Insert(seller);

            return RedirectToAction(nameof(Index));
        }
    }
}