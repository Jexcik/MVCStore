using MVC.Models;

namespace MVC
{
    public static class CartsInMemoryRepository
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }
        public static void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                };
                newCart.Items = new List<CartItem>
                {
                    new CartItem
                    {
                        Amount=1,
                        Product=product
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }
    }
}
