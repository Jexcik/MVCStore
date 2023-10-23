using MVC.Db.Models;
using MVC.Models;

namespace MVC
{
    public class FavoriteInMemoryRepository : IFavoriteRepository
    {
        public List<Product> favorite = new List<Product>(); //Заводим список в который будем добавлять избранные продукты

        /// <summary>
        /// Метод для добавления избранного продукта в список
        /// </summary>
        /// <param name="product"></param>
        
        public void Add(Product product)
        {
            if (!favorite.Contains(product))
            {
                favorite.Add(product);
            }
        }
        /// <summary>
        /// Метод для удаления избранного продукта из списка
        /// </summary>
        /// <param name="product"></param>
        
        public void Del(Product product)
        {
            favorite.Remove(product);
        }
        /// <summary>
        /// Метод для отчистки списка избранных товаров
        /// </summary>
        public void Clear() => favorite.Clear();

        /// <summary>
        /// Метод для получения списка избранных товаров
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            return favorite;
        }
    }
}
