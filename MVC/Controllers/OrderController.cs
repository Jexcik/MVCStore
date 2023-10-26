using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Db.Models;
using MVC.Db;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly Constants constants;


        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository, Constants constants)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
            this.constants = constants;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel user)
        {
            if (!user.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");
            }
            if (!user.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
            }
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var existingCart = cartsRepository.TryGetByUserId(constants.UserId);
            var order = new Order
            {
                
                Items = existingCart.Items,

            };
            ordersRepository.Add(order);
            cartsRepository.Clear(constants.UserId);
            return View(order);
        }
    }
}
