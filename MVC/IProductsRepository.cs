using MVC.Models;

namespace MVC
{
    public interface IProductsRepository
    {
        void Add(Product product);
        void Del(Product product);
        List<Product> GetAll();
        Product TryGetById(int id);
    }
}