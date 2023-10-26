using Microsoft.AspNetCore.Mvc;
using MVC.Db;

namespace MVC.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly Constants constants;
        public FavoriteViewComponent(IFavoriteRepository favoriteRepository, Constants constants)
        {
            this.favoriteRepository = favoriteRepository;
            this.constants = constants;
        }
        public IViewComponentResult Invoke()
        {
            var favoriteList = favoriteRepository.GetAll(constants.UserId);
            return View("Favorite", favoriteList);
        }
    }
}
