using MVC.Db.Models;

namespace MVC.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
}
