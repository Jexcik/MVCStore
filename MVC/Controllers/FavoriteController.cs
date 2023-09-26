using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductsRepository productsRepository;
        public FavoriteController(IProductsRepository productsRepository, IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var favoriteList = favoriteRepository.GetAll();
            return View(favoriteList);
        }
        public IActionResult Add(int id)
        {
            var product = productsRepository.TryGetById(id);
            favoriteRepository.Add(product);
            return RedirectToAction("Index");
        }
    }
}
