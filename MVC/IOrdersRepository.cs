using MVC.Models;

namespace MVC
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        void Add(Order order);
    }
}