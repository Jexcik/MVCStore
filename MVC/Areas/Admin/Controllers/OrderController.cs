using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var orders= ordersRepository.GetAllOrders();
            return View(orders);
        }
    }
}
