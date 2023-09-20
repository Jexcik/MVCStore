using MVC.Models;

namespace MVC
{
    public interface ICompareRepository
    {
        void Add(Product product);
        void Clear();
        void Del(Product product);
        List<Product> GetAllCompare();
    }
}