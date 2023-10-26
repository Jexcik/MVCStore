using Microsoft.AspNetCore.Mvc;
using MVC.Db;

namespace MVC.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductsRepository productsRepository;
        private readonly Constants constants;
        
        public FavoriteController(IProductsRepository productsRepository, IFavoriteRepository favoriteRepository, Constants constants)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
            this.constants = constants;
        }
        public IActionResult Index()
        {
            var favoriteList = favoriteRepository.GetAll(constants.UserId);
            return View(favoriteList);
        }
        public IActionResult Add(Guid id)
        {
            var product = productsRepository.TryGetById(id);
            favoriteRepository.Add(constants.UserId,product);
            return Redirect("~/Home/Index");
        }
        public IActionResult Del(Guid id) 
        {
            var product=productsRepository.TryGetById(id); //Получаем продукт из списка продуктов по ID
            favoriteRepository.Del(constants.UserId,id);//Удаляем переданный продукт из списка избранных
            return RedirectToAction("Index");//Переходим к списку избранных
        }
        public IActionResult Clear() 
        {
            favoriteRepository.Clear(constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
