using Microsoft.EntityFrameworkCore;
using MVC.Db;
using MVC.Db.Models;

namespace MVC
{
    public class CompareDbRepository : ICompareRepository
    {
        private readonly DatabaseContext databaseContext;
        public CompareDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAllCompare(string userId) //Метод для получения списка продуктов для сравнения
        {
            return databaseContext.CompareProducts
                .Where(u=>u.UserId == userId)
                .Include(x=>x.Product)
                .Select(x=>x.Product)
                .ToList();
        }
        public void Add(string userId, Product product)
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
