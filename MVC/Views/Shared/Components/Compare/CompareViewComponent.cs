using Microsoft.AspNetCore.Mvc;

namespace MVC.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareRepository compareRepository; //Объявляем переменную класса хранилища списка сравнений
        public CompareViewComponent(ICompareRepository compareRepository) 
        {
            this.compareRepository = compareRepository;
        }
        public IViewComponentResult Invoke()
        {
            var compareList = compareRepository.GetAllCompare();
            return View("Compare", compareList);
        }
    }
}
