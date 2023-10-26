using Microsoft.EntityFrameworkCore;
using MVC.Db.Models;

namespace MVC.Db
{
    public class FavoriteDbRepository : IFavoriteRepository
    {
        private readonly DatabaseContext databaseContext;
        public FavoriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> favorite = new List<Product>(); //Заводим список в который будем добавлять избранные продукты

        /// <summary>
        /// Метод для добавления избранного продукта в список
        /// </summary>
        /// <param name="product"></param>

        public void Add(string UserId, Product product)
        {
            var existingProduct = databaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == UserId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.FavoriteProducts.Add(new FavoriteProduct { Product = product, UserId = UserId });
                databaseContext.SaveChanges();
            }
        }
        /// <summary>
        /// Метод для удаления избранного продукта из списка
        /// </summary>
        /// <param name="product"></param>

        public void Del(string UserId, Guid productId)
        {
            var removingFavorite= databaseContext.FavoriteProducts.FirstOrDefault(u=>u.UserId == UserId && u.Product.Id == productId);
            databaseContext.FavoriteProducts.Remove(removingFavorite);
            databaseContext.SaveChanges();
        }
        /// <summary>
        /// Метод для очистки списка избранных товаров
        /// </summary>
        public void Clear(string UserId)
        {
            var userFavoriteProducts=databaseContext.FavoriteProducts.Where(u=>u.UserId == UserId).ToList();
            databaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            databaseContext.SaveChanges();
        }

        /// <summary>
        /// Метод для получения списка избранных товаров
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll(string UserId)
        {
            return databaseContext.FavoriteProducts.Where(x => x.UserId == UserId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }
    }
}
