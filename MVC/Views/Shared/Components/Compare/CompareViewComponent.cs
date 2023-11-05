using Microsoft.AspNetCore.Mvc;
using MVC.Db;

namespace MVC.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareRepository compareRepository; //Объявляем переменную класса хранилища списка сравнений
        private readonly Constants constants;
        public CompareViewComponent(ICompareRepository compareRepository, Constants constants)
        {
            this.compareRepository = compareRepository;
            this.constants = constants;
        }
        public IViewComponentResult Invoke()
        {
            var compareList = compareRepository.GetAllCompare(constants.UserId);
            return View("Compare", compareList);
        }
    }
}
