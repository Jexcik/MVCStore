using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Helpers;
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

            return View(Mapping.ToCartViewModel(cart));
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
