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
            var products = productRepository.GetAll();
            return View(products);
        }
        public IActionResult Search(string name)
        {
            if (name != null)
            {
                List<Product> products = productRepository.GetAll();
                var findProducts = products.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                return View(findProducts);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
