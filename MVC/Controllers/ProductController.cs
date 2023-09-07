using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsInMemoryRepository productRepository;
        public ProductController()
        {
            productRepository= new ProductsInMemoryRepository();
        }
        public IActionResult Index(int id)
        {
            var product= productRepository.TryGetById(id) ;
            return View(product);
        }
    }
}
