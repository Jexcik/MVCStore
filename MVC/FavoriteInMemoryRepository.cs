using MVC.Models;

namespace MVC
{
    public class FavoriteInMemoryRepository : IFavoriteRepository
    {
        public List<Product> favorite = new List<Product>(); //Заводим список в который будем добавлять избранные продукты

        public void Add(Product product)
        {
            if (!favorite.Contains(product))
            {
                favorite.Add(product);
            }
        }
        public List<Product> GetAll()
        {
            return favorite;
        }
    }
}
