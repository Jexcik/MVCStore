using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Helpers;
using MVC.Models;

namespace MVC.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly Constants constants;
        public CartViewComponent(ICartsRepository cartsRepository, Constants constants)
        {
            this.cartsRepository = cartsRepository;
            this.constants = constants;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var productCounts = cartViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
