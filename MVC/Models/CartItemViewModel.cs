using MVC.Db.Models;

namespace MVC.Models
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost
        {
            get
            {
                return Product.Cost * Amount;
            }
        }
    }
}
