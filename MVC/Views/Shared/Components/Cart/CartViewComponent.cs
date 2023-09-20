using Microsoft.AspNetCore.Mvc;

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
            var productCounts = cart?.Amount;

            return View("Cart", productCounts);
        }
    }
}
