using Microsoft.EntityFrameworkCore;
using MVC.Db;
using MVC.Db.Models;
using MVC.Models;

namespace MVC
{
    public class CartsDbRepository : ICartsRepository
    {
        private List<Cart> carts = new List<Cart>(); //Список с корзинами всех пользователей

        private DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Метод для получения корзины конкертного Usera
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(cart => cart.UserId == userId);
        }
        /// <summary>
        /// Метод для добавления продукта в корзину
        /// </summary>
        /// <param name="product"></param>
        /// <param name="userId"></param>
        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);//Получаем корзину конкретного пользователя
            if (existingCart == null) //Если корзина не создана то
            {
                var newCart = new Cart//Создаем корзину
                {
                    UserId = userId //Привязываем ее к конкретному пользователю
                };
                newCart.Items = new List<CartItem> //Создаем 
                {
                    new CartItem
                    {
                        Quantity=1,
                        Product=product
                    }
                };
                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Quantity = 1,
                        Product = product
                    });
                }
            }
            databaseContext.SaveChanges();
        }
        /// <summary>
        /// Метод для удаления конкретного продукта из корзины
        /// </summary>
        /// <param name="product"></param>
        /// <param name="userId"></param>
        public void Del(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);//Получаем корзину конкретного пользователя
            var existingCartItem = existingCart?.Items?.FirstOrDefault(item => item.Product.Id == product.Id);//Получаем продукт в этой корзине по переданному Id
            existingCartItem.Quantity--;//Уменьшаем колличество едениц конкретной позиции в корзине
            if (existingCartItem.Quantity == 0) //Проверяем колличество конкретной позиции в корзине
            {
                existingCart.Items.Remove(existingCartItem);//Если в позиции не осталось товара то удаляем эту позицию из списка позиций в корзине 
            }
            if (existingCart.Items.Count == 0)//Проверяем колличество всех позиций в корзине конкретного пользователя
            {
                databaseContext.Carts.Remove(existingCart); //Удаляем корзину пользователя из списка корзин
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);//Получаем корзину конкретного пользователя
            databaseContext.Carts.Remove(existingCart);//Удаляем из списка конкретную корзину
            databaseContext.SaveChanges();
        }
    }
}
