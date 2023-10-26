using Microsoft.AspNetCore.Mvc;
using MVC.Db;
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
            var cartViewModel = new CartViewModel { Id = cart.Id, Items = cart.Items.Select(x => new CartItemViewModel { Id = x.Id, Product = x.Product, Amount = x.Quantity }).ToList(), UserId = cart.UserId }?.Amount;
            var productCounts = cart?.Items;

            return View("Cart", cartViewModel);
        }
    }
}
