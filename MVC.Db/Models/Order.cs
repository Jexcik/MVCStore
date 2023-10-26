using System.ComponentModel.DataAnnotations;

namespace MVC.Db.Models
{
    public enum OrderStatuses
    {
        [Display(Name ="Создан")]
        Created,
        [Display(Name = "Обработан")]
        Processed,
        [Display(Name = "В пути")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Отменен")]
        Canceled
    }
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }

        public List<CartItem> Items { get; set; }
        public OrderStatuses Status { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Order()
        {
            Status = OrderStatuses.Created;
            CreateDateTime = DateTime.Now;
        }
    }
}
