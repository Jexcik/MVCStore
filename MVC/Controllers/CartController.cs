using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly Constants constants;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, Constants constants)
        {
            this.productsRepository= productsRepository;
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId) 
        {
            var product=productsRepository.TryGetById(productId);
            cartsRepository.Add(product,constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Del(int productId) 
        {
            var product=productsRepository.TryGetById(productId);
            cartsRepository.Del(product,constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear() 
        {
            cartsRepository.Clear(constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
