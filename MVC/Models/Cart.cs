﻿namespace MVC.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items.Sum(item => item.Cost);
            }
        }
        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
