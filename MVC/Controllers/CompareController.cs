using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Helpers;

namespace MVC.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;
        private readonly Constants constants;

        public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository, Constants constants)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
            this.constants = constants;
        }

        public IActionResult Index()
        {
            var compareList = compareRepository.GetAllCompare(constants.UserId); //Получаем список всех товаров добавленных в сравнение
            return View(Mapping.ToProductViewModels(compareList));//Передаем в представление список товаров для сравнения
        }
        public IActionResult Add(Guid id)
        {
            var product = productsRepository.TryGetById(id); //Получаем продукт по ID
            compareRepository.Add(constants.UserId, product);//Добавляем в список для сравнения переданный продукт
            return RedirectToAction("Index");//Переходим на страницу с списком для сравнения
        }
        public IActionResult Del(Guid id)
        {
            var product = productsRepository.TryGetById(id);//Получаем продукт по ID
            compareRepository.Del(constants.UserId, id);//Удаляем из списка сравнения переданный продукт
            return RedirectToAction("Index");//Переходим на главную страницу сравнения
        }
        public IActionResult Clear()
        {
            compareRepository.Clear(constants.UserId);//Через экземпляр класса хранилища очищаем список сравнения
            return RedirectToAction("Index"); //Переходим на главную страницу сравнения
        }
    }
}
