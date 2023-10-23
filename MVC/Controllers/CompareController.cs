using Microsoft.AspNetCore.Mvc;
using MVC.Db;

namespace MVC.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;

        public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
        }

        public IActionResult Index()
        {
            var compareList = compareRepository.GetAllCompare(); //Получаем список всех товаров добавленных в сравнение
            return View(compareList);//Передаем в представление список товаров для сравнения
        }
        public IActionResult Add(Guid id)
        {
            var product = productsRepository.TryGetById(id); //Получаем продукт по ID
            compareRepository.Add(product);//Добавляем в список для сравнения переданный продукт
            return RedirectToAction("Index");//Переходим на страницу с списком для сравнения
        }
        public IActionResult Del(Guid id)
        {
            var product = productsRepository.TryGetById(id);//Получаем продукт по ID
            compareRepository.Del(product);//Удаляем из списка сравнения переданный продукт
            return RedirectToAction("Index");//Переходим на главную страницу сравнения
        }
        public IActionResult Clear()
        {
            compareRepository.Clear();//Через экземпляр класса хранилища очищаем список сравнения
            return RedirectToAction("Index"); //Переходим на главную страницу сравнения
        }
    }
}
