using MVC.Models;

namespace MVC
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("ГОРГОРОД","Oxxxymiron",2015,2000,"Music album","/images/Горгород.jpg"),
            new Product("Дом с нормальными явлениями","Скриптонит",2015,1500,"Дебютный альбом","/images/Скриптонит.jpg"),
            new Product("Ещё", "GUF", 2016, 2000, "Legendary Album","/images/ЕЩЁ.jpg")
        };

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Del(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
