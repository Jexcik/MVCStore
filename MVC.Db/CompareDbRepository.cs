using Microsoft.EntityFrameworkCore;
using MVC.Db;
using MVC.Db.Models;

namespace MVC.Db
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
                .Where(u => u.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }
        /// <summary>
        /// Метод для добавления продуктов в список для сравнения
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="product"></param>
        public void Add(string userId, Product product)
        {
            var existingProduct = databaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                databaseContext.CompareProducts.Add(new CompareProduct() { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }
        /// <summary>
        /// Метод для очистки списка сравнения конкретного пользователя
        /// </summary>
        /// <param name="UserId"></param>
        public void Clear(string UserId)
        {
            var userCompareProduct = databaseContext.CompareProducts.Where(u => u.UserId == UserId).ToList();
            databaseContext.CompareProducts.RemoveRange(userCompareProduct);
            databaseContext.SaveChanges();
        }
        /// <summary>
        /// Метод для очистки переданного продукта из списка для сравнения
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="productId"></param>
        public void Del(string UserId, Guid productId)
        {
            var removingCompare=databaseContext.CompareProducts.FirstOrDefault(u=>u.UserId==UserId && u.Product.Id==productId);
            databaseContext.CompareProducts.Remove(removingCompare);
            databaseContext.SaveChanges();
        }
    }
}
