using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Login
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string CheckBox { get; set; }
        public bool RememberMe { get; set; }
    }
}
