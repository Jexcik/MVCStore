using MVC.Models;

namespace MVC
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(
                "ГОРГОРОД",
                "Oxxxymiron",
                2000,
                "Music album",
                2015,
                "/images/Горгород.jpg"
                ),
            new Product(
                "Дом с нормальными явлениями",
                "Скриптонит",
                1500,
                "Дебютный альбом",
                2015,
                "/images/Скриптонит.jpg"
                ),
            new Product(
                "Ещё",
                "GUF",
                2000,
                "Legendary Album",
                2016,
                "/images/ЕЩЁ.jpg")
        };
        public void Add(Product product)
        {
            products.Add(product);
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
