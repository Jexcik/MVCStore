using MVC.Db.Models;

namespace MVC.Db
{
    public interface ICompareRepository
    {
        void Add(string userId, Product product);
        void Clear();
        void Del(Product product);
        List<Product> GetAllCompare(string userId);
    }
}