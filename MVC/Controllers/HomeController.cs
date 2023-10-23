using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Db.Models;
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
            var productsViewModels = products.Select(x =>new ProductViewModel() { Id=x.Id, Name=x.Name, Author=x.Author, ReleaseYear=x.ReleaseYear, Cost=x.Cost, Description=x.Description, ImagePath=x.ImagePath}).ToList();
            return View(productsViewModels);
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
