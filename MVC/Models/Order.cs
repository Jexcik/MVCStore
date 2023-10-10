namespace MVC.Models
{
    public enum OrderStatuses
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }

        public List<CartItem> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
        public OrderStatuses Status { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatuses.Created;
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}
