using MVC.Models;

namespace MVC
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();
        public List<Order> GetAllOrders()
        {
            return orders;
        }
        public void Add(Order order)
        {
            orders.Add(order);
        }

    }
}
