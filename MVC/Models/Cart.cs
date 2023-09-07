﻿namespace MVC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Cost
        {
            get 
            {
                return Items.Sum(item=>item.Cost); 
            }
        }
    }
}
