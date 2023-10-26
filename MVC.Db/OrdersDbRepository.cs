using Microsoft.EntityFrameworkCore;
using MVC.Db.Models;

namespace MVC.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;
        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Order> GetAllOrders()
        {
            return databaseContext.Orders
                .Include(x=>x.User)
                .Include(x=>x.Items)
                .ThenInclude(x=>x.Product)
                .ToList();
        }
        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

    }
}
