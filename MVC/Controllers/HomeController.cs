using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;

        public HomeController(IProductsRepository productsInMemoryRepository)
        {
            this.productRepository = productsInMemoryRepository;
        }

        public IActionResult Index()
        {
            var products= productRepository.GetAll();
            return View(products);
        }
    }
}
