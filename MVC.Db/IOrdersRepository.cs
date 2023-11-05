using MVC.Db.Models;

namespace MVC.Db
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        void Add(Order order);
        Order TryGetById(Guid OrderId);
        void UpdateStatus(Guid id, OrderStatus newStatus);
    }
}