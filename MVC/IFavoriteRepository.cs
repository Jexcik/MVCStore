using MVC.Models;

namespace MVC
{
    public interface IFavoriteRepository
    {
        List<Product> GetAll();
        void Add(Product product);
    }
}