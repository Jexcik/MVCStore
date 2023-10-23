using MVC.Db.Models;
using MVC.Models;

namespace MVC
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void Del(Product product, string userId);
        void Clear(string userId);
    }
}