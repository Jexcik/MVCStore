using MVC.Db.Models;

namespace MVC.Db
{
    public interface ICompareRepository
    {
        void Add(string userId, Product product);
        void Clear(string UserId);
        void Del(string UserId, Guid productId);
        List<Product> GetAllCompare(string userId);
    }
}