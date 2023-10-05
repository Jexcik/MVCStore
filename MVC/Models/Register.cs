using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Не указан email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Не указан повторный пароль")]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
