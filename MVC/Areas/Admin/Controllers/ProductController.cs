using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Db.Models;
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
            var productsDb = productsRepository.GetAll();
            var productsViewModels = productsDb.Select(x => new ProductViewModel() { Id = x.Id, Name = x.Name, Author = x.Author, Cost = x.Cost, ReleaseYear = x.ReleaseYear, Description = x.Description, ImagePath = x.ImagePath }).ToList();
            return View(productsViewModels);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            productsRepository.Add(new Product() { Name = newProduct.Name, Author = newProduct.Author, ReleaseYear = newProduct.ReleaseYear, Cost = newProduct.Cost, Description = newProduct.Description, ImagePath = newProduct.ImagePath });
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            Product product = productsRepository.TryGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product, Guid id)
        {
            productsRepository.Update(product, id);
            return RedirectToAction("Index");
        }
        public IActionResult Del(Guid id)
        {
            Product product = productsRepository.TryGetById(id);
            productsRepository.Del(product);
            return RedirectToAction("Index");
        }
    }
}
