using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;
        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetById(id);
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Name = product.Name,
                Author = product.Author,
                ReleaseYear = product.ReleaseYear,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
            return View(productViewModel);
        }
    }
}
