using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        ProductsInMemoryRepository products;
        public CartController()
        {
            products=new ProductsInMemoryRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
