using MVC.Db.Models;
using MVC.Models;

namespace MVC
{
    public interface IFavoriteRepository
    {
        /// <summary>
        /// Метод для получения всего списка Избранных товаров
        /// </summary>
        /// <returns></returns>
        List<Product> GetAll();
        /// <summary>
        /// Метод для добавления выбранного продукта в список избранных
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);
        /// <summary>
        /// Метод для удаление выбранного продукта из списка товаров
        /// </summary>
        /// <param name="product"></param>
        void Del(Product product);
        
        /// <summary>
        /// Метод для очистки списка избранных товаров
        /// </summary>
        void Clear();
    }
}