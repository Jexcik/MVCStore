using MVC.Db.Models;
using MVC.Models;

namespace MVC
{
    public class CompareInMemoryRepository : ICompareRepository
    {
        private List<Product> Compare = new List<Product>();
        public List<Product> GetAllCompare() //Метод для получения списка продуктов для сравнения
        {
            return Compare;
        }
        public void Add(Product product)
        {
            if (!Compare.Contains(product))
            {
                Compare.Add(product);
            }
        }
        public void Clear()
        {
            Compare.Clear();
        }
        public void Del(Product product)
        {
            Compare.Remove(product);
        }
    }
}
