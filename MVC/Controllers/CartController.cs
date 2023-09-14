using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsInMemoryRepository productsRepository;
        private readonly Constants constants;
        public CartController()
        {
            productsRepository=new ProductsInMemoryRepository();
            constants = new Constants();
        }
        public IActionResult Index()
        {
            var cart = CartsInMemoryRepository.TryGetByUserId(constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId) 
        {
            var product=productsRepository.TryGetById(productId);
            CartsInMemoryRepository.Add(product,constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
