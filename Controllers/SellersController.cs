using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    [Route("[controller]")]
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }

    }
}