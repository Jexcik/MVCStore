using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Register
    {
        [Required]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        [StringLength(50,MinimumLength =8,ErrorMessage ="Пароль должен содержать от 8 до 50 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Не указан повторный пароль")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 50 символов")]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
