using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Введите название роли")]
        public string Name { get; set; }
        public Role() { }
        public Role(string name)
        {
            Name = name;
        }
    }
}
