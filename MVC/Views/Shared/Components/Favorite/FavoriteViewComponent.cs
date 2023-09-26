using Microsoft.AspNetCore.Mvc;

namespace MVC.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        public FavoriteViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }
        public IViewComponentResult Invoke()
        {
            var favoriteList = favoriteRepository.GetAll();
            return View("Favorite", favoriteList);
        }
    }
}
