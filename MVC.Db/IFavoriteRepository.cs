using MVC.Db.Models;

namespace MVC.Db
{
    public interface IFavoriteRepository
    {
        /// <summary>
        /// Метод для получения всего списка Избранных товаров
        /// </summary>
        /// <returns></returns>
        List<Product> GetAll(string UserId);
        /// <summary>
        /// Метод для добавления выбранного продукта в список избранных
        /// </summary>
        /// <param name="product"></param>
        void Add(string UserId,Product product);
        /// <summary>
        /// Метод для удаление выбранного продукта из списка товаров
        /// </summary>
        /// <param name="product"></param>
        void Del(string UserId, Guid productId);
        
        /// <summary>
        /// Метод для очистки списка избранных товаров
        /// </summary>
        void Clear(string UserId);
    }
}