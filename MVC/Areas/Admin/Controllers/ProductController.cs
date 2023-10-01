using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Del(int id)
        {
            Product product = productsRepository.TryGetById(id);
            productsRepository.Del(product);
            return RedirectToAction("Index");
        }
    }
}
