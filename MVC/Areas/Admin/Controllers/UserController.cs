using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
