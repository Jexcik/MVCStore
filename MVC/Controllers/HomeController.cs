using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsInMemoryRepository productRepository;

        public HomeController()
        {
            productRepository = new ProductsInMemoryRepository();
        }

        public IActionResult Index()
        {
            var products= productRepository.GetAll();
            return View(products);
        }
    }
}
