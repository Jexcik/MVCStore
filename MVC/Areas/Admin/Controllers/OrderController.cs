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
        public IActionResult EditStatus(Guid id)
        {
            var orders = ordersRepository.GetAllOrders();
            var currentOrder=orders.FirstOrDefault(order=>order.Id==id);
            return View(currentOrder);
        }
        [HttpPost]
        public IActionResult EditStatus(Guid id,OrderStatuses Status)
        {
            var orders = ordersRepository.GetAllOrders();
            var currentOrder = orders.FirstOrDefault(order => order.Id == id);
            currentOrder.Status = Status;
            return RedirectToAction("Index");
        }

    }
}
