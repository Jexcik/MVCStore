using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Models;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly Constants constants;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, Constants constants)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(constants.UserId);
            var cartViewModel = new CartViewModel { Id = cart.Id, Items = cart.Items.Select(x => new CartItemViewModel() { Id = x.Id, Product = x.Product, Amount = x.Quantity }).ToList(), UserId = cart.UserId };
            return View(cartViewModel);
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Del(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Del(product, constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsRepository.Clear(constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
