using MVC.Models;

namespace MVC
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}