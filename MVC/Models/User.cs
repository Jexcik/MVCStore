﻿namespace MVC.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CheckBox { get; set; }
        public bool RememberMe { get; set; }
    }
}
