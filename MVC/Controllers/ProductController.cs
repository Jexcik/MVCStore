using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;
        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository= productRepository;
        }
        public IActionResult Index(int id)
        {
            var product= productRepository.TryGetById(id) ;
            return View(product);
        }
    }
}
