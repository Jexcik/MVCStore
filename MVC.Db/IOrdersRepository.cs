using MVC.Db.Models;

namespace MVC.Db
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        void Add(Order order);
    }
}