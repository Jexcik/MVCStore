using Microsoft.AspNetCore.Mvc;
using MVC.Db;
using MVC.Db.Models;
using MVC.Helpers;
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
            var ordersDb= ordersRepository.GetAllOrders();
            var ordersViewModels = ordersDb.Select(x => Mapping.ToOrderViewModel(x)).ToList();
            return View(ordersViewModels);
        }
        public IActionResult EditStatus(Guid id)
        {
            var orders = ordersRepository.GetAllOrders();
            var currentOrder=orders.FirstOrDefault(order=>order.Id==id);
            return View(Mapping.ToOrderViewModel(currentOrder));
        }
        [HttpPost]
        public IActionResult EditStatus(Guid id, OrderStatus Status)
        {
            ordersRepository.UpdateStatus(id, (OrderStatus)(int)Status);
            return RedirectToAction("Index");
        }
    }
}
