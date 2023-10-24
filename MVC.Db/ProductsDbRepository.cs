using MVC.Db.Models;

namespace MVC.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        //private static List<Product> products = new List<Product>()
        //{
        //    new Product("ГОРГОРОД","Oxxxymiron",2015,2000,"Music album","/images/Горгород.jpg"),
        //    new Product("Дом с нормальными явлениями","Скриптонит",2015,1500,"Дебютный альбом","/images/Скриптонит.jpg"),
        //    new Product("Ещё", "GUF", 2016, 2000, "Legendary Album","/images/ЕЩЁ.jpg"),
        //    new Product("Моя Игра","Баста",2006,3000,"TheBest Production","/images/Баста.jpg")
        //};

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Del(Product product)
        {
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product, Guid Id)
        {
            var existingProduct= databaseContext.Products.FirstOrDefault(x=>x.Id == Id);
            if (existingProduct == null) 
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Description = product.Description;
            existingProduct.ImagePath=product.ImagePath;
            databaseContext.SaveChanges();
        }
    }
}
