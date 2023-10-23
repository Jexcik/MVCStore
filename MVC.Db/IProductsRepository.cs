using MVC.Db.Models;

namespace MVC.Db
{
    public interface IProductsRepository
    {
        void Add(Product product);
        void Del(Product product);
        List<Product> GetAll();

        /// <summary>
        /// Выбор продукта по id
        /// </summary>
        /// <param name="id">ID продукта</param>
        /// <returns></returns>
        Product TryGetById(Guid id);
    }
}