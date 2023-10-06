using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string LoginUser { get; set; }
        [Required(ErrorMessage ="Введите пароль")]
        [StringLength(50,MinimumLength =8,ErrorMessage ="Пароль должен содержать от 8 до 50 символов")]
        public string Password { get; set; }
        public string CheckBox { get; set; }
        public bool RememberMe { get; set; }
    }
}
